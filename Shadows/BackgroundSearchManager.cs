using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using Microsoft.WindowsAPICodePack.Taskbar;

using ShadowsLib;

namespace Shadows {
    class BackgroundSearchManager {

        private BackgroundWorker worker;
        private SearchEngine engine;
        private Main _MainForm;

        private IList<FolderItem> _Folders = new List<FolderItem>();
        private bool _CompareFileName;
        private bool _CaseSensitive;
        private bool _CompareFileExtension;
        private bool _CompareFileSize;
        private bool _CompareFileContents;
        private bool _IncludeHiddenFiles;
        private bool _IncludeSystemFiles;
        private Regex _FileNameRegex;
        private IList<string> _Extensions = new List<string>();
        private SearchEngine.ExtensionSearchType _ExtensionMode;

        private int _CurrentProgress = 0;

        private Util.SearchState _State = Util.SearchState.Ready;
        private bool scanHasStarted = false;

        private object stateLocker = new object();

        public BackgroundSearchManager(Main owningForm) {
            _MainForm = owningForm;

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(onWorkerDoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(onWorkerProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(onWorkerRunWorkerCompleted);
        }

        private void onWorkerDoWork(object sender, DoWorkEventArgs e) {
            engine = new SearchEngine(FolderItemListToDirInfoList(_Folders), CompareFileName, CaseSensitive, CompareFileExtension, CompareFileSize, CompareFileContents,
                                      IncludeHiddenFiles, IncludeSystemFiles, FileNameRegex, ExtensionMode, _Extensions);
            engine.ComparisonStarted += new ComparisonStartedEventHandler(onEngineComparisonStarted);
            engine.ScanningNewFolder += new ScanningNewFolderEventHandler(onEngineScanningNewFolder);
            engine.ScanningNewFile += new ScanningNewFileEventHandler(onEngineScanningNewFile);
            engine.ProgressMade += new ProgressMadeEventHandler(onEngineProgressMade);
            engine.ShadowFound += new ShadowFoundEventHandler(onEngineShadowFound);
            engine.DirectorySkipped += new DirectorySkippedEventHandler(onEngineDirectorySkipped);
            engine.FileSkipped += new FileSkippedEventHandler(onEngineFileSkipped);

            SearchResult result = engine.Run();

            e.Result = result;
        }

        void onEngineComparisonStarted(object sender, ComparisonStartedEventArgs e) {
            lock(stateLocker) {
                scanHasStarted = true;
                _State = Util.SearchState.Scanning;
            }

            MainForm.SetLabelTextThreadSafe(MainForm.InfoLabel, Strings.SearchScanningFiles);
            MainForm.SetLabelTextThreadSafe(MainForm.FilesScannedLabel, String.Format(Strings.SearchFileXOfY, 0, e.FilesTotal));
            MainForm.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate {
                MainForm.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            });
        }

        void onEngineScanningNewFolder(object sender, ShadowsLib.ScanningNewFolderEventArgs e) {
            MainForm.SetLabelTextThreadSafe(MainForm.CurrentFolderLabel, String.Format(Strings.SearchScanningFolder, e.NewFolder.FullName));
        }

        void onEngineScanningNewFile(object sender, ScanningNewFileEventArgs e) {
            MainForm.SetLabelTextThreadSafe(MainForm.FilesScannedLabel, String.Format(Strings.SearchFileXOfY, e.FilesScanned, e.FilesTotal));
        }

        void onEngineProgressMade(object sender, ProgressMadeEventArgs e) {
            worker.ReportProgress(e.ProgressPercentage);
        }

        void onEngineShadowFound(object sender, ShadowFoundEventArgs e) {
            MainForm.AddShadowThreadSafe(e.ShadowSet);
        }

        void onEngineDirectorySkipped(object sender, DirectorySkippedEventArgs e) {
            MainForm.SetLabelTextThreadSafe(MainForm.InfoLabel, String.Format(Strings.SearchSkippingFileOrDirectory, e.Directory.FullName, e.Reason));
        }

        void onEngineFileSkipped(object sender, FileSkippedEventArgs e) {
            MainForm.SetLabelTextThreadSafe(MainForm.InfoLabel, String.Format(Strings.SearchSkippingFileOrDirectory, e.File.FullName, e.Reason));
        }

        private void onWorkerProgressChanged(object sender, ProgressChangedEventArgs e) {
            MainForm.ProgressBar.Value = e.ProgressPercentage;
            MainForm.ProgressLabel.Text = String.Format(Strings.SearchProgress, e.ProgressPercentage);
            MainForm.NotifyIcon.Text = String.Format(Strings.SearchProgress, e.ProgressPercentage);
            _CurrentProgress = e.ProgressPercentage;

            if(TaskbarManager.IsPlatformSupported) {
                TaskbarManager.Instance.SetProgressValue(e.ProgressPercentage, 100, MainForm.Handle);
            }
        }

        private void onWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            engine.Dispose();
            engine = null;

            SearchResult result = e.Result as SearchResult;
            if(result != null) {
                lock(stateLocker) _State = result.WasCanceled ? Util.SearchState.Aborted : Util.SearchState.Finished;
                MainForm.SearchPostProcessing(result);
            }
        }

