﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using ShadowsLib;
using Shadows.Properties;

namespace Shadows {
    public partial class EmptyFolders : Form {

        private string _SearchPath;
        private bool _RemoveFoldersThatContainHiddenFiles;
        private readonly object _labelLocker = new object();

        private int foldersScanned;
        private int foldersDeleted;

        public EmptyFolders() {
            InitializeComponent();
        }

        private void onEmptyFoldersLoad(object sender, EventArgs e) {
            Icon = Resources.ShadowsIcon;
        }

        private void onEmptyFoldersFormClosing(object sender, FormClosingEventArgs e) {
            if(worker.IsBusy) {
                if(MessageBox.Show(Strings.EmptyFoldersSearchInProgressText, Strings.EmptyFoldersSearchInProgressCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    worker.CancelAsync();
                }
                else {
                    e.Cancel = true;
                }
            }
        }

        private void onButtonSelectFolderClick(object sender, EventArgs e) {
            if(folderBrowserDialogSelect.ShowDialog() == DialogResult.OK) {
                textboxFolder.Text = folderBrowserDialogSelect.SelectedPath;
                _SearchPath = folderBrowserDialogSelect.SelectedPath;
            }
        }

        private void onCheckboxRemoveIfOnlyHiddenFilesCheckedChanged(object sender, EventArgs e) {
            _RemoveFoldersThatContainHiddenFiles = checkboxRemoveIfOnlyHiddenFiles.Checked;
        }

        private void onButtonStartClick(object sender, EventArgs e) {
            if(SearchPath == null || SearchPath.Equals("")) {
                MessageBox.Show(Strings.EmptyFoldersErrorNoFolderSelectedText, Strings.EmptyFoldersErrorNoFolderSelectedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach(Control element in groupBoxFolder.Controls) {
                Util.ChangeControlStateRecursive(element, false);
            }
            buttonStop.Enabled = true;

            labelScanningFolder.Text = Strings.EmptyFoldersSearching;
            labelMostRecentDeletion.Text = Strings.EmptyFoldersSearching;

            worker.RunWorkerAsync(new DirectoryInfo(SearchPath));
        }

        private void onWorkerDoWork(object sender, DoWorkEventArgs e) {
            foldersScanned = 0;
            foldersDeleted = 0;

            bool res = RemoveEmptyDirectoriesRecursive((DirectoryInfo)e.Argument);
            e.Result = new EmptyFoldersSearchResult(foldersScanned, foldersDeleted, res);
        }

        private bool RemoveEmptyDirectoriesRecursive(DirectoryInfo rootDir) {
            if(worker.CancellationPending) {
                return false;
            }

            DirectoryInfo[] subDirs = rootDir.GetDirectories();
            foreach(DirectoryInfo subDir in subDirs) {
                if(!RemoveEmptyDirectoriesRecursive(subDir)) {
                    return false;
                }
            }

            ++foldersScanned;
            SetLabelTextThreadSafe(labelScanningFolder, String.Format(Strings.EmptyFoldersScanningFolder, rootDir.FullName));

            FileSystemInfo[] contents;
            try {
                contents = rootDir.GetFileSystemInfos();
            }
            catch(Exception e) {
                SetLabelTextThreadSafe(labelMostRecentDeletion, String.Format(Strings.EmptyFoldersSearchError, rootDir.FullName, e.Message));
                return true;
            }

            try {
                if(contents.Length == 0) {
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(rootDir.FullName, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                    ++foldersDeleted;
                    SetLabelTextThreadSafe(labelMostRecentDeletion, String.Format(Strings.EmptyFoldersDeletedFolder, rootDir.FullName));
                }
                else if(RemoveFoldersThatContainHiddenFiles) {
                    int hiddenCount = 0;
                    foreach(FileSystemInfo fileOrDirectory in contents) {
                        if((fileOrDirectory.Attributes & FileAttributes.Directory) == FileAttributes.Directory) {
                            return true;
                        }
                        if((fileOrDirectory.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) {
                            ++hiddenCount;
                        }
                    }

                    if(contents.Length == hiddenCount) {
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(rootDir.FullName, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                        ++foldersDeleted;
                        SetLabelTextThreadSafe(labelMostRecentDeletion, String.Format(Strings.EmptyFoldersDeletedFolder, rootDir.FullName));
                    }
                }
            }
            catch(IOException ioe) {
                SetLabelTextThreadSafe(labelMostRecentDeletion, String.Format(Strings.EmptyFoldersDeletionError, rootDir.FullName, ioe.Message));
            }
            return true;
        }

        private void onWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            EmptyFoldersSearchResult res = (EmptyFoldersSearchResult)e.Result;

            foreach(Control element in groupBoxFolder.Controls) {
                Util.ChangeControlStateRecursive(element, true);
            }
            buttonStop.Enabled = false;

            labelScanningFolder.Text = String.Format(Strings.EmptyFoldersXFoldersScanned, res.FoldersScanned);
            labelMostRecentDeletion.Text = String.Format(Strings.EmptyFoldersXFoldersDeleted, res.FoldersDeleted);
        }

        private void onButtonStopClick(object sender, EventArgs e) {
            worker.CancelAsync();
        }

        private void SetLabelTextThreadSafe(Label label, string newText) {
            label.BeginInvoke((MethodInvoker)delegate {
                lock(_labelLocker) {
                    label.Text = newText;
                }
            });
        }

        public string SearchPath {
            get { return _SearchPath; }
        }

        public bool RemoveFoldersThatContainHiddenFiles {
            get { return _RemoveFoldersThatContainHiddenFiles; }
        }
    }
}
