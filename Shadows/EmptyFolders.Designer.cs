namespace Shadows {
    partial class EmptyFolders {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmptyFolders));
            this.splitAll = new System.Windows.Forms.SplitContainer();
            this.groupBoxFolder = new System.Windows.Forms.GroupBox();
            this.checkboxRemoveIfOnlyHiddenFiles = new System.Windows.Forms.CheckBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textboxFolder = new System.Windows.Forms.TextBox();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupResults = new System.Windows.Forms.GroupBox();
            this.labelMostRecentDeletion = new System.Windows.Forms.Label();
            this.labelScanningFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialogSelect = new System.Windows.Forms.FolderBrowserDialog();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.splitAll.Panel1.SuspendLayout();
            this.splitAll.Panel2.SuspendLayout();
            this.splitAll.SuspendLayout();
            this.groupBoxFolder.SuspendLayout();
            this.groupResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitAll
            // 
            resources.ApplyResources(this.splitAll, "splitAll");
            this.splitAll.Name = "splitAll";
            // 
            // splitAll.Panel1
            // 
            this.splitAll.Panel1.Controls.Add(this.groupBoxFolder);
            resources.ApplyResources(this.splitAll.Panel1, "splitAll.Panel1");
            // 
            // splitAll.Panel2
            // 
            this.splitAll.Panel2.Controls.Add(this.groupResults);
            resources.ApplyResources(this.splitAll.Panel2, "splitAll.Panel2");
            // 
            // groupBoxFolder
            // 
            this.groupBoxFolder.Controls.Add(this.checkboxRemoveIfOnlyHiddenFiles);
            this.groupBoxFolder.Controls.Add(this.buttonStop);
            this.groupBoxFolder.Controls.Add(this.textboxFolder);
            this.groupBoxFolder.Controls.Add(this.buttonSelectFolder);
            this.groupBoxFolder.Controls.Add(this.buttonStart);
            resources.ApplyResources(this.groupBoxFolder, "groupBoxFolder");
            this.groupBoxFolder.Name = "groupBoxFolder";
            this.groupBoxFolder.TabStop = false;
            // 
            // checkboxRemoveIfOnlyHiddenFiles
            // 
            resources.ApplyResources(this.checkboxRemoveIfOnlyHiddenFiles, "checkboxRemoveIfOnlyHiddenFiles");
            this.checkboxRemoveIfOnlyHiddenFiles.Name = "checkboxRemoveIfOnlyHiddenFiles";
            this.checkboxRemoveIfOnlyHiddenFiles.UseVisualStyleBackColor = true;
            this.checkboxRemoveIfOnlyHiddenFiles.CheckedChanged += new System.EventHandler(this.onCheckboxRemoveIfOnlyHiddenFilesCheckedChanged);
            // 
            // buttonStop
            // 
            resources.ApplyResources(this.buttonStop, "buttonStop");
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.onButtonStopClick);
            // 
            // textboxFolder
            // 
            resources.ApplyResources(this.textboxFolder, "textboxFolder");
            this.textboxFolder.Name = "textboxFolder";
            this.textboxFolder.ReadOnly = true;
            // 
            // buttonSelectFolder
            // 
            resources.ApplyResources(this.buttonSelectFolder, "buttonSelectFolder");
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.onButtonSelectFolderClick);
            // 
            // buttonStart
            // 
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.onButtonStartClick);
            // 
            // groupResults
            // 
            this.groupResults.Controls.Add(this.labelMostRecentDeletion);
            this.groupResults.Controls.Add(this.labelScanningFolder);
            resources.ApplyResources(this.groupResults, "groupResults");
            this.groupResults.Name = "groupResults";
            this.groupResults.TabStop = false;
            // 
            // labelMostRecentDeletion
            // 
            resources.ApplyResources(this.labelMostRecentDeletion, "labelMostRecentDeletion");
            this.labelMostRecentDeletion.Name = "labelMostRecentDeletion";
            // 
            // labelScanningFolder
            // 
            resources.ApplyResources(this.labelScanningFolder, "labelScanningFolder");
            this.labelScanningFolder.Name = "labelScanningFolder";
            // 
            // folderBrowserDialogSelect
            // 
            resources.ApplyResources(this.folderBrowserDialogSelect, "folderBrowserDialogSelect");
            this.folderBrowserDialogSelect.ShowNewFolderButton = false;
            // 
            // worker
            // 
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.onWorkerDoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.onWorkerRunWorkerCompleted);
            // 
            // EmptyFolders
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "EmptyFolders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onEmptyFoldersFormClosing);
            this.Load += new System.EventHandler(this.onEmptyFoldersLoad);
            this.splitAll.Panel1.ResumeLayout(false);
            this.splitAll.Panel2.ResumeLayout(false);
            this.splitAll.ResumeLayout(false);
            this.groupBoxFolder.ResumeLayout(false);
            this.groupBoxFolder.PerformLayout();
            this.groupResults.ResumeLayout(false);
            this.groupResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textboxFolder;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelScanningFolder;
        private System.Windows.Forms.GroupBox groupBoxFolder;
        private System.Windows.Forms.GroupBox groupResults;
        private System.Windows.Forms.SplitContainer splitAll;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSelect;
        private System.Windows.Forms.Label labelMostRecentDeletion;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkboxRemoveIfOnlyHiddenFiles;
    }
}