        private IList<System.IO.DirectoryInfo> FolderItemListToDirInfoList(IList<FolderItem> list) {
            IList<System.IO.DirectoryInfo> ret = new List<System.IO.DirectoryInfo>(list.Count);
            foreach(FolderItem folder in list) {
                ret.Add((System.IO.DirectoryInfo)folder);
            }
            return ret;
        }

        public void Run() {
            if(engine == null) {
                worker.RunWorkerAsync();
                lock(stateLocker) _State = Util.SearchState.Counting;
            }
        }

        public void Cancel() {
            if(engine != null) {
                worker.CancelAsync();
                engine.Cancel();
            }
        }

        public void Pause() {
            if(engine != null) {
                engine.Paused = true;
                lock(stateLocker) _State = Util.SearchState.Paused;
            }
        }

        public void Resume() {
            if(engine != null) {
                engine.Paused = false;
                lock(stateLocker) _State = scanHasStarted ? Util.SearchState.Scanning : Util.SearchState.Counting;
            }
        }

        public IList<FolderItem> Folders {
            get { return _Folders; }
        }

        public IList<string> Extensions {
            get { return _Extensions; }
        }

        public bool CompareFileName {
            get { return _CompareFileName; }
            set { _CompareFileName = value; }
        }

        public bool CaseSensitive {
            get { return _CaseSensitive; }
            set { _CaseSensitive = value; }
        }

        public bool CompareFileExtension {
            get { return _CompareFileExtension; }
            set { _CompareFileExtension = value; }
        }

        public bool CompareFileSize {
            get { return _CompareFileSize; }
            set { _CompareFileSize = value; }
        }

        public bool CompareFileContents {
            get { return _CompareFileContents; }
            set { _CompareFileContents = value; }
        }

        public SearchEngine.ExtensionSearchType ExtensionMode {
            get { return _ExtensionMode; }
            set { _ExtensionMode = value; }
        }

        public bool IncludeHiddenFiles {
            get { return _IncludeHiddenFiles; }
            set { _IncludeHiddenFiles = value; }
        }

        public bool IncludeSystemFiles {
            get { return _IncludeSystemFiles; }
            set { _IncludeSystemFiles = value; }
        }

        public Regex FileNameRegex {
            get { return _FileNameRegex; }
            set { _FileNameRegex = value; }
        }

        public int CurrentProgress {
            get { return _CurrentProgress; }
        }

        public Util.SearchState State {
            get { lock(stateLocker) return _State; }
        }

        public Main MainForm {
            get { return _MainForm; }
            set { _MainForm = value; }
        }
    }
}
