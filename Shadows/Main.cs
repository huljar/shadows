using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

using ShadowsLib;
using Shadows.Properties;

namespace Shadows {
    public partial class Main : Form {

        private Panel activePanel;

        private bool showMinimizedInfo = true;
        private bool _MinimizedToSystemTray = false;

        private readonly object _resultsTableLocker = new object();
        private readonly object _resultsTreeLocker = new object();
        private readonly object _labelLocker = new object();

        private enum GridColumnIndices {
            Expand = 0,
            Name = 1,
            Path = 2,
            Size = 3,
            ModDate = 4,
            Type = 5
        }

        /// <summary>
        /// Holds the current instance of BackgroundSearchManager. This is null if no search has been started yet.
        /// </summary>
        private BackgroundSearchManager backgroundSearcher;
        /// <summary>
        /// Holds the current list of FileSystemWatcher instances. When a search starts, 3 FileSystemWatchers are created for each
        /// directory in the folder list: one for files, one for subdirectories, and one that watches the directory itself.
        /// </summary>
        private IList<FileSystemWatcher> fileSystemWatchers = new List<FileSystemWatcher>();

        public Main() {
            InitializeComponent();
            activePanel = panelListView;
        }

        private void onMainLoad(object sender, EventArgs e) {
            // Set up log4net
            LogHelper.SetUpLogger(Settings.Default.LogLevel, Settings.Default.LogActive);

            // Set null value of ResultsTableView image column
            DataGridViewImageColumn col = tableViewResults.Columns[(int)GridColumnIndices.Expand] as DataGridViewImageColumn;
            if(col != null) {
                col.DefaultCellStyle.NullValue = null;
            }

            // Set context menu strips of tree view nodes
            treeViewResults.SetDirNodeMenu(contextMenuDirectoryNode);
            treeViewResults.SetFileNodeMenu(contextMenuFileNode);

            // Apply saved settings to the form
            ApplySavedSettings();

            // Set icons of components
            Icon = Resources.ShadowsIcon;
            nofityIconMinimized.Icon = Resources.ShadowsIcon;

            // Set version in status label
            statuslabelProgramName.Text = "Shadows v" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Padding tmp = progressBarSearchProgress.Margin;
            progressBarSearchProgress.Margin = new Padding(140 - statuslabelProgramName.Width, tmp.Top, tmp.Right, tmp.Bottom);

            splitTable.SplitterDistance = 367; // TODO: remove when implementing new features
        }

        /// <summary>
        /// Retrieves saved user settings and applies them to the form controls.
        /// </summary>
        private void ApplySavedSettings() {
            // Logging
            menuItemActivateLogging.Checked = Settings.Default.LogActive;
            switch(Settings.Default.LogLevel) {
                case 0: menuItemLogLevelInfo.Checked = true; break;
                case 1: menuItemLogLevelWarning.Checked = true; break;
                case 2: menuItemLogLevelError.Checked = true; break;
                case 3: menuItemLogLevelFatal.Checked = true; break;
            }

            // Comparison criteria
            checkboxCompareFileName.Checked = Settings.Default.SearchCompareFileName;
            checkboxCaseSensitive.Checked = Settings.Default.SearchCaseSensitive;
            checkboxFileExtension.Checked = Settings.Default.SearchCompareFileExtension;
            checkboxCompareFileSize.Checked = Settings.Default.SearchCompareFileSize;
            checkboxCompareFileContents.Checked = Settings.Default.SearchCompareFileContents;

            // File types
            radiobuttonAllTypes.Checked = Settings.Default.SearchExtensionMode == 0;
            radiobuttonExcludeTypes.Checked = Settings.Default.SearchExtensionMode == 1;
            radiobuttonIncludeTypes.Checked = Settings.Default.SearchExtensionMode == 2;
            checkboxImages.Checked = Settings.Default.SearchExtensionsImages;
            checkboxMusic.Checked = Settings.Default.SearchExtensionsMusic;
            checkboxVideos.Checked = Settings.Default.SearchExtensionsVideos;
            checkboxCustomTypes.Checked = Settings.Default.SearchExtensionsCustom;

            // Custom extensions
            if(Settings.Default.ExtensionsCustom.Count > 0) {
                StringBuilder exts = new StringBuilder(Settings.Default.ExtensionsCustom.Count * 5);
                foreach(string ext in Settings.Default.ExtensionsCustom) {
                    exts.AppendFormat("{0}, ", ext);
                }
                textboxCustomTypes.Text = exts.ToString(0, exts.Length - 2);
            }

            // Advanced settings
            checkboxHiddenFiles.Checked = Settings.Default.SearchIncludeHiddenFiles;
            checkboxSystemFiles.Checked = Settings.Default.SearchIncludeSystemFiles;
            checkboxMatchRegex.Checked = Settings.Default.SearchMatchRegex;

            // Regex
            textboxMatchRegex.Text = Settings.Default.SearchFileNameRegex;
        }

