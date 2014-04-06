using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace ShadowsLib {

    public class SearchEngine : IDisposable {

        public enum ExtensionSearchType {
            All = 0,
            Exclude = 1,
            Include = 2
        }

        private IList<DirectoryInfo> folders;
        private bool compareFileName;
        private bool caseSensitive;
        private bool compareFileExtension;
        private bool compareFileSize;
        private bool compareFileContents;
        private bool includeHiddenFiles;
        private bool includeSystemFiles;
        private Regex fileNameRegex;
        private ExtensionSearchType extensionMode;
        private IList<string> extensions;

        private IList<FileInfoWrapper> allFiles = new List<FileInfoWrapper>();
        private IList<Set<FileInfoWrapper>> allShadows = new List<Set<FileInfoWrapper>>();
        private ulong comparisonsTotal;
        private ulong comparisonsSoFar = 0;
        private int filesScannedSoFar = 0;
        private int progressPercentage = 0;

        private ManualResetEvent pauseEvent = new ManualResetEvent(true);
        private AutoResetEvent cancelEvent = new AutoResetEvent(false);
        private WaitHandle[] waitHandles;
        private volatile bool _Paused = false; // TODO: use locks instead of volatile
        private volatile bool cancellationPending = false;

        public event ComparisonStartedEventHandler ComparisonStarted;
        public event ScanningNewFolderEventHandler ScanningNewFolder;
        public event ScanningNewFileEventHandler ScanningNewFile;
        public event ProgressMadeEventHandler ProgressMade;
        public event ShadowFoundEventHandler ShadowFound;
        public event DirectorySkippedEventHandler DirectorySkipped;
        public event FileSkippedEventHandler FileSkipped;

        public SearchEngine(IList<DirectoryInfo> folders, bool compareFileName, bool caseSensitive, bool compareFileExtension, bool compareFileSize, bool compareFileContents,
                            bool includeHiddenFiles, bool includeSystemFiles, Regex fileNameRegex, ExtensionSearchType extensionMode, IList<string> extensions) {
            this.folders = folders;
            this.compareFileName = compareFileName;
            this.caseSensitive = caseSensitive;
            this.compareFileExtension = compareFileExtension;
            this.compareFileSize = compareFileSize;
            this.compareFileContents = compareFileContents;
            this.includeHiddenFiles = includeHiddenFiles;
            this.includeSystemFiles = includeSystemFiles;
            this.fileNameRegex = fileNameRegex;
            this.extensionMode = extensionMode;
            this.extensions = extensions;

            waitHandles = new WaitHandle[] {
                pauseEvent,
                cancelEvent
            };
        }

        public SearchResult Run() {
            try {
                foreach(DirectoryInfo folder in folders) {
                    ScanForFilesRecursive(folder);
                }
                if(allFiles.Count < 2) {
                    comparisonsTotal = 1;
                    comparisonsSoFar = 1;
                    ReportProgress();
                    return new SearchResult(new List<Set<FileInfoWrapper>>(), allFiles.Count, false);
                }
                comparisonsTotal = CalculateComparisonsTotal();
                CompareAllFiles();
            }
            catch(OperationCanceledException) { }
            // TODO: check for other possible exceptions

            return new SearchResult(allShadows, filesScannedSoFar, cancellationPending);
        }

        public void Cancel() {
            if(Paused) {
                cancelEvent.Set();
            }
            else {
                cancellationPending = true;
            }
        }

        private void ScanForFilesRecursive(DirectoryInfo root) {
            CheckPauseCancel();

            DirectoryInfo[] subDirs;
            FileInfo[] files;

            try {
                subDirs = root.GetDirectories();
                files = root.GetFiles();
            }
            catch(Exception e) {
                RaiseDirectorySkipped(new DirectorySkippedEventArgs(root, e.Message));
                return;
            }

            foreach(DirectoryInfo dir in subDirs) {
                if(IsMatch(dir)) {
                    ScanForFilesRecursive(dir);
                }
            }

            foreach(FileInfo file in files) {
                if(IsMatch(file)) {
                    allFiles.Add(new FileInfoWrapper(file));
                }
            }
        }

        private bool IsMatch(FileInfo file) {
            if(extensionMode == ExtensionSearchType.Exclude) {
                if(file.Extension.Length > 1 && extensions.Contains(file.Extension.Substring(1).ToLower())) {
                    return false;
                }
            }
            else if(extensionMode == ExtensionSearchType.Include) {
                if(file.Extension.Length <= 1 || !extensions.Contains(file.Extension.Substring(1).ToLower())) {
                    return false;
                }
            }
            if(!includeHiddenFiles && (file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) {
                return false;
            }
            if(!includeSystemFiles && (file.Attributes & FileAttributes.System) == FileAttributes.System) {
                return false;
            }
            if(fileNameRegex != null && !fileNameRegex.IsMatch(file.FullName)) {
                return false;
            }
            return true;
        }

        private bool IsMatch(DirectoryInfo dir) {
            if(!includeHiddenFiles && (dir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) {
                return false;
            }
            if(!includeSystemFiles && (dir.Attributes & FileAttributes.System) == FileAttributes.System) {
                return false;
            }
            return true;
        }

        private ulong CalculateComparisonsTotal() {
            ulong ret = 0;
            ulong count = (ulong)allFiles.Count;
            for(ulong i = 1; i < count; ++i) {
                ret += i;
            }
            return ret;
        }

        private void CompareAllFiles() {
            RaiseComparisonStarted(new ComparisonStartedEventArgs(allFiles.Count));

            string currentDir = "";
            for(int i = 0; i < allFiles.Count; ++i) {
                CheckPauseCancel();

                FileInfoWrapper currentFile = allFiles[i];
                if(!currentFile.File.DirectoryName.Equals(currentDir)) { // TODO: check if DirectoryName throws an exception if file is deleted
                    currentDir = currentFile.File.DirectoryName;
                    RaiseScanningNewFolder(new ScanningNewFolderEventArgs(currentFile.File.Directory));
                }
                RaiseScanningNewFile(new ScanningNewFileEventArgs(currentFile.File, filesScannedSoFar + 1, allFiles.Count));

                if(currentFile.Marked) {
                    ++filesScannedSoFar;
                    comparisonsSoFar += (ulong)(allFiles.Count - i - 1);
                    ReportProgress();
                    continue;
                }
                currentFile.Marked = true;

                Set<FileInfoWrapper> currentShadowSet = null;

                for(int j = i + 1; j < allFiles.Count; ++j) {
                    CheckPauseCancel();

                    FileInfoWrapper currentTest = allFiles[j];
                    if(currentTest.Marked) {
                        ++comparisonsSoFar;
                        ReportProgress();
                        continue;
                    }

                    try {
                        if(Compare(currentFile, currentTest)) {
                            currentTest.Marked = true;

                            if(currentShadowSet == null) {
                                currentShadowSet = new Set<FileInfoWrapper>(currentFile, currentTest);
                                allShadows.Add(currentShadowSet);
                            }
                            else {
                                currentShadowSet.Add(currentTest);
                            }
                        }
                    }
                    catch(ChecksumComputingException e) {
                        RaiseFileSkipped(new FileSkippedEventArgs(e.File, e.Message));
                        if(e.File.Equals(currentTest.File)) {
                            currentTest.Marked = true;
                        }
                    }
                    finally {
                        ++comparisonsSoFar;
                        ReportProgress();
                    }
                }

                ++filesScannedSoFar;
                if(currentShadowSet != null) {
                    RaiseShadowFound(new ShadowFoundEventArgs(currentShadowSet));
                }
            }
        }

        private bool Compare(FileInfoWrapper file1, FileInfoWrapper file2) {
            if(compareFileName) {
                string name1, name2;
                if(compareFileExtension) {
                    name1 = file1.File.Name;
                    name2 = file2.File.Name;
                }
                else {
                    name1 = file1.File.Name.Substring(0, file1.File.Name.Length - file1.File.Extension.Length);
                    name2 = file2.File.Name.Substring(0, file2.File.Name.Length - file2.File.Extension.Length);
                }
                if(caseSensitive) {
                    if(!name1.Equals(name2)) {
                        return false;
                    }
                }
                else if(!name1.ToLower().Equals(name2.ToLower())) {
                    return false;
                }
            }

            if(compareFileSize && file1.File.Length != file2.File.Length) {
                return false;
            }

            if(compareFileContents && !file1.Sha1Checksum.Equals(file2.Sha1Checksum)) {
                return false;
            }

            return true;
        }

        private void CheckPauseCancel() {
            if(cancellationPending) {
                throw new OperationCanceledException("Search canceled by user");
            }
            else {
                int waitResult = WaitHandle.WaitAny(waitHandles);

                // If the thread wakes up because of the pauseEvent, continue normally. If the cancelEvent is triggered, abort the operation
                if(waitResult == 1) {
                    throw new OperationCanceledException("Search canceled by user");
                }
            }
        }

        private void ReportProgress() {
            int currentProgressPercentage = (int)Math.Floor((double)(comparisonsSoFar * 100 / comparisonsTotal));
            if(currentProgressPercentage > progressPercentage) {
                progressPercentage = currentProgressPercentage;
                RaiseProgressMade(new ProgressMadeEventArgs(currentProgressPercentage));
            };
        }

        public bool Paused {
            get { return _Paused; }
            set {
                _Paused = value;
                if(_Paused) {
                    pauseEvent.Reset();
                }
                else {
                    pauseEvent.Set();
                }
            }
        }

        protected virtual void RaiseComparisonStarted(ComparisonStartedEventArgs e) {
            ComparisonStartedEventHandler handler = ComparisonStarted;
            if(handler != null) {
                handler(this, e);
            }
        }

        protected virtual void RaiseScanningNewFolder(ScanningNewFolderEventArgs e) {
            ScanningNewFolderEventHandler handler = ScanningNewFolder;
            if(handler != null) {
                handler(this, e);
            }
        }

        protected virtual void RaiseScanningNewFile(ScanningNewFileEventArgs e) {
            ScanningNewFileEventHandler handler = ScanningNewFile;
            if(handler != null) {
                handler(this, e);
            }
        }

        protected virtual void RaiseProgressMade(ProgressMadeEventArgs e) {
            ProgressMadeEventHandler handler = ProgressMade;
            if(handler != null) {
                handler(this, e);
            }
        }

        protected virtual void RaiseShadowFound(ShadowFoundEventArgs e) {
            ShadowFoundEventHandler handler = ShadowFound;
            if(handler != null) {
                handler(this, e);
            }
        }

        protected virtual void RaiseDirectorySkipped(DirectorySkippedEventArgs e) {
            DirectorySkippedEventHandler handler = DirectorySkipped;
            if(handler != null) {
                handler(this, e);
            }
        }

        protected virtual void RaiseFileSkipped(FileSkippedEventArgs e) {
            FileSkippedEventHandler handler = FileSkipped;
            if(handler != null) {
                handler(this, e);
            }
        }

        public void Dispose() {
            pauseEvent.Close();
            cancelEvent.Close();
        }
    }
}
