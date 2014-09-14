namespace Shadows {
    partial class Main {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitAll = new System.Windows.Forms.SplitContainer();
            this.splitTop = new System.Windows.Forms.SplitContainer();
            this.groupFolders = new System.Windows.Forms.GroupBox();
            this.splitFolderSelection = new System.Windows.Forms.SplitContainer();
            this.expTreeFolders = new ExpTreeLib.ExpTree();
            this.contextMenuFolderTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextItemShowHiddenFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextItemRefreshTree = new System.Windows.Forms.ToolStripMenuItem();
            this.splitFoldersAdded = new System.Windows.Forms.SplitContainer();
            this.buttonAddFolder = new System.Windows.Forms.Button();
            this.buttonRemoveFolder = new System.Windows.Forms.Button();
            this.listboxFoldersAdded = new ShadowsLib.FolderListView();
            this.contextMenuAddedFolders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextItemSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.contextItemSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.contextItemInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageComparisonCriteria = new System.Windows.Forms.TabPage();
            this.checkboxCompareFileName = new System.Windows.Forms.CheckBox();
            this.checkboxCaseSensitive = new System.Windows.Forms.CheckBox();
            this.checkboxFileExtension = new System.Windows.Forms.CheckBox();
            this.checkboxCompareFileSize = new System.Windows.Forms.CheckBox();
            this.checkboxCompareFileContents = new System.Windows.Forms.CheckBox();
            this.tabPageFileTypes = new System.Windows.Forms.TabPage();
            this.radiobuttonAllTypes = new System.Windows.Forms.RadioButton();
            this.radiobuttonExcludeTypes = new System.Windows.Forms.RadioButton();
            this.radiobuttonIncludeTypes = new System.Windows.Forms.RadioButton();
            this.checkboxImages = new System.Windows.Forms.CheckBox();
            this.checkboxMusic = new System.Windows.Forms.CheckBox();
            this.checkboxVideos = new System.Windows.Forms.CheckBox();
            this.checkboxCustomTypes = new System.Windows.Forms.CheckBox();
            this.textboxCustomTypes = new System.Windows.Forms.TextBox();
            this.tabPageAdvancedSettings = new System.Windows.Forms.TabPage();
            this.checkboxHiddenFiles = new System.Windows.Forms.CheckBox();
            this.checkboxSystemFiles = new System.Windows.Forms.CheckBox();
            this.checkboxMatchRegex = new System.Windows.Forms.CheckBox();
            this.textboxMatchRegex = new System.Windows.Forms.TextBox();
            this.splitBottom = new System.Windows.Forms.SplitContainer();
            this.pictureBoxTreeView = new System.Windows.Forms.PictureBox();
            this.pictureBoxListView = new System.Windows.Forms.PictureBox();
            this.buttonStartSearch = new System.Windows.Forms.Button();
            this.buttonStopSearch = new System.Windows.Forms.Button();
            this.buttonPauseSearch = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.labelFilesScanned = new System.Windows.Forms.Label();
            this.labelCurrentFolder = new System.Windows.Forms.Label();
            this.groupResults = new System.Windows.Forms.GroupBox();
            this.panelListView = new System.Windows.Forms.Panel();
            this.splitTable = new System.Windows.Forms.SplitContainer();
            this.tableViewResults = new ShadowsLib.ResultsTableView();
            this.gridcolumnExpand = new System.Windows.Forms.DataGridViewImageColumn();
            this.gridcolumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridcolumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridcolumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridcolumnModDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridcolumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTreeView = new System.Windows.Forms.Panel();
            this.splitTreeview = new System.Windows.Forms.SplitContainer();
            this.treeViewResults = new ShadowsLib.ResultsTreeView();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemResetWindowSize = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency0 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency10 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency20 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency30 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency40 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency50 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency60 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency70 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency80 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTransparency90 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogging = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemActivateLogging = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogLevelFatal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogLevelError = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogLevelWarning = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLogLevelInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemOpenLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExtras = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEmptyFoldersTool = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGettingStarted = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAboutShadows = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarBottom = new System.Windows.Forms.StatusStrip();
            this.statuslabelProgramName = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarSearchProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.statusLabelInfos = new System.Windows.Forms.ToolStripStatusLabel();
            this.tooltipDefault = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuGroupEntry = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuOpenWithDefaultProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRenameFile = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuShowInTreeView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuShowInExplorerEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuShowAllInFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuGroupHeader = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuExpandCollapse = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuShowInExplorerHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuDirectoryNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuNodeDirShowInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFileNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuNodeOpenWithDefaultProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuNodeRenameFile = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuNodeDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuNodeShowInTableView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuNodeShowInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIconMinimized = new System.Windows.Forms.NotifyIcon(this.components);
            this.splitAll.Panel1.SuspendLayout();
            this.splitAll.Panel2.SuspendLayout();
            this.splitAll.SuspendLayout();
            this.splitTop.Panel1.SuspendLayout();
            this.splitTop.Panel2.SuspendLayout();
            this.splitTop.SuspendLayout();
            this.groupFolders.SuspendLayout();
            this.splitFolderSelection.Panel1.SuspendLayout();
            this.splitFolderSelection.Panel2.SuspendLayout();
            this.splitFolderSelection.SuspendLayout();
            this.contextMenuFolderTree.SuspendLayout();
            this.splitFoldersAdded.Panel1.SuspendLayout();
            this.splitFoldersAdded.Panel2.SuspendLayout();
            this.splitFoldersAdded.SuspendLayout();
            this.contextMenuAddedFolders.SuspendLayout();
            this.groupSettings.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPageComparisonCriteria.SuspendLayout();
            this.tabPageFileTypes.SuspendLayout();
            this.tabPageAdvancedSettings.SuspendLayout();
            this.splitBottom.Panel1.SuspendLayout();
            this.splitBottom.Panel2.SuspendLayout();
            this.splitBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxListView)).BeginInit();
            this.groupResults.SuspendLayout();
            this.panelListView.SuspendLayout();
            this.splitTable.Panel1.SuspendLayout();
            this.splitTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableViewResults)).BeginInit();
            this.panelTreeView.SuspendLayout();
            this.splitTreeview.Panel1.SuspendLayout();
            this.splitTreeview.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.statusBarBottom.SuspendLayout();
            this.contextMenuGroupEntry.SuspendLayout();
            this.contextMenuGroupHeader.SuspendLayout();
            this.contextMenuDirectoryNode.SuspendLayout();
            this.contextMenuFileNode.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitAll
            // 
            resources.ApplyResources(this.splitAll, "splitAll");
            this.splitAll.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitAll.Name = "splitAll";
            // 
            // splitAll.Panel1
            // 
            this.splitAll.Panel1.Controls.Add(this.splitTop);
            resources.ApplyResources(this.splitAll.Panel1, "splitAll.Panel1");
            // 
            // splitAll.Panel2
            // 
            this.splitAll.Panel2.Controls.Add(this.splitBottom);
            resources.ApplyResources(this.splitAll.Panel2, "splitAll.Panel2");
            // 
            // splitTop
            // 
            resources.ApplyResources(this.splitTop, "splitTop");
            this.splitTop.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitTop.Name = "splitTop";
            // 
            // splitTop.Panel1
            // 
            this.splitTop.Panel1.Controls.Add(this.groupFolders);
            resources.ApplyResources(this.splitTop.Panel1, "splitTop.Panel1");
            // 
            // splitTop.Panel2
            // 
            this.splitTop.Panel2.Controls.Add(this.groupSettings);
            resources.ApplyResources(this.splitTop.Panel2, "splitTop.Panel2");
            // 
            // groupFolders
            // 
            this.groupFolders.Controls.Add(this.splitFolderSelection);
            resources.ApplyResources(this.groupFolders, "groupFolders");
            this.groupFolders.Name = "groupFolders";
            this.groupFolders.TabStop = false;
            // 
            // splitFolderSelection
            // 
            resources.ApplyResources(this.splitFolderSelection, "splitFolderSelection");
            this.splitFolderSelection.Name = "splitFolderSelection";
            // 
            // splitFolderSelection.Panel1
            // 
            this.splitFolderSelection.Panel1.Controls.Add(this.expTreeFolders);
            // 
            // splitFolderSelection.Panel2
            // 
            this.splitFolderSelection.Panel2.Controls.Add(this.splitFoldersAdded);
            // 
            // expTreeFolders
            // 
            this.expTreeFolders.ContextMenuStrip = this.contextMenuFolderTree;
            this.expTreeFolders.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.expTreeFolders, "expTreeFolders");
            this.expTreeFolders.Name = "expTreeFolders";
            this.expTreeFolders.ShowHiddenFolders = false;
            this.expTreeFolders.ShowRootLines = false;
            // 
            // contextMenuFolderTree
            // 
            this.contextMenuFolderTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextItemShowHiddenFolders,
            this.toolStripMenuItem3,
            this.contextItemRefreshTree});
            this.contextMenuFolderTree.Name = "contextMenuFolderTree";
            resources.ApplyResources(this.contextMenuFolderTree, "contextMenuFolderTree");
            // 
            // contextItemShowHiddenFolders
            // 
            this.contextItemShowHiddenFolders.Name = "contextItemShowHiddenFolders";
            resources.ApplyResources(this.contextItemShowHiddenFolders, "contextItemShowHiddenFolders");
            this.contextItemShowHiddenFolders.Click += new System.EventHandler(this.onContextItemShowHiddenFoldersClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // contextItemRefreshTree
            // 
            this.contextItemRefreshTree.Name = "contextItemRefreshTree";
            resources.ApplyResources(this.contextItemRefreshTree, "contextItemRefreshTree");
            this.contextItemRefreshTree.Click += new System.EventHandler(this.onContextItemRefreshTreeClick);
            // 
            // splitFoldersAdded
            // 
            resources.ApplyResources(this.splitFoldersAdded, "splitFoldersAdded");
            this.splitFoldersAdded.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitFoldersAdded.Name = "splitFoldersAdded";
            // 
            // splitFoldersAdded.Panel1
            // 
            this.splitFoldersAdded.Panel1.Controls.Add(this.buttonAddFolder);
            this.splitFoldersAdded.Panel1.Controls.Add(this.buttonRemoveFolder);
            // 
            // splitFoldersAdded.Panel2
            // 
            this.splitFoldersAdded.Panel2.Controls.Add(this.listboxFoldersAdded);
            // 
            // buttonAddFolder
            // 
            resources.ApplyResources(this.buttonAddFolder, "buttonAddFolder");
            this.buttonAddFolder.Name = "buttonAddFolder";
            this.tooltipDefault.SetToolTip(this.buttonAddFolder, resources.GetString("buttonAddFolder.ToolTip"));
            this.buttonAddFolder.UseVisualStyleBackColor = true;
            this.buttonAddFolder.Click += new System.EventHandler(this.onButtonAddFolderClick);
            // 
            // buttonRemoveFolder
            // 
            resources.ApplyResources(this.buttonRemoveFolder, "buttonRemoveFolder");
            this.buttonRemoveFolder.Name = "buttonRemoveFolder";
            this.tooltipDefault.SetToolTip(this.buttonRemoveFolder, resources.GetString("buttonRemoveFolder.ToolTip"));
            this.buttonRemoveFolder.UseVisualStyleBackColor = true;
            this.buttonRemoveFolder.Click += new System.EventHandler(this.onButtonRemoveFolderClick);
            // 
            // listboxFoldersAdded
            // 
            this.listboxFoldersAdded.AllowDrop = true;
            this.listboxFoldersAdded.ContextMenuStrip = this.contextMenuAddedFolders;
            resources.ApplyResources(this.listboxFoldersAdded, "listboxFoldersAdded");
            this.listboxFoldersAdded.FormattingEnabled = true;
            this.listboxFoldersAdded.Name = "listboxFoldersAdded";
            this.listboxFoldersAdded.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listboxFoldersAdded.DragDrop += new System.Windows.Forms.DragEventHandler(this.onListboxFoldersAddedDragDrop);
            this.listboxFoldersAdded.DragEnter += new System.Windows.Forms.DragEventHandler(this.onListboxFoldersAddedDragEnter);
            this.listboxFoldersAdded.DragLeave += new System.EventHandler(this.onListboxFoldersAddedDragLeave);
            // 
            // contextMenuAddedFolders
            // 
            this.contextMenuAddedFolders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextItemSelectAll,
            this.contextItemSelectNone,
            this.contextItemInvertSelection});
            this.contextMenuAddedFolders.Name = "contextMenuAddedFolders";
            resources.ApplyResources(this.contextMenuAddedFolders, "contextMenuAddedFolders");
            // 
            // contextItemSelectAll
            // 
            this.contextItemSelectAll.Name = "contextItemSelectAll";
            resources.ApplyResources(this.contextItemSelectAll, "contextItemSelectAll");
            this.contextItemSelectAll.Click += new System.EventHandler(this.onContextItemSelectAllClick);
            // 
            // contextItemSelectNone
            // 
            this.contextItemSelectNone.Name = "contextItemSelectNone";
            resources.ApplyResources(this.contextItemSelectNone, "contextItemSelectNone");
            this.contextItemSelectNone.Click += new System.EventHandler(this.onContextItemSelectNoneClick);
            // 
            // contextItemInvertSelection
            // 
            this.contextItemInvertSelection.Name = "contextItemInvertSelection";
            resources.ApplyResources(this.contextItemInvertSelection, "contextItemInvertSelection");
            this.contextItemInvertSelection.Click += new System.EventHandler(this.onContextItemInvertSelectionClick);
            // 
            // groupSettings
            // 
            this.groupSettings.Controls.Add(this.tabControlSettings);
            resources.ApplyResources(this.groupSettings, "groupSettings");
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.TabStop = false;
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPageComparisonCriteria);
            this.tabControlSettings.Controls.Add(this.tabPageFileTypes);
            this.tabControlSettings.Controls.Add(this.tabPageAdvancedSettings);
            resources.ApplyResources(this.tabControlSettings, "tabControlSettings");
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            // 
            // tabPageComparisonCriteria
            // 
            this.tabPageComparisonCriteria.Controls.Add(this.checkboxCompareFileName);
            this.tabPageComparisonCriteria.Controls.Add(this.checkboxCaseSensitive);
            this.tabPageComparisonCriteria.Controls.Add(this.checkboxFileExtension);
            this.tabPageComparisonCriteria.Controls.Add(this.checkboxCompareFileSize);
            this.tabPageComparisonCriteria.Controls.Add(this.checkboxCompareFileContents);
            resources.ApplyResources(this.tabPageComparisonCriteria, "tabPageComparisonCriteria");
            this.tabPageComparisonCriteria.Name = "tabPageComparisonCriteria";
            this.tabPageComparisonCriteria.UseVisualStyleBackColor = true;
            // 
            // checkboxCompareFileName
            // 
            resources.ApplyResources(this.checkboxCompareFileName, "checkboxCompareFileName");
            this.checkboxCompareFileName.Checked = true;
            this.checkboxCompareFileName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxCompareFileName.Name = "checkboxCompareFileName";
            this.checkboxCompareFileName.UseVisualStyleBackColor = true;
            this.checkboxCompareFileName.CheckedChanged += new System.EventHandler(this.onCheckboxCompareFileNameCheckedChanged);
            // 
            // checkboxCaseSensitive
            // 
            resources.ApplyResources(this.checkboxCaseSensitive, "checkboxCaseSensitive");
            this.checkboxCaseSensitive.Name = "checkboxCaseSensitive";
            this.checkboxCaseSensitive.UseVisualStyleBackColor = true;
            this.checkboxCaseSensitive.CheckedChanged += new System.EventHandler(this.onCheckboxCaseSensitiveCheckedChanged);
            // 
            // checkboxFileExtension
            // 
            resources.ApplyResources(this.checkboxFileExtension, "checkboxFileExtension");
            this.checkboxFileExtension.Checked = true;
            this.checkboxFileExtension.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxFileExtension.Name = "checkboxFileExtension";
            this.checkboxFileExtension.UseVisualStyleBackColor = true;
            this.checkboxFileExtension.CheckedChanged += new System.EventHandler(this.onCheckboxFileExtensionCheckedChanged);
            // 
            // checkboxCompareFileSize
            // 
            resources.ApplyResources(this.checkboxCompareFileSize, "checkboxCompareFileSize");
            this.checkboxCompareFileSize.Checked = true;
            this.checkboxCompareFileSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxCompareFileSize.Name = "checkboxCompareFileSize";
            this.checkboxCompareFileSize.UseVisualStyleBackColor = true;
            this.checkboxCompareFileSize.CheckedChanged += new System.EventHandler(this.onCheckboxCompareFileSizeCheckedChanged);
            // 
            // checkboxCompareFileContents
            // 
            resources.ApplyResources(this.checkboxCompareFileContents, "checkboxCompareFileContents");
            this.checkboxCompareFileContents.Name = "checkboxCompareFileContents";
            this.checkboxCompareFileContents.UseVisualStyleBackColor = true;
            this.checkboxCompareFileContents.CheckedChanged += new System.EventHandler(this.onCheckboxCompareFileContentsCheckedChanged);
            // 
            // tabPageFileTypes
            // 
            this.tabPageFileTypes.Controls.Add(this.radiobuttonAllTypes);
            this.tabPageFileTypes.Controls.Add(this.radiobuttonExcludeTypes);
            this.tabPageFileTypes.Controls.Add(this.radiobuttonIncludeTypes);
            this.tabPageFileTypes.Controls.Add(this.checkboxImages);
            this.tabPageFileTypes.Controls.Add(this.checkboxMusic);
            this.tabPageFileTypes.Controls.Add(this.checkboxVideos);
            this.tabPageFileTypes.Controls.Add(this.checkboxCustomTypes);
            this.tabPageFileTypes.Controls.Add(this.textboxCustomTypes);
            resources.ApplyResources(this.tabPageFileTypes, "tabPageFileTypes");
            this.tabPageFileTypes.Name = "tabPageFileTypes";
            this.tabPageFileTypes.UseVisualStyleBackColor = true;
            // 
            // radiobuttonAllTypes
            // 
            resources.ApplyResources(this.radiobuttonAllTypes, "radiobuttonAllTypes");
            this.radiobuttonAllTypes.Checked = true;
            this.radiobuttonAllTypes.Name = "radiobuttonAllTypes";
            this.radiobuttonAllTypes.TabStop = true;
            this.tooltipDefault.SetToolTip(this.radiobuttonAllTypes, resources.GetString("radiobuttonAllTypes.ToolTip"));
            this.radiobuttonAllTypes.UseVisualStyleBackColor = true;
            this.radiobuttonAllTypes.CheckedChanged += new System.EventHandler(this.onRadiobuttonAllTypesCheckedChanged);
            // 
            // radiobuttonExcludeTypes
            // 
            resources.ApplyResources(this.radiobuttonExcludeTypes, "radiobuttonExcludeTypes");
            this.radiobuttonExcludeTypes.Name = "radiobuttonExcludeTypes";
            this.tooltipDefault.SetToolTip(this.radiobuttonExcludeTypes, resources.GetString("radiobuttonExcludeTypes.ToolTip"));
            this.radiobuttonExcludeTypes.UseVisualStyleBackColor = true;
            this.radiobuttonExcludeTypes.CheckedChanged += new System.EventHandler(this.onRadiobuttonExcludeTypesCheckedChanged);
            // 
            // radiobuttonIncludeTypes
            // 
            resources.ApplyResources(this.radiobuttonIncludeTypes, "radiobuttonIncludeTypes");
            this.radiobuttonIncludeTypes.Name = "radiobuttonIncludeTypes";
            this.tooltipDefault.SetToolTip(this.radiobuttonIncludeTypes, resources.GetString("radiobuttonIncludeTypes.ToolTip"));
            this.radiobuttonIncludeTypes.UseVisualStyleBackColor = true;
            this.radiobuttonIncludeTypes.CheckedChanged += new System.EventHandler(this.onRadiobuttonIncludeTypesCheckedChanged);
            // 
            // checkboxImages
            // 
            resources.ApplyResources(this.checkboxImages, "checkboxImages");
            this.checkboxImages.Name = "checkboxImages";
            this.checkboxImages.UseVisualStyleBackColor = true;
            this.checkboxImages.CheckedChanged += new System.EventHandler(this.onCheckboxImagesCheckedChanged);
            // 
            // checkboxMusic
            // 
            resources.ApplyResources(this.checkboxMusic, "checkboxMusic");
            this.checkboxMusic.Name = "checkboxMusic";
            this.checkboxMusic.UseVisualStyleBackColor = true;
            this.checkboxMusic.CheckedChanged += new System.EventHandler(this.onCheckboxMusicCheckedChanged);
            // 
            // checkboxVideos
            // 
            resources.ApplyResources(this.checkboxVideos, "checkboxVideos");
            this.checkboxVideos.Name = "checkboxVideos";
            this.checkboxVideos.UseVisualStyleBackColor = true;
            this.checkboxVideos.CheckedChanged += new System.EventHandler(this.onCheckboxVideosCheckedChanged);
            // 
            // checkboxCustomTypes
            // 
            resources.ApplyResources(this.checkboxCustomTypes, "checkboxCustomTypes");
            this.checkboxCustomTypes.Name = "checkboxCustomTypes";
            this.tooltipDefault.SetToolTip(this.checkboxCustomTypes, resources.GetString("checkboxCustomTypes.ToolTip"));
            this.checkboxCustomTypes.UseVisualStyleBackColor = true;
            this.checkboxCustomTypes.CheckedChanged += new System.EventHandler(this.onCheckboxCustomTypesCheckedChanged);
            // 
            // textboxCustomTypes
            // 
            resources.ApplyResources(this.textboxCustomTypes, "textboxCustomTypes");
            this.textboxCustomTypes.Name = "textboxCustomTypes";
            this.textboxCustomTypes.Leave += new System.EventHandler(this.onTextboxCustomTypesLeave);
            // 
            // tabPageAdvancedSettings
            // 
            this.tabPageAdvancedSettings.Controls.Add(this.checkboxHiddenFiles);
            this.tabPageAdvancedSettings.Controls.Add(this.checkboxSystemFiles);
            this.tabPageAdvancedSettings.Controls.Add(this.checkboxMatchRegex);
            this.tabPageAdvancedSettings.Controls.Add(this.textboxMatchRegex);
            resources.ApplyResources(this.tabPageAdvancedSettings, "tabPageAdvancedSettings");
            this.tabPageAdvancedSettings.Name = "tabPageAdvancedSettings";
            this.tabPageAdvancedSettings.UseVisualStyleBackColor = true;
            // 
            // checkboxHiddenFiles
            // 
            resources.ApplyResources(this.checkboxHiddenFiles, "checkboxHiddenFiles");
            this.checkboxHiddenFiles.Name = "checkboxHiddenFiles";
            this.checkboxHiddenFiles.UseVisualStyleBackColor = true;
            this.checkboxHiddenFiles.CheckedChanged += new System.EventHandler(this.onCheckboxHiddenFilesCheckedChanged);
            // 
            // checkboxSystemFiles
            // 
            resources.ApplyResources(this.checkboxSystemFiles, "checkboxSystemFiles");
            this.checkboxSystemFiles.Name = "checkboxSystemFiles";
            this.checkboxSystemFiles.UseVisualStyleBackColor = true;
            this.checkboxSystemFiles.CheckedChanged += new System.EventHandler(this.onCheckboxSystemFilesCheckedChanged);
            // 
            // checkboxMatchRegex
            // 
            resources.ApplyResources(this.checkboxMatchRegex, "checkboxMatchRegex");
            this.checkboxMatchRegex.Name = "checkboxMatchRegex";
            this.checkboxMatchRegex.UseVisualStyleBackColor = true;
            this.checkboxMatchRegex.CheckedChanged += new System.EventHandler(this.onCheckboxMatchRegexCheckedChanged);
            // 
            // textboxMatchRegex
            // 
            resources.ApplyResources(this.textboxMatchRegex, "textboxMatchRegex");
            this.textboxMatchRegex.Name = "textboxMatchRegex";
            this.textboxMatchRegex.Leave += new System.EventHandler(this.onTextboxMatchRegexLeave);
            // 
            // splitBottom
            // 
            resources.ApplyResources(this.splitBottom, "splitBottom");
            this.splitBottom.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitBottom.Name = "splitBottom";
            // 
            // splitBottom.Panel1
            // 
            this.splitBottom.Panel1.Controls.Add(this.pictureBoxTreeView);
            this.splitBottom.Panel1.Controls.Add(this.pictureBoxListView);
            this.splitBottom.Panel1.Controls.Add(this.buttonStartSearch);
            this.splitBottom.Panel1.Controls.Add(this.buttonStopSearch);
            this.splitBottom.Panel1.Controls.Add(this.buttonPauseSearch);
            this.splitBottom.Panel1.Controls.Add(this.buttonMinimize);
            this.splitBottom.Panel1.Controls.Add(this.labelStatus);
            this.splitBottom.Panel1.Controls.Add(this.labelProgress);
            this.splitBottom.Panel1.Controls.Add(this.labelFilesScanned);
            this.splitBottom.Panel1.Controls.Add(this.labelCurrentFolder);
            // 
            // splitBottom.Panel2
            // 
            this.splitBottom.Panel2.Controls.Add(this.groupResults);
            // 
            // pictureBoxTreeView
            // 
            resources.ApplyResources(this.pictureBoxTreeView, "pictureBoxTreeView");
            this.pictureBoxTreeView.Image = global::Shadows.Properties.Resources.IconTreeView;
            this.pictureBoxTreeView.Name = "pictureBoxTreeView";
            this.pictureBoxTreeView.TabStop = false;
            this.pictureBoxTreeView.Click += new System.EventHandler(this.onPictureBoxTreeViewClick);
            // 
            // pictureBoxListView
            // 
            resources.ApplyResources(this.pictureBoxListView, "pictureBoxListView");
            this.pictureBoxListView.Image = global::Shadows.Properties.Resources.IconListView;
            this.pictureBoxListView.Name = "pictureBoxListView";
            this.pictureBoxListView.TabStop = false;
            this.pictureBoxListView.Click += new System.EventHandler(this.onPictureBoxListViewClick);
            // 
            // buttonStartSearch
            // 
            resources.ApplyResources(this.buttonStartSearch, "buttonStartSearch");
            this.buttonStartSearch.Name = "buttonStartSearch";
            this.buttonStartSearch.UseVisualStyleBackColor = true;
            this.buttonStartSearch.Click += new System.EventHandler(this.onButtonStartSearchClick);
            // 
            // buttonStopSearch
            // 
            resources.ApplyResources(this.buttonStopSearch, "buttonStopSearch");
            this.buttonStopSearch.Name = "buttonStopSearch";
            this.buttonStopSearch.UseVisualStyleBackColor = true;
            this.buttonStopSearch.Click += new System.EventHandler(this.onButtonStopSearchClick);
            // 
            // buttonPauseSearch
            // 
            resources.ApplyResources(this.buttonPauseSearch, "buttonPauseSearch");
            this.buttonPauseSearch.Name = "buttonPauseSearch";
            this.buttonPauseSearch.UseVisualStyleBackColor = true;
            this.buttonPauseSearch.Click += new System.EventHandler(this.onButtonPauseSearchClick);
            // 
            // buttonMinimize
            // 
            resources.ApplyResources(this.buttonMinimize, "buttonMinimize");
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.onButtonMinimizeClick);
            // 
            // labelStatus
            // 
            resources.ApplyResources(this.labelStatus, "labelStatus");
            this.labelStatus.Name = "labelStatus";
            // 
            // labelProgress
            // 
            resources.ApplyResources(this.labelProgress, "labelProgress");
            this.labelProgress.Name = "labelProgress";
            // 
            // labelFilesScanned
            // 
            resources.ApplyResources(this.labelFilesScanned, "labelFilesScanned");
            this.labelFilesScanned.Name = "labelFilesScanned";
            // 
            // labelCurrentFolder
            // 
            resources.ApplyResources(this.labelCurrentFolder, "labelCurrentFolder");
            this.labelCurrentFolder.Name = "labelCurrentFolder";
            // 
            // groupResults
            // 
            this.groupResults.Controls.Add(this.panelListView);
            this.groupResults.Controls.Add(this.panelTreeView);
            resources.ApplyResources(this.groupResults, "groupResults");
            this.groupResults.Name = "groupResults";
            this.groupResults.TabStop = false;
            // 
            // panelListView
            // 
            this.panelListView.Controls.Add(this.splitTable);
            resources.ApplyResources(this.panelListView, "panelListView");
            this.panelListView.Name = "panelListView";
            // 
            // splitTable
            // 
            resources.ApplyResources(this.splitTable, "splitTable");
            this.splitTable.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitTable.Name = "splitTable";
            // 
            // splitTable.Panel1
            // 
            this.splitTable.Panel1.Controls.Add(this.tableViewResults);
            // 
            // tableViewResults
            // 
            this.tableViewResults.AllowUserToAddRows = false;
            this.tableViewResults.AllowUserToDeleteRows = false;
            this.tableViewResults.AllowUserToOrderColumns = true;
            this.tableViewResults.AllowUserToResizeRows = false;
            this.tableViewResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableViewResults.BackgroundColor = System.Drawing.SystemColors.Window;
            this.tableViewResults.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tableViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tableViewResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridcolumnExpand,
            this.gridcolumnName,
            this.gridcolumnPath,
            this.gridcolumnSize,
            this.gridcolumnModDate,
            this.gridcolumnType});
            resources.ApplyResources(this.tableViewResults, "tableViewResults");
            this.tableViewResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tableViewResults.Name = "tableViewResults";
            this.tableViewResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tableViewResults.RowHeadersVisible = false;
            this.tableViewResults.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(2);
            this.tableViewResults.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.tableViewResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableViewResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.onTableViewResultsCellClick);
            this.tableViewResults.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.onTableViewResultsCellDoubleClick);
            this.tableViewResults.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.onTableViewResultsCellEndEdit);
            this.tableViewResults.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.onTableViewResultsCellMouseDown);
            this.tableViewResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onTableViewResultsKeyDown);
            // 
            // gridcolumnExpand
            // 
            this.gridcolumnExpand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gridcolumnExpand.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridcolumnExpand.Frozen = true;
            resources.ApplyResources(this.gridcolumnExpand, "gridcolumnExpand");
            this.gridcolumnExpand.Name = "gridcolumnExpand";
            this.gridcolumnExpand.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // gridcolumnName
            // 
            this.gridcolumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridcolumnName.FillWeight = 25F;
            resources.ApplyResources(this.gridcolumnName, "gridcolumnName");
            this.gridcolumnName.Name = "gridcolumnName";
            this.gridcolumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridcolumnPath
            // 
            this.gridcolumnPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridcolumnPath.FillWeight = 40F;
            resources.ApplyResources(this.gridcolumnPath, "gridcolumnPath");
            this.gridcolumnPath.Name = "gridcolumnPath";
            this.gridcolumnPath.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridcolumnSize
            // 
            this.gridcolumnSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridcolumnSize.FillWeight = 10F;
            resources.ApplyResources(this.gridcolumnSize, "gridcolumnSize");
            this.gridcolumnSize.Name = "gridcolumnSize";
            this.gridcolumnSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridcolumnModDate
            // 
            this.gridcolumnModDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridcolumnModDate.FillWeight = 18F;
            resources.ApplyResources(this.gridcolumnModDate, "gridcolumnModDate");
            this.gridcolumnModDate.Name = "gridcolumnModDate";
            this.gridcolumnModDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridcolumnType
            // 
            this.gridcolumnType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridcolumnType.FillWeight = 10F;
            resources.ApplyResources(this.gridcolumnType, "gridcolumnType");
            this.gridcolumnType.Name = "gridcolumnType";
            this.gridcolumnType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panelTreeView
            // 
            this.panelTreeView.Controls.Add(this.splitTreeview);
            resources.ApplyResources(this.panelTreeView, "panelTreeView");
            this.panelTreeView.Name = "panelTreeView";
            // 
            // splitTreeview
            // 
            resources.ApplyResources(this.splitTreeview, "splitTreeview");
            this.splitTreeview.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitTreeview.Name = "splitTreeview";
            // 
            // splitTreeview.Panel1
            // 
            this.splitTreeview.Panel1.Controls.Add(this.treeViewResults);
            // 
            // treeViewResults
            // 
            resources.ApplyResources(this.treeViewResults, "treeViewResults");
            this.treeViewResults.HideSelection = false;
            this.treeViewResults.ItemHeight = 18;
            this.treeViewResults.LabelEdit = true;
            this.treeViewResults.Name = "treeViewResults";
            this.treeViewResults.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.onTreeViewResultsAfterLabelEdit);
            this.treeViewResults.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.onTreeViewResultsNodeMouseDoubleClick);
            this.treeViewResults.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onTreeViewResultsKeyDown);
            this.treeViewResults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onTreeViewResultsKeyPress);
            this.treeViewResults.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onTreeViewResultsMouseDown);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemProgram,
            this.menuItemView,
            this.menuItemLogging,
            this.menuItemExtras,
            this.menuItemHelp});
            resources.ApplyResources(this.mainMenu, "mainMenu");
            this.mainMenu.Name = "mainMenu";
            // 
            // menuItemProgram
            // 
            this.menuItemProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOptions,
            this.toolStripMenuItem1,
            this.menuItemExit});
            this.menuItemProgram.Name = "menuItemProgram";
            resources.ApplyResources(this.menuItemProgram, "menuItemProgram");
            // 
            // menuItemOptions
            // 
            this.menuItemOptions.Name = "menuItemOptions";
            resources.ApplyResources(this.menuItemOptions, "menuItemOptions");
            this.menuItemOptions.Click += new System.EventHandler(this.onMenuItemOptionsClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            resources.ApplyResources(this.menuItemExit, "menuItemExit");
            this.menuItemExit.Click += new System.EventHandler(this.onMenuItemExitClick);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAlwaysOnTop,
            this.menuItemResetWindowSize,
            this.menuItemTransparency});
            this.menuItemView.Name = "menuItemView";
            resources.ApplyResources(this.menuItemView, "menuItemView");
            // 
            // menuItemAlwaysOnTop
            // 
            this.menuItemAlwaysOnTop.Name = "menuItemAlwaysOnTop";
            resources.ApplyResources(this.menuItemAlwaysOnTop, "menuItemAlwaysOnTop");
            this.menuItemAlwaysOnTop.Click += new System.EventHandler(this.onMenuItemAlwaysOnTopClick);
            // 
            // menuItemResetWindowSize
            // 
            this.menuItemResetWindowSize.Name = "menuItemResetWindowSize";
            resources.ApplyResources(this.menuItemResetWindowSize, "menuItemResetWindowSize");
            this.menuItemResetWindowSize.Click += new System.EventHandler(this.onMenuItemResetWindowSizeClick);
            // 
            // menuItemTransparency
            // 
            this.menuItemTransparency.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemTransparency0,
            this.menuItemTransparency10,
            this.menuItemTransparency20,
            this.menuItemTransparency30,
            this.menuItemTransparency40,
            this.menuItemTransparency50,
            this.menuItemTransparency60,
            this.menuItemTransparency70,
            this.menuItemTransparency80,
            this.menuItemTransparency90});
            this.menuItemTransparency.Name = "menuItemTransparency";
            resources.ApplyResources(this.menuItemTransparency, "menuItemTransparency");
            // 
            // menuItemTransparency0
            // 
            this.menuItemTransparency0.Checked = true;
            this.menuItemTransparency0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemTransparency0.Name = "menuItemTransparency0";
            resources.ApplyResources(this.menuItemTransparency0, "menuItemTransparency0");
            this.menuItemTransparency0.Click += new System.EventHandler(this.onMenuItemTransparency0Click);
            // 
            // menuItemTransparency10
            // 
            this.menuItemTransparency10.Name = "menuItemTransparency10";
            resources.ApplyResources(this.menuItemTransparency10, "menuItemTransparency10");
            this.menuItemTransparency10.Click += new System.EventHandler(this.onMenuItemTransparency10Click);
            // 
            // menuItemTransparency20
            // 
            this.menuItemTransparency20.Name = "menuItemTransparency20";
            resources.ApplyResources(this.menuItemTransparency20, "menuItemTransparency20");
            this.menuItemTransparency20.Click += new System.EventHandler(this.onMenuItemTransparency20Click);
            // 
            // menuItemTransparency30
            // 
            this.menuItemTransparency30.Name = "menuItemTransparency30";
            resources.ApplyResources(this.menuItemTransparency30, "menuItemTransparency30");
            this.menuItemTransparency30.Click += new System.EventHandler(this.onMenuItemTransparency30Click);
            // 
            // menuItemTransparency40
            // 
            this.menuItemTransparency40.Name = "menuItemTransparency40";
            resources.ApplyResources(this.menuItemTransparency40, "menuItemTransparency40");
            this.menuItemTransparency40.Click += new System.EventHandler(this.onMenuItemTransparency40Click);
            // 
            // menuItemTransparency50
            // 
            this.menuItemTransparency50.Name = "menuItemTransparency50";
            resources.ApplyResources(this.menuItemTransparency50, "menuItemTransparency50");
            this.menuItemTransparency50.Click += new System.EventHandler(this.onMenuItemTransparency50Click);
            // 
            // menuItemTransparency60
            // 
            this.menuItemTransparency60.Name = "menuItemTransparency60";
            resources.ApplyResources(this.menuItemTransparency60, "menuItemTransparency60");
            this.menuItemTransparency60.Click += new System.EventHandler(this.onMenuItemTransparency60Click);
            // 
            // menuItemTransparency70
            // 
            this.menuItemTransparency70.Name = "menuItemTransparency70";
            resources.ApplyResources(this.menuItemTransparency70, "menuItemTransparency70");
            this.menuItemTransparency70.Click += new System.EventHandler(this.onMenuItemTransparency70Click);
            // 
            // menuItemTransparency80
            // 
            this.menuItemTransparency80.Name = "menuItemTransparency80";
            resources.ApplyResources(this.menuItemTransparency80, "menuItemTransparency80");
            this.menuItemTransparency80.Click += new System.EventHandler(this.onMenuItemTransparency80Click);
            // 
            // menuItemTransparency90
            // 
            this.menuItemTransparency90.Name = "menuItemTransparency90";
            resources.ApplyResources(this.menuItemTransparency90, "menuItemTransparency90");
            this.menuItemTransparency90.Click += new System.EventHandler(this.onMenuItemTransparency90Click);
            // 
            // menuItemLogging
            // 
            this.menuItemLogging.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemActivateLogging,
            this.menuItemLogLevel,
            this.toolStripMenuItem2,
            this.menuItemOpenLogFile});
            this.menuItemLogging.Name = "menuItemLogging";
            resources.ApplyResources(this.menuItemLogging, "menuItemLogging");
            // 
            // menuItemActivateLogging
            // 
            this.menuItemActivateLogging.Name = "menuItemActivateLogging";
            resources.ApplyResources(this.menuItemActivateLogging, "menuItemActivateLogging");
            this.menuItemActivateLogging.Click += new System.EventHandler(this.onMenuItemActivateLoggingClick);
            // 
            // menuItemLogLevel
            // 
            this.menuItemLogLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLogLevelFatal,
            this.menuItemLogLevelError,
            this.menuItemLogLevelWarning,
            this.menuItemLogLevelInfo});
            this.menuItemLogLevel.Name = "menuItemLogLevel";
            resources.ApplyResources(this.menuItemLogLevel, "menuItemLogLevel");
            // 
            // menuItemLogLevelFatal
            // 
            this.menuItemLogLevelFatal.Name = "menuItemLogLevelFatal";
            resources.ApplyResources(this.menuItemLogLevelFatal, "menuItemLogLevelFatal");
            this.menuItemLogLevelFatal.Click += new System.EventHandler(this.onMenuItemLogLevelFatalClick);
            // 
            // menuItemLogLevelError
            // 
            this.menuItemLogLevelError.Name = "menuItemLogLevelError";
            resources.ApplyResources(this.menuItemLogLevelError, "menuItemLogLevelError");
            this.menuItemLogLevelError.Click += new System.EventHandler(this.onMenuItemLogLevelErrorClick);
            // 
            // menuItemLogLevelWarning
            // 
            this.menuItemLogLevelWarning.Name = "menuItemLogLevelWarning";
            resources.ApplyResources(this.menuItemLogLevelWarning, "menuItemLogLevelWarning");
            this.menuItemLogLevelWarning.Click += new System.EventHandler(this.onMenuItemLogLevelWarningClick);
            // 
            // menuItemLogLevelInfo
            // 
            this.menuItemLogLevelInfo.Name = "menuItemLogLevelInfo";
            resources.ApplyResources(this.menuItemLogLevelInfo, "menuItemLogLevelInfo");
            this.menuItemLogLevelInfo.Click += new System.EventHandler(this.onMenuItemLogLevelInfoClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // menuItemOpenLogFile
            // 
            this.menuItemOpenLogFile.Name = "menuItemOpenLogFile";
            resources.ApplyResources(this.menuItemOpenLogFile, "menuItemOpenLogFile");
            this.menuItemOpenLogFile.Click += new System.EventHandler(this.onMenuItemOpenLogFileClick);
            // 
            // menuItemExtras
            // 
            this.menuItemExtras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemEmptyFoldersTool});
            this.menuItemExtras.Name = "menuItemExtras";
            resources.ApplyResources(this.menuItemExtras, "menuItemExtras");
            this.menuItemExtras.DropDownOpening += new System.EventHandler(this.onMenuItemExtrasDropDownOpening);
            // 
            // menuItemEmptyFoldersTool
            // 
            this.menuItemEmptyFoldersTool.Name = "menuItemEmptyFoldersTool";
            resources.ApplyResources(this.menuItemEmptyFoldersTool, "menuItemEmptyFoldersTool");
            this.menuItemEmptyFoldersTool.Click += new System.EventHandler(this.onMenuItemEmptyFoldersToolClick);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemGettingStarted,
            this.menuItemAboutShadows});
            this.menuItemHelp.Name = "menuItemHelp";
            resources.ApplyResources(this.menuItemHelp, "menuItemHelp");
            // 
            // menuItemGettingStarted
            // 
            this.menuItemGettingStarted.Name = "menuItemGettingStarted";
            resources.ApplyResources(this.menuItemGettingStarted, "menuItemGettingStarted");
            this.menuItemGettingStarted.Click += new System.EventHandler(this.onMenuItemGettingStartedClick);
            // 
            // menuItemAboutShadows
            // 
            this.menuItemAboutShadows.Name = "menuItemAboutShadows";
            resources.ApplyResources(this.menuItemAboutShadows, "menuItemAboutShadows");
            this.menuItemAboutShadows.Click += new System.EventHandler(this.onMenuItemAboutShadowsClick);
            // 
            // statusBarBottom
            // 
            this.statusBarBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statuslabelProgramName,
            this.progressBarSearchProgress,
            this.statusLabelInfos});
            resources.ApplyResources(this.statusBarBottom, "statusBarBottom");
            this.statusBarBottom.Name = "statusBarBottom";
            // 
            // statuslabelProgramName
            // 
            this.statuslabelProgramName.Name = "statuslabelProgramName";
            resources.ApplyResources(this.statuslabelProgramName, "statuslabelProgramName");
            // 
            // progressBarSearchProgress
            // 
            this.progressBarSearchProgress.Margin = new System.Windows.Forms.Padding(72, 2, 4, 2);
            this.progressBarSearchProgress.Name = "progressBarSearchProgress";
            resources.ApplyResources(this.progressBarSearchProgress, "progressBarSearchProgress");
            this.progressBarSearchProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // statusLabelInfos
            // 
            this.statusLabelInfos.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.statusLabelInfos.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.statusLabelInfos.Name = "statusLabelInfos";
            resources.ApplyResources(this.statusLabelInfos, "statusLabelInfos");
            this.statusLabelInfos.Spring = true;
            // 
            // contextMenuGroupEntry
            // 
            this.contextMenuGroupEntry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuOpenWithDefaultProgram,
            this.contextMenuRenameFile,
            this.contextMenuDeleteFile,
            this.toolStripMenuItem8,
            this.contextMenuShowInTreeView,
            this.toolStripMenuItem4,
            this.contextMenuShowInExplorerEntry,
            this.contextMenuShowAllInFolder});
            this.contextMenuGroupEntry.Name = "contextMenuGroupEntry";
            resources.ApplyResources(this.contextMenuGroupEntry, "contextMenuGroupEntry");
            this.contextMenuGroupEntry.Opening += new System.ComponentModel.CancelEventHandler(this.onContextMenuGroupEntryOpening);
            // 
            // contextMenuOpenWithDefaultProgram
            // 
            this.contextMenuOpenWithDefaultProgram.Name = "contextMenuOpenWithDefaultProgram";
            resources.ApplyResources(this.contextMenuOpenWithDefaultProgram, "contextMenuOpenWithDefaultProgram");
            this.contextMenuOpenWithDefaultProgram.Click += new System.EventHandler(this.onContextMenuOpenWithDefaultProgramClick);
            // 
            // contextMenuRenameFile
            // 
            this.contextMenuRenameFile.Name = "contextMenuRenameFile";
            resources.ApplyResources(this.contextMenuRenameFile, "contextMenuRenameFile");
            this.contextMenuRenameFile.Click += new System.EventHandler(this.onContextMenuRenameFileClick);
            // 
            // contextMenuDeleteFile
            // 
            this.contextMenuDeleteFile.Name = "contextMenuDeleteFile";
            resources.ApplyResources(this.contextMenuDeleteFile, "contextMenuDeleteFile");
            this.contextMenuDeleteFile.Click += new System.EventHandler(this.onContextMenuDeleteFileClick);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
            // 
            // contextMenuShowInTreeView
            // 
            this.contextMenuShowInTreeView.Name = "contextMenuShowInTreeView";
            resources.ApplyResources(this.contextMenuShowInTreeView, "contextMenuShowInTreeView");
            this.contextMenuShowInTreeView.Click += new System.EventHandler(this.onContextMenuShowInTreeViewClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // contextMenuShowInExplorerEntry
            // 
            this.contextMenuShowInExplorerEntry.Name = "contextMenuShowInExplorerEntry";
            resources.ApplyResources(this.contextMenuShowInExplorerEntry, "contextMenuShowInExplorerEntry");
            this.contextMenuShowInExplorerEntry.Click += new System.EventHandler(this.onContextMenuShowInExplorerEntryClick);
            // 
            // contextMenuShowAllInFolder
            // 
            this.contextMenuShowAllInFolder.Name = "contextMenuShowAllInFolder";
            resources.ApplyResources(this.contextMenuShowAllInFolder, "contextMenuShowAllInFolder");
            this.contextMenuShowAllInFolder.Click += new System.EventHandler(this.onContextMenuShowAllInFolderClick);
            // 
            // contextMenuGroupHeader
            // 
            this.contextMenuGroupHeader.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuExpandCollapse,
            this.contextMenuHide,
            this.toolStripMenuItem5,
            this.contextMenuShowInExplorerHeader});
            this.contextMenuGroupHeader.Name = "contextMenuGroupHeader";
            resources.ApplyResources(this.contextMenuGroupHeader, "contextMenuGroupHeader");
            this.contextMenuGroupHeader.Opening += new System.ComponentModel.CancelEventHandler(this.onContextMenuGroupHeaderOpening);
            // 
            // contextMenuExpandCollapse
            // 
            this.contextMenuExpandCollapse.Name = "contextMenuExpandCollapse";
            resources.ApplyResources(this.contextMenuExpandCollapse, "contextMenuExpandCollapse");
            this.contextMenuExpandCollapse.Click += new System.EventHandler(this.onContextMenuExpandCollapseClick);
            // 
            // contextMenuHide
            // 
            this.contextMenuHide.Name = "contextMenuHide";
            resources.ApplyResources(this.contextMenuHide, "contextMenuHide");
            this.contextMenuHide.Click += new System.EventHandler(this.onContextMenuHideClick);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // contextMenuShowInExplorerHeader
            // 
            this.contextMenuShowInExplorerHeader.Name = "contextMenuShowInExplorerHeader";
            resources.ApplyResources(this.contextMenuShowInExplorerHeader, "contextMenuShowInExplorerHeader");
            this.contextMenuShowInExplorerHeader.Click += new System.EventHandler(this.onContextMenuShowInExplorerHeaderClick);
            // 
            // contextMenuDirectoryNode
            // 
            this.contextMenuDirectoryNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuNodeDirShowInExplorer});
            this.contextMenuDirectoryNode.Name = "contextMenuDirectoryNode";
            resources.ApplyResources(this.contextMenuDirectoryNode, "contextMenuDirectoryNode");
            // 
            // contextMenuNodeDirShowInExplorer
            // 
            this.contextMenuNodeDirShowInExplorer.Name = "contextMenuNodeDirShowInExplorer";
            resources.ApplyResources(this.contextMenuNodeDirShowInExplorer, "contextMenuNodeDirShowInExplorer");
            this.contextMenuNodeDirShowInExplorer.Click += new System.EventHandler(this.onContextMenuNodeDirShowInExplorerClick);
            // 
            // contextMenuFileNode
            // 
            this.contextMenuFileNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuNodeOpenWithDefaultProgram,
            this.contextMenuNodeRenameFile,
            this.contextMenuNodeDeleteFile,
            this.toolStripMenuItem6,
            this.contextMenuNodeShowInTableView,
            this.toolStripMenuItem7,
            this.contextMenuNodeShowInExplorer});
            this.contextMenuFileNode.Name = "contextMenuFileNode";
            resources.ApplyResources(this.contextMenuFileNode, "contextMenuFileNode");
            // 
            // contextMenuNodeOpenWithDefaultProgram
            // 
            this.contextMenuNodeOpenWithDefaultProgram.Name = "contextMenuNodeOpenWithDefaultProgram";
            resources.ApplyResources(this.contextMenuNodeOpenWithDefaultProgram, "contextMenuNodeOpenWithDefaultProgram");
            this.contextMenuNodeOpenWithDefaultProgram.Click += new System.EventHandler(this.onContextMenuNodeOpenWithDefaultProgramClick);
            // 
            // contextMenuNodeRenameFile
            // 
            this.contextMenuNodeRenameFile.Name = "contextMenuNodeRenameFile";
            resources.ApplyResources(this.contextMenuNodeRenameFile, "contextMenuNodeRenameFile");
            this.contextMenuNodeRenameFile.Click += new System.EventHandler(this.onContextMenuNodeRenameFileClick);
            // 
            // contextMenuNodeDeleteFile
            // 
            this.contextMenuNodeDeleteFile.Name = "contextMenuNodeDeleteFile";
            resources.ApplyResources(this.contextMenuNodeDeleteFile, "contextMenuNodeDeleteFile");
            this.contextMenuNodeDeleteFile.Click += new System.EventHandler(this.onContextMenuNodeDeleteFileClick);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // contextMenuNodeShowInTableView
            // 
            this.contextMenuNodeShowInTableView.Name = "contextMenuNodeShowInTableView";
            resources.ApplyResources(this.contextMenuNodeShowInTableView, "contextMenuNodeShowInTableView");
            this.contextMenuNodeShowInTableView.Click += new System.EventHandler(this.onContextMenuNodeShowInTableViewClick);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            // 
            // contextMenuNodeShowInExplorer
            // 
            this.contextMenuNodeShowInExplorer.Name = "contextMenuNodeShowInExplorer";
            resources.ApplyResources(this.contextMenuNodeShowInExplorer, "contextMenuNodeShowInExplorer");
            this.contextMenuNodeShowInExplorer.Click += new System.EventHandler(this.onContextMenuNodeShowInExplorerClick);
            // 
            // notifyIconMinimized
            // 
            resources.ApplyResources(this.notifyIconMinimized, "notifyIconMinimized");
            this.notifyIconMinimized.BalloonTipClicked += new System.EventHandler(this.onNotifyIconMinimizedBalloonTipClicked);
            this.notifyIconMinimized.Click += new System.EventHandler(this.onNofityIconMinimizedClick);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitAll);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.statusBarBottom);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onMainFormClosing);
            this.Load += new System.EventHandler(this.onMainLoad);
            this.splitAll.Panel1.ResumeLayout(false);
            this.splitAll.Panel2.ResumeLayout(false);
            this.splitAll.ResumeLayout(false);
            this.splitTop.Panel1.ResumeLayout(false);
            this.splitTop.Panel2.ResumeLayout(false);
            this.splitTop.ResumeLayout(false);
            this.groupFolders.ResumeLayout(false);
            this.splitFolderSelection.Panel1.ResumeLayout(false);
            this.splitFolderSelection.Panel2.ResumeLayout(false);
            this.splitFolderSelection.ResumeLayout(false);
            this.contextMenuFolderTree.ResumeLayout(false);
            this.splitFoldersAdded.Panel1.ResumeLayout(false);
            this.splitFoldersAdded.Panel2.ResumeLayout(false);
            this.splitFoldersAdded.ResumeLayout(false);
            this.contextMenuAddedFolders.ResumeLayout(false);
            this.groupSettings.ResumeLayout(false);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageComparisonCriteria.ResumeLayout(false);
            this.tabPageComparisonCriteria.PerformLayout();
            this.tabPageFileTypes.ResumeLayout(false);
            this.tabPageFileTypes.PerformLayout();
            this.tabPageAdvancedSettings.ResumeLayout(false);
            this.tabPageAdvancedSettings.PerformLayout();
            this.splitBottom.Panel1.ResumeLayout(false);
            this.splitBottom.Panel1.PerformLayout();
            this.splitBottom.Panel2.ResumeLayout(false);
            this.splitBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTreeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxListView)).EndInit();
            this.groupResults.ResumeLayout(false);
            this.panelListView.ResumeLayout(false);
            this.splitTable.Panel1.ResumeLayout(false);
            this.splitTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableViewResults)).EndInit();
            this.panelTreeView.ResumeLayout(false);
            this.splitTreeview.Panel1.ResumeLayout(false);
            this.splitTreeview.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBarBottom.ResumeLayout(false);
            this.statusBarBottom.PerformLayout();
            this.contextMenuGroupEntry.ResumeLayout(false);
            this.contextMenuGroupHeader.ResumeLayout(false);
            this.contextMenuDirectoryNode.ResumeLayout(false);
            this.contextMenuFileNode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemProgram;
        private System.Windows.Forms.ToolStripMenuItem menuItemOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogging;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuItemAlwaysOnTop;
        private System.Windows.Forms.ToolStripMenuItem menuItemResetWindowSize;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency0;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency10;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency20;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency30;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency40;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency50;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency60;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency70;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency80;
        private System.Windows.Forms.ToolStripMenuItem menuItemTransparency90;
        private System.Windows.Forms.ToolStripMenuItem menuItemActivateLogging;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogLevel;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogLevelFatal;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogLevelWarning;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogLevelError;
        private System.Windows.Forms.ToolStripMenuItem menuItemLogLevelInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenLogFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemGettingStarted;
        private System.Windows.Forms.ToolStripMenuItem menuItemAboutShadows;
        private System.Windows.Forms.SplitContainer splitAll;
        private System.Windows.Forms.SplitContainer splitTop;
        private System.Windows.Forms.StatusStrip statusBarBottom;
        private System.Windows.Forms.GroupBox groupFolders;
        private System.Windows.Forms.SplitContainer splitFolderSelection;
        private ExpTreeLib.ExpTree expTreeFolders;
        private System.Windows.Forms.ContextMenuStrip contextMenuFolderTree;
        private System.Windows.Forms.SplitContainer splitFoldersAdded;
        private System.Windows.Forms.Button buttonAddFolder;
        private System.Windows.Forms.Button buttonRemoveFolder;
        private System.Windows.Forms.ContextMenuStrip contextMenuAddedFolders;
        private System.Windows.Forms.GroupBox groupSettings;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageComparisonCriteria;
        private System.Windows.Forms.CheckBox checkboxCompareFileName;
        private System.Windows.Forms.CheckBox checkboxCaseSensitive;
        private System.Windows.Forms.CheckBox checkboxFileExtension;
        private System.Windows.Forms.CheckBox checkboxCompareFileSize;
        private System.Windows.Forms.CheckBox checkboxCompareFileContents;
        private System.Windows.Forms.TabPage tabPageFileTypes;
        private System.Windows.Forms.TabPage tabPageAdvancedSettings;
        private System.Windows.Forms.RadioButton radiobuttonAllTypes;
        private System.Windows.Forms.RadioButton radiobuttonExcludeTypes;
        private System.Windows.Forms.RadioButton radiobuttonIncludeTypes;
        private System.Windows.Forms.CheckBox checkboxImages;
        private System.Windows.Forms.CheckBox checkboxMusic;
        private System.Windows.Forms.CheckBox checkboxVideos;
        private System.Windows.Forms.CheckBox checkboxCustomTypes;
        private System.Windows.Forms.TextBox textboxCustomTypes;
        private System.Windows.Forms.CheckBox checkboxHiddenFiles;
        private System.Windows.Forms.CheckBox checkboxSystemFiles;
        private System.Windows.Forms.CheckBox checkboxMatchRegex;
        private System.Windows.Forms.TextBox textboxMatchRegex;
        private System.Windows.Forms.SplitContainer splitBottom;
        private System.Windows.Forms.Button buttonStartSearch;
        private System.Windows.Forms.Button buttonStopSearch;
        private System.Windows.Forms.Button buttonPauseSearch;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.GroupBox groupResults;
        private System.Windows.Forms.SplitContainer splitTable;
        private System.Windows.Forms.ToolStripStatusLabel statuslabelProgramName;
        private System.Windows.Forms.ToolTip tooltipDefault;
        private ShadowsLib.FolderListView listboxFoldersAdded;
        private System.Windows.Forms.ToolStripMenuItem contextItemShowHiddenFolders;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem contextItemRefreshTree;
        private System.Windows.Forms.ToolStripMenuItem contextItemSelectAll;
        private System.Windows.Forms.ToolStripMenuItem contextItemSelectNone;
        private System.Windows.Forms.ToolStripMenuItem contextItemInvertSelection;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label labelFilesScanned;
        private System.Windows.Forms.Label labelCurrentFolder;
        private System.Windows.Forms.ToolStripProgressBar progressBarSearchProgress;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelInfos;
        private ShadowsLib.ResultsTableView tableViewResults;
        private System.Windows.Forms.NotifyIcon notifyIconMinimized;
        private System.Windows.Forms.ContextMenuStrip contextMenuGroupEntry;
        private System.Windows.Forms.ContextMenuStrip contextMenuGroupHeader;
        private System.Windows.Forms.ToolStripMenuItem contextMenuOpenWithDefaultProgram;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRenameFile;
        private System.Windows.Forms.ToolStripMenuItem contextMenuDeleteFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem contextMenuShowInExplorerEntry;
        private System.Windows.Forms.ToolStripMenuItem contextMenuExpandCollapse;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem contextMenuShowInExplorerHeader;
        private System.Windows.Forms.ToolStripMenuItem contextMenuShowAllInFolder;
        private System.Windows.Forms.ToolStripMenuItem contextMenuHide;
        private System.Windows.Forms.ToolStripMenuItem menuItemExtras;
        private System.Windows.Forms.ToolStripMenuItem menuItemEmptyFoldersTool;
        private System.Windows.Forms.DataGridViewImageColumn gridcolumnExpand;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridcolumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridcolumnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridcolumnSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridcolumnModDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridcolumnType;
        private System.Windows.Forms.PictureBox pictureBoxTreeView;
        private System.Windows.Forms.PictureBox pictureBoxListView;
        private System.Windows.Forms.Panel panelListView;
        private System.Windows.Forms.Panel panelTreeView;
        private ShadowsLib.ResultsTreeView treeViewResults;
        private System.Windows.Forms.ContextMenuStrip contextMenuDirectoryNode;
        private System.Windows.Forms.ContextMenuStrip contextMenuFileNode;
        private System.Windows.Forms.ToolStripMenuItem contextMenuNodeOpenWithDefaultProgram;
        private System.Windows.Forms.ToolStripMenuItem contextMenuNodeRenameFile;
        private System.Windows.Forms.ToolStripMenuItem contextMenuNodeDeleteFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem contextMenuNodeShowInExplorer;
        private System.Windows.Forms.ToolStripMenuItem contextMenuNodeDirShowInExplorer;
        private System.Windows.Forms.ToolStripMenuItem contextMenuNodeShowInTableView;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.SplitContainer splitTreeview;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem contextMenuShowInTreeView;
    }
}