        private void onMainFormClosing(object sender, FormClosingEventArgs e) {
            // Confirm closing if switched on
            if(Settings.Default.ConfirmExit && MessageBox.Show(Strings.ConfirmExitText, Strings.ConfirmExitCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel) {
                e.Cancel = true;
                return;
            }

            // Stop any running background tasks
            if(backgroundSearcher != null) {
                backgroundSearcher.Cancel();
            }

            // Save regex and custom extensions
            // TODO: find better way so they always get saved without this
            onTextboxCustomTypesLeave(sender, e);
            onTextboxMatchRegexLeave(sender, e);

            // Save settings on shutdown
            Settings.Default.Save();
        }

        #region main menu click events
        private void onMenuItemOptionsClick(object sender, EventArgs e) {
            using(Options options = new Options()) {
                options.ShowDialog();
            }
        }

        private void onMenuItemExitClick(object sender, EventArgs e) {
            Close();
        }

        private void onMenuItemAlwaysOnTopClick(object sender, EventArgs e) {
            TopMost = !TopMost;
            menuItemAlwaysOnTop.Checked = TopMost;
        }

        private void onMenuItemResetWindowSizeClick(object sender, EventArgs e) {
            if(WindowState == FormWindowState.Maximized) {
                WindowState = FormWindowState.Normal;
            }
            Size = new Size(Settings.Default.MainWindowDefaultWidth, Settings.Default.MainWindowDefaultHeight);
            Refresh();
        }

        private void onMenuItemTransparency0Click(object sender, EventArgs e) {
            ChangeWindowOpacity(1.0d, menuItemTransparency0);
        }

        private void onMenuItemTransparency10Click(object sender, EventArgs e) {
            ChangeWindowOpacity(0.9d, menuItemTransparency10);
        }

        private void onMenuItemTransparency20Click(object sender, EventArgs e) {
            ChangeWindowOpacity(0.8d, menuItemTransparency20);
        }

        private void onMenuItemTransparency30Click(object sender, EventArgs e) {
            ChangeWindowOpacity(0.7d, menuItemTransparency30);
        }

        private void onMenuItemTransparency40Click(object sender, EventArgs e) {
            ChangeWindowOpacity(0.6d, menuItemTransparency40);
        }

        private void onMenuItemTransparency50Click(object sender, EventArgs e) {
            ChangeWindowOpacity(0.5d, menuItemTransparency50);
        }

        private void onMenuItemTransparency60Click(object sender, EventArgs e) {
            ChangeWindowOpacity(0.4d, menuItemTransparency60);
        }

        private void onMenuItemTransparency70Click(object sender, EventArgs e) {
            ChangeWindowOpacity(0.3d, menuItemTransparency70);
        }

        private void onMenuItemTransparency80Click(object sender, EventArgs e) {
            ChangeWindowOpacity(0.2d, menuItemTransparency80);
        }

        private void onMenuItemTransparency90Click(object sender, EventArgs e) {
            ChangeWindowOpacity(0.1d, menuItemTransparency90);
        }

        private void ChangeWindowOpacity(double opacity, ToolStripMenuItem correspondingMenuEntry) {
            Opacity = opacity;
            menuItemTransparency0.Checked = false;
            menuItemTransparency10.Checked = false;
            menuItemTransparency20.Checked = false;
            menuItemTransparency30.Checked = false;
            menuItemTransparency40.Checked = false;
            menuItemTransparency50.Checked = false;
            menuItemTransparency60.Checked = false;
            menuItemTransparency70.Checked = false;
            menuItemTransparency80.Checked = false;
            menuItemTransparency90.Checked = false;
            correspondingMenuEntry.Checked = true;
        }

        private void onMenuItemActivateLoggingClick(object sender, EventArgs e) {
            Settings.Default.LogActive = !Settings.Default.LogActive;
            menuItemActivateLogging.Checked = Settings.Default.LogActive;
            LogHelper.SetUpLogger(Settings.Default.LogLevel, Settings.Default.LogActive);
        }

        private void onMenuItemLogLevelFatalClick(object sender, EventArgs e) {
            ChangeLogLevel(3, menuItemLogLevelFatal);
        }

        private void onMenuItemLogLevelErrorClick(object sender, EventArgs e) {
            ChangeLogLevel(2, menuItemLogLevelError);
        }

        private void onMenuItemLogLevelWarningClick(object sender, EventArgs e) {
            ChangeLogLevel(1, menuItemLogLevelWarning);
        }

        private void onMenuItemLogLevelInfoClick(object sender, EventArgs e) {
            ChangeLogLevel(0, menuItemLogLevelInfo);
        }

        private void ChangeLogLevel(byte logLevel, ToolStripMenuItem correspondingMenuEntry) {
            Settings.Default.LogLevel = logLevel;
            menuItemLogLevelInfo.Checked = false;
            menuItemLogLevelWarning.Checked = false;
            menuItemLogLevelError.Checked = false;
            menuItemLogLevelFatal.Checked = false;
            correspondingMenuEntry.Checked = true;
            LogHelper.SetUpLogger(logLevel, Settings.Default.LogActive);
        }

        private void onMenuItemOpenLogFileClick(object sender, EventArgs e) {
            string file = (String.IsNullOrEmpty(Settings.Default.LogDirectory) ? LogHelper.DefaultLogDirectory : Settings.Default.LogDirectory) + "\\" + Settings.Default.LogFileName;
            if(File.Exists(file)) {
                System.Diagnostics.Process.Start(file);
            }
            else {
                MessageBox.Show(Strings.ErrorLogfileNotFoundText, Strings.ErrorLogfileNotFoundCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void onMenuItemExtrasDropDownOpening(object sender, EventArgs e) {
            // Empty Folders Deletion Tool is only available if no search is currently active
            menuItemEmptyFoldersTool.Enabled = backgroundSearcher == null || backgroundSearcher.State == Util.SearchState.Aborted || backgroundSearcher.State == Util.SearchState.Finished;
        }

        private void onMenuItemEmptyFoldersToolClick(object sender, EventArgs e) {
            using(EmptyFolders emptyFolders = new EmptyFolders()) {
                emptyFolders.ShowDialog();
            }
        }

        private void onMenuItemGettingStartedClick(object sender, EventArgs e) {
            // TODO: Getting started
            MessageBox.Show("Not yet implemented.", "Sorry!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void onMenuItemAboutShadowsClick(object sender, EventArgs e) {
            using(AboutShadows about = new AboutShadows()) {
                about.ShowDialog();
            }
        }
        #endregion

        #region folder section events
        private void onButtonAddFolderClick(object sender, EventArgs e) {
            AddFolderWithChecks(new FolderItem(expTreeFolders.SelectedItem), listboxFoldersAdded);
        }

        /// <summary>
        /// Checks if a folder is allowed to be added to the search. If yes, the folder is added to the list. Shows error messages to the user if it is
        /// not a valid folder.
        /// </summary>
        /// <param name="folder">The FolderItem to be added</param>
        /// <param name="target">The FolderListView the FolderItem is supposed to be added to</param>
        /// <returns>true, if the folder was added successfully, otherwise false</returns>
        private bool AddFolderWithChecks(FolderItem folder, FolderListView target) {
            // Check that the folder is not virtual
            if(!folder.CheckRealFolder()) {
                MessageBox.Show(Strings.ErrorVirtualFolderAddedText, Strings.ErrorVirtualFolderAddedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check that the folder is not in the recycle bin
            if(folder.CheckRecycled()) {
                MessageBox.Show(Strings.ErrorRecycledFolderAddedText, Strings.ErrorRecycledFolderAddedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if the folder has already been added
            FolderItem addedFolder = target.GetAddedFolder(folder);
            if(addedFolder != null) {
                target.ClearSelected();
                target.SelectedItem = addedFolder;
                MessageBox.Show(String.Format(Strings.ErrorFolderAlreadyAddedText, folder.Node.DisplayName), Strings.ErrorFolderAlreadyAddedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if a parent folder has already been added
            FolderItem addedParent = target.GetAddedParentFolder(folder);
            if(addedParent != null) {
                target.ClearSelected();
                target.SelectedItem = addedParent;
                MessageBox.Show(String.Format(Strings.ErrorParentFolderAlreadyAddedText, addedParent.Node.DisplayName), Strings.ErrorParentFolderAlreadyAddedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if subdirectories of the added folder have already been added
            IList<FolderItem> addedSubfolders = target.GetAddedSubfolders(folder);
            if(addedSubfolders.Count != 0) {
                target.ClearSelected();
                foreach(FolderItem item in addedSubfolders) {
                    target.SelectedItem = item;
                }
                string message = addedSubfolders.Count == 1
                                 ? String.Format(Strings.WarningSingleSubfolderAlreadyAddedText, addedSubfolders[0].Node.DisplayName, folder.Node.DisplayName)
                                 : String.Format(Strings.WarningMultipleSubfoldersAlreadyAddedText, folder.Node.DisplayName);
                if(MessageBox.Show(message, Strings.WarningSubfolderAlreadyAddedCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    foreach(FolderItem item in addedSubfolders) {
                        target.Items.Remove(item);
                    }
                }
                else {
                    return false;
                }
            }

            // Add the folder if the function reaches this point
            target.Items.Add(folder);
            return true;
        }

        private void onButtonRemoveFolderClick(object sender, EventArgs e) {
            List<FolderItem> toRemove = new List<FolderItem>(listboxFoldersAdded.SelectedItems.Count);
            foreach(FolderItem selectedFolder in listboxFoldersAdded.SelectedItems) {
                toRemove.Add(selectedFolder);
            }
            RemoveFolders(toRemove, listboxFoldersAdded);
        }

        private void RemoveFolders(IEnumerable<FolderItem> toRemove, FolderListView target) {
            foreach(FolderItem item in toRemove) {
                RemoveFolder(item, target);
            }
        }

        private void RemoveFolder(FolderItem toRemove, FolderListView target) {
            target.Items.Remove(toRemove);
        }

        private void onListboxFoldersAddedDragEnter(object sender, DragEventArgs e) {
            // Allow drag & drop if only directories are being dragged (from Windows Explorer)
            if(Util.CheckDragDropOnlyDirectories(e.Data)) {
                e.Effect = DragDropEffects.Link;
                listboxFoldersAdded.BackColor = SystemColors.GradientActiveCaption;
            }
        }

        private void onListboxFoldersAddedDragLeave(object sender, EventArgs e) {
            listboxFoldersAdded.BackColor = SystemColors.Window;
        }

        private void onListboxFoldersAddedDragDrop(object sender, DragEventArgs e) {
            listboxFoldersAdded.BackColor = SystemColors.Window;

            if(Util.CheckDragDropOnlyDirectories(e.Data)) {
                string[] directories = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach(string dir in directories) {
                    AddFolderWithChecks(new FolderItem(dir), listboxFoldersAdded);
                }
            }
        }

        private void onContextItemShowHiddenFoldersClick(object sender, EventArgs e) {
            ExpTreeLib.CShItem selectedNode = expTreeFolders.SelectedItem;
            contextItemShowHiddenFolders.Checked = !contextItemShowHiddenFolders.Checked;
            expTreeFolders.ShowHiddenFolders = contextItemShowHiddenFolders.Checked;
            expTreeFolders.RefreshTree();
            expTreeFolders.ExpandANode(selectedNode);
        }

        private void onContextItemRefreshTreeClick(object sender, EventArgs e) {
            ExpTreeLib.CShItem selectedNode = expTreeFolders.SelectedItem;
            expTreeFolders.RefreshTree();
            expTreeFolders.ExpandANode(selectedNode);
        }

        private void onContextItemSelectAllClick(object sender, EventArgs e) {
            for(int i = 0; i < listboxFoldersAdded.Items.Count; ++i) {
                listboxFoldersAdded.SetSelected(i, true);
            }
        }

        private void onContextItemSelectNoneClick(object sender, EventArgs e) {
            for(int i = 0; i < listboxFoldersAdded.Items.Count; ++i) {
                listboxFoldersAdded.SetSelected(i, false);
            }
        }

        private void onContextItemInvertSelectionClick(object sender, EventArgs e) {
            for(int i = 0; i < listboxFoldersAdded.Items.Count; ++i) {
                listboxFoldersAdded.SetSelected(i, !listboxFoldersAdded.GetSelected(i));
            }
        }
        #endregion

        #region settings section events
        private void onCheckboxCompareFileNameCheckedChanged(object sender, EventArgs e) {
            bool check = checkboxCompareFileName.Checked;
            Settings.Default.SearchCompareFileName = check;

            checkboxCaseSensitive.Enabled = check;
            checkboxFileExtension.Enabled = check;
        }

        private void onCheckboxCaseSensitiveCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchCaseSensitive = checkboxCaseSensitive.Checked;
        }

        private void onCheckboxFileExtensionCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchCompareFileName = checkboxFileExtension.Checked;
        }

        private void onCheckboxCompareFileSizeCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchCompareFileSize = checkboxCompareFileSize.Checked;

            if(!checkboxCompareFileSize.Checked) {
                checkboxCompareFileContents.Checked = false;
            }
        }

        private void onCheckboxCompareFileContentsCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchCompareFileContents = checkboxCompareFileContents.Checked;

            if(checkboxCompareFileContents.Checked) {
                checkboxCompareFileSize.Checked = true;
            }
        }

        private void onRadiobuttonAllTypesCheckedChanged(object sender, EventArgs e) {
            bool check = radiobuttonAllTypes.Checked;
            if(check) {
                Settings.Default.SearchExtensionMode = 0;
            }

            checkboxImages.Enabled = !check;
            checkboxMusic.Enabled = !check;
            checkboxVideos.Enabled = !check;
            checkboxCustomTypes.Enabled = !check;
            textboxCustomTypes.Enabled = !check && checkboxCustomTypes.Checked;
        }

        private void onRadiobuttonExcludeTypesCheckedChanged(object sender, EventArgs e) {
            if(radiobuttonExcludeTypes.Checked) {
                Settings.Default.SearchExtensionMode = 1;
            }
        }

        private void onRadiobuttonIncludeTypesCheckedChanged(object sender, EventArgs e) {
            if(radiobuttonIncludeTypes.Checked) {
                Settings.Default.SearchExtensionMode = 2;
            }
        }

        private void onCheckboxImagesCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchExtensionsImages = checkboxImages.Checked;
        }

        private void onCheckboxMusicCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchExtensionsMusic = checkboxMusic.Checked;
        }

        private void onCheckboxVideosCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchExtensionsVideos = checkboxVideos.Checked;
        }

        private void onCheckboxCustomTypesCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchExtensionsCustom = checkboxCustomTypes.Checked;
            textboxCustomTypes.Enabled = checkboxCustomTypes.Checked;
        }

        private void onTextboxCustomTypesLeave(object sender, EventArgs e) {
            if(Util.IsValidExtensionInput(textboxCustomTypes.Text)) {
                textboxCustomTypes.BackColor = SystemColors.Window;
                Settings.Default.ExtensionsCustom = Util.FormatForSettings(textboxCustomTypes.Text, ',');
            }
            else {
                textboxCustomTypes.BackColor = Color.IndianRed;
            }
        }

        private void onCheckboxHiddenFilesCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchIncludeHiddenFiles = checkboxHiddenFiles.Checked;
        }

        private void onCheckboxSystemFilesCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchIncludeSystemFiles = checkboxSystemFiles.Checked;
        }

        private void onCheckboxMatchRegexCheckedChanged(object sender, EventArgs e) {
            Settings.Default.SearchMatchRegex = checkboxMatchRegex.Checked;
            textboxMatchRegex.Enabled = checkboxMatchRegex.Checked;
        }

        private void onTextboxMatchRegexLeave(object sender, EventArgs e) {
            if(Util.IsValidRegex(textboxMatchRegex.Text)) {
                textboxMatchRegex.BackColor = SystemColors.Window;
                Settings.Default.SearchFileNameRegex = textboxMatchRegex.Text;
            }
            else {
                textboxMatchRegex.BackColor = Color.IndianRed;
            }
        }
        #endregion

        #region search button events
        private void onButtonStartSearchClick(object sender, EventArgs e) {
            if(backgroundSearcher != null && backgroundSearcher.State == Util.SearchState.Paused) {
                // Resume paused search
                backgroundSearcher.Resume();
                SetSearchControlStates(Util.StateChange.Resume);
            }
            else {
                // Start new search
                if(PerformSearchStartChecks(listboxFoldersAdded.Items.Cast<FolderItem>(), true)) {
                    StartSearch();
                    SetSearchControlStates(Util.StateChange.Start);
                }
            }
        }

        private void onButtonStopSearchClick(object sender, EventArgs e) {
            backgroundSearcher.Cancel();
            SetSearchControlStates(Util.StateChange.Stop);
        }

        private void onButtonPauseSearchClick(object sender, EventArgs e) {
            backgroundSearcher.Pause();
            SetSearchControlStates(Util.StateChange.Pause);
        }

        /// <summary>
        /// Performs all necessary operations to start a new search.
        /// </summary>
        private void StartSearch() {
            tableViewResults.Reset();
            treeViewResults.Reset();
            foreach(FolderItem folder in listboxFoldersAdded.Items) {
                treeViewResults.RootFolders.Add(folder);
            }
            InitializeSearchEngine();
            InitializeFileSystemWatchers();
            LogHelper.LogSearchStart(this);
            backgroundSearcher.Run();
        }

        /// <summary>
        /// Checks if the settings are valid to start a new search.
        /// </summary>
        /// <param name="folders">The list of folders added to the search</param>
        /// <param name="displayErrors">true to show errors to the user, otherwise false</param>
        /// <returns>true if all checks have passed, otherwise false</returns>
        private bool PerformSearchStartChecks(IEnumerable<FolderItem> folders, bool displayErrors) {
            // Check if a folder was specified
            if(folders.Count() == 0) {
                if(displayErrors) MessageBox.Show(Strings.ErrorNoFoldersAddedText, Strings.ErrorNoFoldersAddedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if at least one comparison criterion is checked
            if(!checkboxCompareFileName.Checked && !checkboxCompareFileSize.Checked) {
                if(displayErrors) MessageBox.Show(Strings.ErrorNoComparisonCriterionCheckedText, Strings.ErrorNoComparisonCriterionCheckedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if custom extension input is valid
            if(checkboxCustomTypes.Checked && !Util.IsValidExtensionInput(textboxCustomTypes.Text)) {
                if(displayErrors) MessageBox.Show(Strings.ErrorIncorrectCustomFileTypesText, Strings.ErrorIncorrectCustomFileTypesCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if at least one file type was specified
            if(radiobuttonIncludeTypes.Checked && !checkboxImages.Checked && !checkboxMusic.Checked && !checkboxVideos.Checked
                    && (!checkboxCustomTypes.Checked || Settings.Default.ExtensionsCustom.Count == 0)) {
                if(displayErrors) MessageBox.Show(Strings.ErrorNoFileTypesSpecifiedText, Strings.ErrorNoFileTypesSpecifiedCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if user is admin if system files shall be searched
            if(checkboxSystemFiles.Checked && !(new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))) {
                if(displayErrors) MessageBox.Show(Strings.ErrorSystemFilesWithoutAdminPrivilegesText, Strings.ErrorSystemFilesWithoutAdminPrivilegesCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if the regular expression entered is valid if the file name shall match it
            if(checkboxMatchRegex.Checked && !Util.IsValidRegex(textboxMatchRegex.Text)) {
                if(displayErrors) MessageBox.Show(Strings.ErrorInvalidRegexEnteredText, Strings.ErrorInvalidRegexEnteredCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if all added folders exist
            foreach(FolderItem folder in listboxFoldersAdded.Items) {
                DirectoryInfo dir = (DirectoryInfo)folder;
                if(dir == null || !dir.Exists) {
                    if(displayErrors) MessageBox.Show(String.Format(Strings.ErrorUnableToAccessFolderText, folder.Node.DisplayName), Strings.ErrorUnableToAccessFolderCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            // End of checks
            return true;
        }
        
        /// <summary>
        /// Changes the enabled state of form controls to match the search state transition.
        /// </summary>
        /// <param name="stateChange">the search state transition</param>
        private void SetSearchControlStates(Util.StateChange stateChange) {
            if(stateChange == Util.StateChange.Start) {
                buttonStartSearch.Enabled = false;
                buttonPauseSearch.Enabled = true;
                buttonStopSearch.Enabled = true;
                buttonMinimize.Enabled = true;
                ChangeControlStatesFoldersAndSettings(false);

                labelStatus.Text = Strings.SearchStatusActive;
                labelProgress.Text = String.Format(Strings.SearchProgress, 0);
                labelFilesScanned.Text = Strings.SearchCountingFiles;
                labelCurrentFolder.Text = Strings.SearchNotScanningYet;
                statusLabelInfos.Text = Strings.SearchCountingFiles;
                progressBarSearchProgress.Value = 0;
                progressBarSearchProgress.Style = ProgressBarStyle.Marquee;

                progressBarSearchProgress.Visible = true;
                statusLabelInfos.Visible = true;

                if(TaskbarManager.IsPlatformSupported) {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, Handle);
                    TaskbarManager.Instance.SetProgressValue(0, 100, Handle);
                }
            }
            else if(stateChange == Util.StateChange.Stop) {
                buttonStartSearch.Enabled = true;
                buttonPauseSearch.Enabled = false;
                buttonStopSearch.Enabled = false;
                buttonMinimize.Enabled = false;
                ChangeControlStatesFoldersAndSettings(true);

                labelStatus.Text = Strings.SearchStatusAborted;
                progressBarSearchProgress.Style = ProgressBarStyle.Continuous;

                progressBarSearchProgress.Visible = false;
                statusLabelInfos.Visible = false;

                if(TaskbarManager.IsPlatformSupported) {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Handle);
                }
            }
            else if(stateChange == Util.StateChange.Pause) {
                buttonStartSearch.Enabled = true;
                buttonPauseSearch.Enabled = false;
                buttonMinimize.Enabled = false;

                labelStatus.Text = Strings.SearchStatusPaused;

                statusLabelInfos.Visible = false;

                if(TaskbarManager.IsPlatformSupported) {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Paused);
                }
            }
            else if(stateChange == Util.StateChange.Resume) {
                buttonStartSearch.Enabled = false;
                buttonPauseSearch.Enabled = true;
                buttonMinimize.Enabled = true;

                labelStatus.Text = Strings.SearchStatusActive;
                statusLabelInfos.Text = Strings.SearchScanningFiles;

                statusLabelInfos.Visible = true;

                if(TaskbarManager.IsPlatformSupported) {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                }
            }
            else if(stateChange == Util.StateChange.Complete) {
                buttonStartSearch.Enabled = true;
                buttonPauseSearch.Enabled = false;
                buttonStopSearch.Enabled = false;
                buttonMinimize.Enabled = false;
                ChangeControlStatesFoldersAndSettings(true);

                labelStatus.Text = Strings.SearchStatusCompleted;

                progressBarSearchProgress.Visible = false;
                statusLabelInfos.Visible = false;

                if(TaskbarManager.IsPlatformSupported) {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress, Handle);
                }
            }
        }

        /// <summary>
        /// Enables or disables the form controls of the Folders section and the Settings section properly.
        /// </summary>
        /// <param name="enable">true to enable components, false to disable</param>
        private void ChangeControlStatesFoldersAndSettings(bool enable) {
            foreach(Control element in groupFolders.Controls) {
                Util.ChangeControlStateRecursive(element, enable);
            }
            foreach(Control element in tabControlSettings.Controls) {
                Util.ChangeControlStateRecursive(element, enable);
            }

            if(enable) {
                if(!checkboxCompareFileName.Checked) {
                    checkboxCaseSensitive.Enabled = false;
                    checkboxFileExtension.Enabled = false;
                }

                if(radiobuttonAllTypes.Checked) {
                    checkboxImages.Enabled = false;
                    checkboxMusic.Enabled = false;
                    checkboxVideos.Enabled = false;
                    checkboxCustomTypes.Enabled = false;
                    textboxCustomTypes.Enabled = false;
                }
                else {
                    if(!checkboxCustomTypes.Checked) {
                        textboxCustomTypes.Enabled = false;
                    }
                }

                if(!checkboxMatchRegex.Checked) {
                    textboxMatchRegex.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Creates a new BackgroundSearchManager and passes it all necessary user settings.
        /// </summary>
        private void InitializeSearchEngine() {
            backgroundSearcher = new BackgroundSearchManager(this);

            foreach(FolderItem folder in listboxFoldersAdded.Items) {
                backgroundSearcher.Folders.Add(folder);
            }

            backgroundSearcher.CompareFileName = checkboxCompareFileName.Checked;
            backgroundSearcher.CaseSensitive = checkboxCaseSensitive.Checked;
            backgroundSearcher.CompareFileExtension = checkboxFileExtension.Checked;
            backgroundSearcher.CompareFileSize = checkboxCompareFileSize.Checked;
            backgroundSearcher.CompareFileContents = checkboxCompareFileContents.Checked;

            if(radiobuttonAllTypes.Checked) {
                backgroundSearcher.ExtensionMode = SearchEngine.ExtensionSearchType.All;
            }
            else {
                if(radiobuttonExcludeTypes.Checked) {
                    backgroundSearcher.ExtensionMode = SearchEngine.ExtensionSearchType.Exclude;
                }
                else {
                    backgroundSearcher.ExtensionMode = SearchEngine.ExtensionSearchType.Include;
                }

                if(checkboxImages.Checked) {
                    foreach(string ext in Settings.Default.ExtensionsImages) {
                        backgroundSearcher.Extensions.Add(ext);
                    }
                }
                if(checkboxMusic.Checked) {
                    foreach(string ext in Settings.Default.ExtensionsMusic) {
                        backgroundSearcher.Extensions.Add(ext);
                    }
                }
                if(checkboxVideos.Checked) {
                    foreach(string ext in Settings.Default.ExtensionsVideos) {
                        backgroundSearcher.Extensions.Add(ext);
                    }
                }
                if(checkboxCustomTypes.Checked) {
                    foreach(string ext in Settings.Default.ExtensionsCustom) {
                        backgroundSearcher.Extensions.Add(ext);
                    }
                }
            }

            backgroundSearcher.IncludeHiddenFiles = checkboxHiddenFiles.Checked;
            backgroundSearcher.IncludeSystemFiles = checkboxSystemFiles.Checked;
            if(checkboxMatchRegex.Checked) backgroundSearcher.FileNameRegex = new System.Text.RegularExpressions.Regex(textboxMatchRegex.Text);
        }

        /// <summary>
        /// Disposes any active FileSystemWatchers and creates new FileSystemWatchers according to the folders that were added to the search.
        /// </summary>
        private void InitializeFileSystemWatchers() {
            foreach(FileSystemWatcher watcher in fileSystemWatchers) {
                watcher.Dispose();
            }
            fileSystemWatchers.Clear();

            foreach(FolderItem folder in listboxFoldersAdded.Items) {
                FileSystemWatcher fileWatcher = CreateFileSystemWatcher(folder.Node.Path, false);
                fileWatcher.Changed += new FileSystemEventHandler(onFileWatcherChanged);
                fileWatcher.Created += new FileSystemEventHandler(onFileWatcherChanged);
                fileWatcher.Deleted += new FileSystemEventHandler(onFileWatcherChanged);
                fileWatcher.Renamed += new RenamedEventHandler(onFileWatcherRenamed);
                fileSystemWatchers.Add(fileWatcher);

                FileSystemWatcher dirWatcher = CreateFileSystemWatcher(folder.Node.Path, true);
                dirWatcher.Changed += new FileSystemEventHandler(onDirWatcherChanged);
                dirWatcher.Created += new FileSystemEventHandler(onDirWatcherChanged);
                dirWatcher.Deleted += new FileSystemEventHandler(onDirWatcherChanged);
                dirWatcher.Renamed += new RenamedEventHandler(onDirWatcherRenamed);
                fileSystemWatchers.Add(dirWatcher);

                FileSystemWatcher parentWatcher = CreateParentWatcher(folder.Node.Path);
                if(parentWatcher != null) {
                    parentWatcher.Changed += new FileSystemEventHandler(onDirWatcherChanged);
                    parentWatcher.Created += new FileSystemEventHandler(onDirWatcherChanged);
                    parentWatcher.Deleted += new FileSystemEventHandler(onDirWatcherChanged);
                    parentWatcher.Renamed += new RenamedEventHandler(onDirWatcherRenamed);
                    fileSystemWatchers.Add(parentWatcher);
                }
            }
        }

        private void onFileWatcherChanged(object sender, FileSystemEventArgs e) {
            // Update groups and table when a file has been deleted
            if(e.ChangeType == WatcherChangeTypes.Deleted) {
                // Handle file deletion
                lock(_resultsTableLocker) {
                    ResultsTableViewEntry entry = SearchEntryByFileName(e.FullPath);
                    if(entry != null) {
                        RemoveGroupEntry(entry);
                    }
                }

                lock(_resultsTreeLocker) {
                    ResultsTreeViewNode node = treeViewResults.GetNodeByPath(e.FullPath);
                    if(node != null) {
                        treeViewResults.Invoke((MethodInvoker)delegate {
                            TreeNode parent = node.Parent;
                            node.Remove();
                            treeViewResults.UpdateAllParents(parent, true, true, false);
                        });
                    }
                }
            }
        }

        private void onFileWatcherRenamed(object sender, RenamedEventArgs e) {
            // Update entry and header when a file has been renamed
            lock(_resultsTableLocker) {
                ResultsTableViewEntry entry = SearchEntryByFileName(e.OldFullPath);
                if(entry != null) {
                    // Path.GetFileName necessary because FileSystemWatcher uses names relative to its own root directory
                    entry.Cells[(int)GridColumnIndices.Name].Value = Path.GetFileName(e.FullPath);
                    entry.FileAssociated = new FileInfoWrapper(new FileInfo(e.FullPath));
                    entry.ContainerGroup.Header.Cells[(int)GridColumnIndices.Name].Value = BuildHeaderName(entry.ContainerGroup.GetFilesAssociated());
                }
            }

            lock(_resultsTreeLocker) {
                ResultsTreeViewNode node = treeViewResults.GetNodeByPath(e.OldFullPath);
                if(node != null) {
                    treeViewResults.Invoke((MethodInvoker)delegate {
                        if(node is ResultsTreeViewFileNode) {
                            node.Name = Path.GetFileName(e.FullPath);
                            node.Text = node.Name;
                            int iconIndex = treeViewResults.IconManager.AddFileIcon(e.FullPath);
                            node.ImageIndex = iconIndex;
                            node.SelectedImageIndex = iconIndex;
                        }
                    });
                }
            }
        }

        void onDirWatcherChanged(object sender, FileSystemEventArgs e) {
            // Update groups and table for all affected files when a directory has been deleted
            if(e.ChangeType == WatcherChangeTypes.Deleted) {
                lock(_resultsTableLocker) {
                    IList<ResultsTableViewEntry> entries = SearchEntriesByDirectoryName(e.FullPath, true);
                    foreach(ResultsTableViewEntry entry in entries) {
                        RemoveGroupEntry(entry);
                    }
                }

                lock(_resultsTreeLocker) {
                    ResultsTreeViewNode node = treeViewResults.GetNodeByPath(e.FullPath);
                    if(node != null) {
                        treeViewResults.Invoke((MethodInvoker)delegate {
                            TreeNode parent = node.Parent;
                            node.Remove();
                            treeViewResults.UpdateAllParents(parent, false, false);
                        });
                    }
                }
            }
        }

        void onDirWatcherRenamed(object sender, RenamedEventArgs e) {
            // Update entries for all affected files when a directory has been renamed
            lock(_resultsTableLocker) {
                IList<ResultsTableViewEntry> entries = SearchEntriesByDirectoryName(e.OldFullPath, true);
                foreach(ResultsTableViewEntry entry in entries) {
                    DataGridViewCell pathCell = entry.Cells[(int)GridColumnIndices.Path];
                    pathCell.Value = ((string)pathCell.Value).Replace(e.OldFullPath, e.FullPath);
                    entry.FileAssociated = new FileInfoWrapper(new FileInfo(entry.FileAssociated.File.FullName.Replace(e.OldFullPath, e.FullPath)));
                }
            }

            lock(_resultsTreeLocker) {
                ResultsTreeViewDirectoryNode node = treeViewResults.GetNodeByPath(e.OldFullPath) as ResultsTreeViewDirectoryNode;
                if(node != null) {
                    treeViewResults.Invoke((MethodInvoker)delegate {
                        if(node.Parent == null) {
                            // Node is a root node in the tree view
                            node.Name = e.FullPath;
                        }
                        else {
                            // Node is not a root node
                            node.Name = Path.GetFileName(e.FullPath);
                        }
                        treeViewResults.UpdateChildrenFiles(node, e.OldFullPath, e.FullPath);
                        node.UpdateText();
                    });
                }
            }
        }

        /// <summary>
        /// Searches the Results Table for an entry that has a specific file associated.
        /// </summary>
        /// <param name="fullName">the full name of the file</param>
        /// <returns>the corresponding entry or null, if no entry has the specified file associated</returns>
        private ResultsTableViewEntry SearchEntryByFileName(string fullName) {
            foreach(ResultsGroup group in tableViewResults.GetGroups()) {
                foreach(ResultsTableViewEntry entry in group.Entries) {
                    if(entry.FileAssociated.File.FullName.Equals(fullName)) {
                        return entry;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Searches the Results Table for entries that have files associated that are within the specified directory.
        /// </summary>
        /// <param name="fullName">the full name of the directory</param>
        /// <param name="includeSubdirectories">specifies whether to search subdirectories, too</param>
        /// <returns>a list of entries that were found (empty list if none were found)</returns>
        private IList<ResultsTableViewEntry> SearchEntriesByDirectoryName(string fullName, bool includeSubdirectories) {
            string startString = fullName + "\\";
            IList<ResultsTableViewEntry> ret = new List<ResultsTableViewEntry>();
            foreach(ResultsGroup group in tableViewResults.GetGroups()) {
                foreach(ResultsTableViewEntry entry in group.Entries) {
                    if(includeSubdirectories) {
                        if(entry.FileAssociated.File.FullName.StartsWith(startString)) {
                            ret.Add(entry);
                        }
                    }
                    else {
                        if(entry.FileAssociated.File.DirectoryName == fullName) {
                            ret.Add(entry);
                        }
                    }
                }
            }
            return ret;
        }

        private void RemoveGroupEntry(ResultsTableViewEntry entry) {
            // Remove the entry from the table if the group is expanded
            if(entry.ContainerGroup.Expanded) {
                if(tableViewResults.InvokeRequired) {
                    tableViewResults.Invoke((MethodInvoker)delegate {
                        try {
                            tableViewResults.Rows.Remove(entry);
                        }
                        catch(ArgumentException) { }
                    });
                }
                else {
                    try {
                        tableViewResults.Rows.Remove(entry);
                    }
                    catch(ArgumentException) { }
                }
            }
            // Remove the entry from the ResultsGroup
            entry.ContainerGroup.Entries.Remove(entry);
            // If the group is empty or has one entry and is allowed to be removed, remove it. Otherwise just update the group header.
            if(entry.ContainerGroup.Entries.Count < 1 || entry.ContainerGroup.Entries.Count < 2 && Settings.Default.RemoveGroupsWithOneEntry) {
                if(tableViewResults.InvokeRequired) {
                    tableViewResults.Invoke((MethodInvoker)delegate {
                        tableViewResults.RemoveGroup(entry.ContainerGroup);
                    });
                }
                else {
                    tableViewResults.RemoveGroup(entry.ContainerGroup);
                }
            }
            else {
                entry.ContainerGroup.Header.Cells[(int)GridColumnIndices.Name].Value = BuildHeaderName(entry.ContainerGroup.GetFilesAssociated());
            }
        }

        private FileSystemWatcher CreateFileSystemWatcher(string path, bool isDirectoryWatcher, bool activate = true) {
            FileSystemWatcher ret = new FileSystemWatcher(path);
            ret.IncludeSubdirectories = true;
            ret.NotifyFilter = isDirectoryWatcher ? NotifyFilters.DirectoryName : NotifyFilters.FileName;
            ret.InternalBufferSize = isDirectoryWatcher ? 8192 : 32768;
            ret.EnableRaisingEvents = activate;
            return ret;
        }

        private FileSystemWatcher CreateParentWatcher(string path, bool activate = true) {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if(dirInfo.Parent != null) {
                FileSystemWatcher ret = new FileSystemWatcher(dirInfo.Parent.FullName);
                ret.IncludeSubdirectories = false;
                ret.NotifyFilter = NotifyFilters.DirectoryName;
                ret.Filter = dirInfo.Name;
                ret.EnableRaisingEvents = activate;
                return ret;
            }
            return null;
        }

        private void onButtonMinimizeClick(object sender, EventArgs e) {
            nofityIconMinimized.Visible = true;
            Hide();
            ShowInTaskbar = false;
            MinimizedToSystemTray = true;

            // If minimize is pressed for the first time, show an info balloon
            if(showMinimizedInfo) {
                nofityIconMinimized.ShowBalloonTip(6000, Strings.WorkingInBackgroundBalloonTitle, Strings.WorkingInBackgroundBalloonText, ToolTipIcon.Info);
                showMinimizedInfo = false;
            }
        }

        private void onNofityIconMinimizedClick(object sender, EventArgs e) {
            ResurrectWindow();
        }

        private void onNotifyIconMinimizedBalloonTipClicked(object sender, EventArgs e) {
            if(backgroundSearcher != null && backgroundSearcher.State == Util.SearchState.Finished) {
                ResurrectWindow();
            }
        }

        private void ResurrectWindow() {
            nofityIconMinimized.Visible = false;
            ShowInTaskbar = true;
            Show();
            MinimizedToSystemTray = false;

            if(backgroundSearcher.State != Util.SearchState.Finished && TaskbarManager.IsPlatformSupported) {
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                TaskbarManager.Instance.SetProgressValue(backgroundSearcher.CurrentProgress, 100, Handle);
            }
        }

        private void onPictureBoxListViewClick(object sender, EventArgs e) {
            SwitchPanel(panelListView);
        }

        private void onPictureBoxTreeViewClick(object sender, EventArgs e) {
            SwitchPanel(panelTreeView);
        }

        private void SwitchPanel(Panel newPanel) {
            if(activePanel != newPanel) {
                activePanel.Visible = false;
                activePanel = newPanel;
                activePanel.Visible = true;
            }
        }
        #endregion

        #region results table events
        private void onTableViewResultsCellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {
            // Select row on right-click before context menu is shown
            if(e.Button == MouseButtons.Right && e.RowIndex != -1 && !tableViewResults.Rows[e.RowIndex].Selected) {
                tableViewResults.ClearSelection();
                tableViewResults.Rows[e.RowIndex].Selected = true;
            }
        }

        private void onTableViewResultsCellClick(object sender, DataGridViewCellEventArgs e) {
            // Expand/Collapse group if the icon is clicked
            if(e.RowIndex != -1 && e.ColumnIndex == 0 && tableViewResults.Rows[e.RowIndex] is ResultsTableViewHeader) {
                ResultsTableViewHeader header = tableViewResults.Rows[e.RowIndex] as ResultsTableViewHeader;
                ToggleExpandState(header.ContainerGroup);
            }
        }

        private void onTableViewResultsCellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // Expand/Collapse if a header is double-clicked (but not the icon). Open the associated file if an entry is double-clicked.
            if(e.RowIndex != -1 && e.ColumnIndex > 0) {
                if(tableViewResults.Rows[e.RowIndex] is ResultsTableViewHeader) {
                    ResultsTableViewHeader header = tableViewResults.Rows[e.RowIndex] as ResultsTableViewHeader;
                    ToggleExpandState(header.ContainerGroup);
                }
                else if(tableViewResults.Rows[e.RowIndex] is IFileAssociated) {
                    IFileAssociated entry = tableViewResults.Rows[e.RowIndex] as IFileAssociated;
                    OpenFileDefaultProgram(entry.FileAssociated.File.FullName);
                }
            }
        }

        /// <summary>
        /// Opens a file in a new process. Displays an error message if an error occurred.
        /// </summary>
        /// <param name="fullName">the full name of the file</param>
        private void OpenFileDefaultProgram(string fullName) {
            try {
                System.Diagnostics.Process.Start(fullName);
            }
            catch(Win32Exception e) {
                MessageBox.Show(String.Format(Strings.ErrorUnableToStartProcessText, fullName, e.Message), Strings.ErrorUnableToStartProcessCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Toggles a group's expanded/collapsed state.
        /// </summary>
        /// <param name="group">the group to be expanded/collapsed</param>
        private void ToggleExpandState(ResultsGroup group) {
            lock(_resultsTableLocker) {
                if(group.Expanded) {
                    tableViewResults.CollapseGroup(group);
                    group.Header.Cells[(int)GridColumnIndices.Expand].Value = Resources.IconExpand;
                }
                else {
                    tableViewResults.ExpandGroup(group);
                    group.Header.Cells[(int)GridColumnIndices.Expand].Value = Resources.IconCollapse;
                }
            }
        }

        private void onTableViewResultsKeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                // If Enter was pressed and an entry is selected, open its associated file. If only headers are selected, toggle expand/collapse.
                if(tableViewResults.SelectedRows.Count == 1 && tableViewResults.SelectedRows[0] is IFileAssociated) {
                    IFileAssociated entry = tableViewResults.SelectedRows[0] as IFileAssociated;
                    OpenFileDefaultProgram(entry.FileAssociated.File.FullName);
                }
                else if(OnlyHeadersSelected()) {
                    foreach(ResultsTableViewHeader header in tableViewResults.SelectedRows) {
                        ToggleExpandState(header.ContainerGroup);
                    }
                }
                e.Handled = true; // Necessary so the cursor does not move to the next row.
            }
            else if(e.KeyCode == Keys.Delete) {
                // If Delete was pressed and only entries are selected, delete their associated files.
                if(OnlyEntriesSelected()) {
                    DeleteAssociatedFiles(tableViewResults.SelectedRows);
                }
            }
            else if(e.KeyCode == Keys.F2) {
                // If F2 was pressed and an entry is selected, open a renaming box to rename the associated file.
                if(tableViewResults.SelectedRows.Count == 1 && tableViewResults.SelectedRows[0] is ResultsTableViewEntry) {
                    BeginRenaming(tableViewResults.SelectedRows[0]);
                }
            }
        }

        private void BeginRenaming(DataGridViewRow row) {
            tableViewResults.CurrentCell = row.Cells[(int)GridColumnIndices.Name];
            tableViewResults.BeginEdit(true);
        }

        private void onTableViewResultsCellEndEdit(object sender, DataGridViewCellEventArgs e) {
            // Try to rename the associated file and update the entry accordingly.
            ResultsTableViewEntry row = tableViewResults.Rows[e.RowIndex] as ResultsTableViewEntry;
            if(row != null) {
                FileInfo file = row.FileAssociated.File;
                string newName = (string)row.Cells[(int)GridColumnIndices.Name].Value;

                if(newName == "") {
                    row.Cells[(int)GridColumnIndices.Name].Value = file.Name;
                    return;
                }

                bool success = RenameFile(file, newName);
                if(success) {
                    row.ContainerGroup.Header.Cells[(int)GridColumnIndices.Name].Value = BuildHeaderName(row.ContainerGroup.GetFilesAssociated());
                }
                else {
                    row.Cells[(int)GridColumnIndices.Name].Value = file.Name;
                }
            }
        }

        /// <summary>
        /// Tries to rename a file and displays an error message if an error occurred.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        private bool RenameFile(FileInfo file, string newName) {
            try {
                file.MoveTo(file.DirectoryName + "\\" + newName);
            }
            catch(Exception e) {
                MessageBox.Show(String.Format(Strings.ErrorUnableToRenameFileText, file.Name, e.Message), Strings.ErrorUnableToRenameFileCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void onContextMenuGroupEntryOpening(object sender, CancelEventArgs e) {
            // Set enabled states of context menu entries based on selected rows
            bool onlyEntriesSelected = OnlyEntriesSelected();
            contextMenuOpenWithDefaultProgram.Enabled = tableViewResults.SelectedRows.Count == 1;
            contextMenuRenameFile.Enabled = tableViewResults.SelectedRows.Count == 1;
            contextMenuDeleteFile.Enabled = onlyEntriesSelected;
            contextMenuShowInExplorerEntry.Enabled = onlyEntriesSelected;
            contextMenuShowAllInFolder.Enabled = tableViewResults.SelectedRows.Count == 1 && backgroundSearcher != null && (backgroundSearcher.State == Util.SearchState.Aborted || backgroundSearcher.State == Util.SearchState.Finished);
        }

        private void onContextMenuGroupHeaderOpening(object sender, CancelEventArgs e) {
            // Set enabled states of context menu entries based on selected rows
            bool onlyHeadersSelected = OnlyHeadersSelected();
            contextMenuExpandCollapse.Enabled = onlyHeadersSelected;
            contextMenuHide.Enabled = onlyHeadersSelected;
            contextMenuShowInExplorerHeader.Enabled = onlyHeadersSelected;
        }

        /// <summary>
        /// Checks if only headers are selected in the Results Table.
        /// </summary>
        /// <returns>true if only headers are selected, otherwise false</returns>
        private bool OnlyHeadersSelected() {
            foreach(ResultsTableViewRow row in tableViewResults.SelectedRows) {
                if(!(row is ResultsTableViewHeader)) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if only entries are selected in the Results Table.
        /// </summary>
        /// <returns>true if only entries are selected, otherwise false</returns>
        private bool OnlyEntriesSelected() {
            foreach(ResultsTableViewRow row in tableViewResults.SelectedRows) {
                if(!(row is ResultsTableViewEntry)) {
                    return false;
                }
            }
            return true;
        }

        private void onContextMenuOpenWithDefaultProgramClick(object sender, EventArgs e) {
            if(tableViewResults.SelectedRows.Count == 1 && tableViewResults.SelectedRows[0] is IFileAssociated) {
                IFileAssociated entry = tableViewResults.SelectedRows[0] as IFileAssociated;
                if(entry != null) {
                    OpenFileDefaultProgram(entry.FileAssociated.File.FullName);
                }
            }
        }

        private void onContextMenuRenameFileClick(object sender, EventArgs e) {
            if(tableViewResults.SelectedRows.Count == 1 &&  tableViewResults.SelectedRows[0] is ResultsTableViewEntry) {
                BeginRenaming(tableViewResults.SelectedRows[0]);
            }
        }

        private void onContextMenuDeleteFileClick(object sender, EventArgs e) {
            if(OnlyEntriesSelected()) {
                DeleteAssociatedFiles(tableViewResults.SelectedRows);
            }
        }

        /// <summary>
        /// Starts deleting the associated files for several entries.
        /// </summary>
        /// <param name="entries">the affected entries</param>
        /// <param name="confirm">true to ask the user for confirmation first, otherwise false</param>
        private void DeleteAssociatedFiles(System.Collections.IEnumerable entries, bool confirm = true) {
            if(!confirm || MessageBox.Show(Strings.ConfirmFileDeletionText, Strings.ConfirmFileDeletionCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                foreach(IFileAssociated entry in entries) {
                    Util.DeletionResult result = DeleteFile(entry.FileAssociated.File.FullName);
                    if(result == Util.DeletionResult.Aborted) {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Deletes a file by moving it to the recycle bin.
        /// </summary>
        /// <param name="fullFileName">the full name of the file</param>
        /// <returns>enum specifying the result of the deletion (success, canceled, aborted)</returns>
        private Util.DeletionResult DeleteFile(string fullFileName) {
            bool retryCurrent;

            do {
                retryCurrent = false;
                try {
                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(fullFileName, Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                }
                catch(OperationCanceledException) {
                    // TODO: logging
                    return Util.DeletionResult.Canceled;
                }
                catch(Exception e) {
                    DialogResult decision = MessageBox.Show(String.Format(Strings.ErrorUnableToDeleteFileText, fullFileName, e.Message), Strings.ErrorUnableToDeleteFileCaption, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if(decision == DialogResult.Abort) {
                        return Util.DeletionResult.Aborted;
                    }
                    else if(decision == DialogResult.Retry) {
                        retryCurrent = true;
                    }
                    else if(decision == DialogResult.Ignore) {
                        return Util.DeletionResult.Canceled;
                    }
                }
            }
            while(retryCurrent);

            return Util.DeletionResult.Success;
        }

        private void onContextMenuShowInExplorerEntryClick(object sender, EventArgs e) {
            if(OnlyEntriesSelected()) { // TODO: rethink counting entries / count different paths
                if(tableViewResults.SelectedRows.Count < 10 || MessageBox.Show(Strings.WarningManyFoldersOpeningText, Strings.WarningManyFoldersOpeningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    lock(_resultsTableLocker) {
                        IList<FileSystemInfo> files = new List<FileSystemInfo>();
                        foreach(IFileAssociated entry in tableViewResults.SelectedRows) {
                            files.Add(entry.FileAssociated.File);
                        }
                        try {
                            ShowSelectedInExplorer.FilesOrFolders(files);
                        }
                        catch(System.Runtime.InteropServices.COMException ex) {
                            MessageBox.Show(String.Format(Strings.ErrorUnableToOpenFolderAndSelectItemsText, ex.ErrorCode, ex.Message), Strings.ErrorUnableToOpenFolderAndSelectItemsCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void onContextMenuShowAllInFolderClick(object sender, EventArgs e) {
            // Open Windows Explorer and select all files in the folder that were found in the search
            if(tableViewResults.SelectedRows.Count == 1 && tableViewResults.SelectedRows[0] is ResultsTableViewEntry) {
                lock(_resultsTableLocker) {
                    ResultsTableViewEntry selected = tableViewResults.SelectedRows[0] as ResultsTableViewEntry;
                    IList<ResultsTableViewEntry> entries = SearchEntriesByDirectoryName(selected.FileAssociated.File.DirectoryName, false);
                    IList<FileSystemInfo> files = new List<FileSystemInfo>(entries.Count);
                    foreach(ResultsTableViewEntry entry in entries) {
                        files.Add(entry.FileAssociated.File);
                    }
                    try {
                        ShowSelectedInExplorer.FilesOrFolders(files);
                    }
                    catch(System.Runtime.InteropServices.COMException ex) {
                        MessageBox.Show(String.Format(Strings.ErrorUnableToOpenFolderAndSelectItemsText, ex.ErrorCode, ex.Message), Strings.ErrorUnableToOpenFolderAndSelectItemsCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void onContextMenuExpandCollapseClick(object sender, EventArgs e) {
            if(OnlyHeadersSelected()) {
                lock(_resultsTableLocker) {
                    foreach(ResultsTableViewHeader header in tableViewResults.SelectedRows) {
                        ToggleExpandState(header.ContainerGroup);
                    }
                }
            }
        }

        private void onContextMenuHideClick(object sender, EventArgs e) {
            if(OnlyHeadersSelected()) {
                lock(_resultsTableLocker) {
                    foreach(ResultsTableViewHeader header in tableViewResults.SelectedRows) {
                        tableViewResults.RemoveGroup(header.ContainerGroup);
                    }
                }
            }
        }

        private void onContextMenuShowInExplorerHeaderClick(object sender, EventArgs e) {
            if(OnlyHeadersSelected()) {
                int selectedEntries = 0;
                foreach(ResultsTableViewHeader header in tableViewResults.SelectedRows) {
                    selectedEntries += header.ContainerGroup.Entries.Count;
                } // TODO: rethink counting entries / count different paths
                if(selectedEntries < 10 || MessageBox.Show(Strings.WarningManyFoldersOpeningText, Strings.WarningManyFoldersOpeningCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    IList<FileSystemInfo> files = new List<FileSystemInfo>();
                    foreach(ResultsTableViewHeader header in tableViewResults.SelectedRows) {
                        foreach(ResultsTableViewEntry entry in header.ContainerGroup.Entries) {
                            files.Add(entry.FileAssociated.File);
                        }
                    }
                    try {
                        ShowSelectedInExplorer.FilesOrFolders(files);
                    }
                    catch(System.Runtime.InteropServices.COMException ex) {
                        MessageBox.Show(String.Format(Strings.ErrorUnableToOpenFolderAndSelectItemsText, ex.ErrorCode, ex.Message), Strings.ErrorUnableToOpenFolderAndSelectItemsCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region Tree Results
        private void onTreeViewResultsMouseDown(object sender, MouseEventArgs e) {
            // Select node on right-click before context menu is shown
            if(e.Button == MouseButtons.Right) {
            TreeNode nodeClicked = treeViewResults.GetNodeAt(e.X, e.Y);
            if(nodeClicked != null)
                treeViewResults.SelectedNode = nodeClicked;
            }
        }

        private void onTreeViewResultsNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            IFileAssociated entry = e.Node as IFileAssociated;
            if(entry != null) {
                OpenFileDefaultProgram(entry.FileAssociated.File.FullName);
            }
        }

        private void onContextMenuNodeOpenWithDefaultProgramClick(object sender, EventArgs e) {
            IFileAssociated entry = treeViewResults.SelectedNode as IFileAssociated;
            if(entry != null) {
                OpenFileDefaultProgram(entry.FileAssociated.File.FullName);
            }
        }

        private void onContextMenuNodeRenameFileClick(object sender, EventArgs e) {
            if(treeViewResults.SelectedNode is ResultsTreeViewFileNode) {
                treeViewResults.SelectedNode.BeginEdit();
            }
        }

        private void onTreeViewResultsAfterLabelEdit(object sender, NodeLabelEditEventArgs e) {
            // Try to rename the associated file and update the node accordingly.
            ResultsTreeViewFileNode node = e.Node as ResultsTreeViewFileNode;
            if(node != null) {
                FileInfo file = node.FileAssociated.File;

                if(e.Label == null || e.Label.Equals("")) {
                    node.Text = file.Name;
                    return;
                }

                bool success = RenameFile(file, e.Label);
                if(!success) {
                    node.Text = file.Name;
                }
            }
        }

        private void onContextMenuNodeDeleteFileClick(object sender, EventArgs e) {
            if(MessageBox.Show(Strings.ConfirmFileDeletionText, Strings.ConfirmFileDeletionCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                IFileAssociated node = treeViewResults.SelectedNode as IFileAssociated;
                if(node != null) {
                    DeleteFile(node.FileAssociated.File.FullName);
                }
            }
        }

        private void onContextMenuNodeShowInExplorerClick(object sender, EventArgs e) {
            IFileAssociated node = treeViewResults.SelectedNode as IFileAssociated;
            if(node != null) {
                try {
                    ShowSelectedInExplorer.FileOrFolder(node.FileAssociated.File.FullName);
                }
                catch(System.Runtime.InteropServices.COMException ex) {
                    MessageBox.Show(String.Format(Strings.ErrorUnableToOpenFolderAndSelectItemsText, ex.ErrorCode, ex.Message), Strings.ErrorUnableToOpenFolderAndSelectItemsCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void onContextMenuNodeDirShowInExplorerClick(object sender, EventArgs e) {
            ResultsTreeViewDirectoryNode node = treeViewResults.SelectedNode as ResultsTreeViewDirectoryNode;
            if(node != null) {
                IList<FileSystemInfo> files = new List<FileSystemInfo>(node.Nodes.Count);
                foreach(TreeNode subNode in node.Nodes) {
                    if(subNode is IFileAssociated) {
                        files.Add((subNode as IFileAssociated).FileAssociated.File);
                    }
                }
                try {
                    ShowSelectedInExplorer.FilesOrFolders(files);
                }
                catch(System.Runtime.InteropServices.COMException ex) {
                    MessageBox.Show(String.Format(Strings.ErrorUnableToOpenFolderAndSelectItemsText, ex.ErrorCode, ex.Message), Strings.ErrorUnableToOpenFolderAndSelectItemsCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void onTreeViewResultsKeyDown(object sender, KeyEventArgs e) {
            IFileAssociated fileNode = treeViewResults.SelectedNode as IFileAssociated;
            if(e.KeyCode == Keys.Enter) {
                // If Enter was pressed and a file node is selected, open its associated file. If a directory node is selected, toggle collapse/expand.
                if(fileNode != null) {
                    OpenFileDefaultProgram(fileNode.FileAssociated.File.FullName);
                }
                else if(treeViewResults.SelectedNode is ResultsTreeViewDirectoryNode) {
                    treeViewResults.SelectedNode.Toggle();
                }
            }
            else if(e.KeyCode == Keys.Delete) {
                // If Delete was pressed and a file node is selected, delete its associated file.
                if(fileNode != null) {
                    DeleteFile(fileNode.FileAssociated.File.FullName);
                }
            }
            else if(e.KeyCode == Keys.F2) {
                // If F2 was pressed and a file node is selected, open a renaming box to rename the associated file.
                if(treeViewResults.SelectedNode is ResultsTreeViewFileNode) {
                    treeViewResults.SelectedNode.BeginEdit();
                }
            }
        }

        private void onTreeViewResultsKeyPress(object sender, KeyPressEventArgs e) {
            if(e.KeyChar == '\n' || e.KeyChar == '\r') {
                e.Handled = true; // Necessary to prevent the 'ding' sound from Windows when pressing Enter
            }
        }
        #endregion

        #region after search
        internal void SearchPostProcessing(SearchResult result) {
            // TODO: logging

            if(!result.WasCanceled) {
                SetSearchControlStates(Util.StateChange.Complete);
            }
            lock(_labelLocker) {
                labelFilesScanned.Text = String.Format(Strings.SearchXFilesScanned, result.FilesScanned);
                labelCurrentFolder.Text = String.Format(Strings.SearchXShadowsFound, result.AllShadows.Count);
            }
            if(MinimizedToSystemTray) {
                nofityIconMinimized.ShowBalloonTip(6000, Strings.SearchCompletedBalloonTitle, String.Format(Strings.SearchCompletedBalloonText, result.AllShadows.Count), ToolTipIcon.Info);
            }
        }
        #endregion

        /// <summary>
        /// Adds a new group of duplicate files to the Results Table in a thread-safe manner.
        /// </summary>
        /// <param name="shadowSet">the IList of duplicate files</param>
        internal void AddShadowThreadSafe(IList<FileInfoWrapper> shadowSet) {
            tableViewResults.BeginInvoke((MethodInvoker)delegate {
                lock(_resultsTableLocker) {
                    ResultsTableViewHeader header = CreateGroupHeader(shadowSet, tableViewResults, Settings.Default.ResultsInitiallyExpanded);
                    IList<ResultsTableViewEntry> entries = CreateGroupEntries(shadowSet, tableViewResults);
                    tableViewResults.AddGroup(new ResultsGroup(header, entries), Settings.Default.ResultsInitiallyExpanded);
                }
            });

            treeViewResults.BeginInvoke((MethodInvoker)delegate {
                lock(_resultsTreeLocker) {
                    treeViewResults.AddShadow(shadowSet);
                }
            });
        }

        /// <summary>
        /// Builds the group header based on the contents of the group and the search settings.
        /// </summary>
        /// <param name="shadowSet">the files in the group</param>
        /// <param name="table">the table where the header will be displayed</param>
        /// <param name="expanded">true if the group will be expanded, false otherwise</param>
        /// <returns>the header created</returns>
        private ResultsTableViewHeader CreateGroupHeader(IList<FileInfoWrapper> shadowSet, DataGridView table, bool expanded) {
            ResultsTableViewHeader ret = new ResultsTableViewHeader();

            string name = BuildHeaderName(shadowSet);

            string size;
            if(backgroundSearcher.CompareFileSize) {
                size = Util.HumanReadableSize(shadowSet[0].File.Length);
            }
            else {
                size = "";
            }

            ret.CreateCells(table);
            ret.Cells[(int)GridColumnIndices.Expand].Value = expanded ? Resources.IconCollapse : Resources.IconExpand;
            ret.Cells[(int)GridColumnIndices.Name].Value = name;
            ret.Cells[(int)GridColumnIndices.Path].Value = "";
            ret.Cells[(int)GridColumnIndices.Size].Value = size;
            ret.Cells[(int)GridColumnIndices.ModDate].Value = "";
            ret.Cells[(int)GridColumnIndices.Type].Value = "";

            ret.ContextMenuStrip = contextMenuGroupHeader;
            ret.DefaultCellStyle.BackColor = SystemColors.ControlLight;

            return ret;
        }

        /// <summary>
        /// Builds the name of the group header based on the contents of the group and the search settings.
        /// </summary>
        /// <param name="shadowSet">the files in the group</param>
        /// <returns>the header name</returns>
        private string BuildHeaderName(IList<FileInfoWrapper> shadowSet) {
            string ret;
            if(backgroundSearcher.CompareFileName) {
                ret = shadowSet[0].File.Name;
                if(!backgroundSearcher.CompareFileExtension) {
                    ret = ret.Substring(0, ret.Length - shadowSet[0].File.Extension.Length);
                }
            }
            else {
                StringBuilder nameBuilder = new StringBuilder();
                foreach(FileInfoWrapper file in shadowSet) {
                    nameBuilder.AppendFormat("{0}{1}", file.File.Name, Settings.Default.ResultsFileNameSeparator);
                }
                if(nameBuilder.Length < Settings.Default.ResultsFileNameSeparator.Length) {
                    ret = "";
                }
                else {
                    ret = nameBuilder.ToString(0, nameBuilder.Length - Settings.Default.ResultsFileNameSeparator.Length);
                }
            }
            return ret;
        }

        /// <summary>
        /// Creates group entries for each file of a group.
        /// </summary>
        /// <param name="shadowSet">the files in the group</param>
        /// <param name="table">the table where the entries will be displayed</param>
        /// <returns>IList containing the created entries</returns>
        private IList<ResultsTableViewEntry> CreateGroupEntries(IList<FileInfoWrapper> shadowSet, DataGridView table) {
            IList<ResultsTableViewEntry> ret = new List<ResultsTableViewEntry>(shadowSet.Count);
            foreach(FileInfoWrapper file in shadowSet) {
                ret.Add(CreateGroupEntry(file, table));
            }
            return ret;
        }

        /// <summary>
        /// Creates a single group entry.
        /// </summary>
        /// <param name="file">the file for which the group entry shall be created</param>
        /// <param name="table">the table where the entry will be displayed</param>
        /// <returns>the constructed entry</returns>
        private ResultsTableViewEntry CreateGroupEntry(FileInfoWrapper file, DataGridView table) {
            ResultsTableViewEntry ret = new ResultsTableViewEntry(file);

            ret.CreateCells(table);
            ret.Cells[(int)GridColumnIndices.Name].Value = file.File.Name;
            ret.Cells[(int)GridColumnIndices.Path].Value = file.File.DirectoryName;
            ret.Cells[(int)GridColumnIndices.Size].Value = Util.HumanReadableSize(file.File.Length);
            ret.Cells[(int)GridColumnIndices.ModDate].Value = file.File.LastWriteTime.ToString(Settings.Default.ResultsModificationDateFormat);
            ret.Cells[(int)GridColumnIndices.Type].Value = ""; // TODO: implement using SHGetFileInfo

            ret.ContextMenuStrip = contextMenuGroupEntry;

            return ret;
        }

        /// <summary>
        /// Sets the text of a label in a thread-safe manner.
        /// </summary>
        /// <param name="label">the label to be altered</param>
        /// <param name="newText">the new label text</param>
        internal void SetLabelTextThreadSafe(Label label, string newText) {
            label.Invoke((MethodInvoker)delegate {
                lock(_labelLocker) {
                    label.Text = newText;
                }
            });
        }

        /// <summary>
        /// Sets the text of a status label in a thread-safe manner.
        /// </summary>
        /// <param name="label">the status label to be altered</param>
        /// <param name="newText">the new label text</param>
        internal void SetLabelTextThreadSafe(ToolStripStatusLabel label, string newText) {
            label.Owner.Invoke((MethodInvoker)delegate {
                lock(_labelLocker) {
                    label.Text = newText;
                }
            });
        }

        internal bool MinimizedToSystemTray {
            get { return _MinimizedToSystemTray; }
            set { _MinimizedToSystemTray = value; }
        }

        internal Label StatusLabel {
            get { return labelStatus; }
        }

        internal Label ProgressLabel {
            get { return labelProgress; }
        }

        internal Label FilesScannedLabel {
            get { return labelFilesScanned; }
        }

        internal Label CurrentFolderLabel {
            get { return labelCurrentFolder; }
        }

        internal ToolStripStatusLabel InfoLabel {
            get { return statusLabelInfos; }
        }

        internal ToolStripProgressBar ProgressBar {
            get { return progressBarSearchProgress; }
        }

        internal NotifyIcon NotifyIcon {
            get { return nofityIconMinimized; }
        }
    }
}
