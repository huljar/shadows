namespace Shadows
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.splitAll = new System.Windows.Forms.SplitContainer();
            this.groupGeneral = new System.Windows.Forms.GroupBox();
            this.checkboxAutoRemoveGroups = new System.Windows.Forms.CheckBox();
            this.checkboxConfirmExit = new System.Windows.Forms.CheckBox();
            this.checkboxAutoExpand = new System.Windows.Forms.CheckBox();
            this.groupLogging = new System.Windows.Forms.GroupBox();
            this.buttonUseDefaultLogFolder = new System.Windows.Forms.Button();
            this.numericUpDownLogSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLogArchives = new System.Windows.Forms.NumericUpDown();
            this.buttonSelectLogFolder = new System.Windows.Forms.Button();
            this.textboxLogFolder = new System.Windows.Forms.TextBox();
            this.labelLogDirectory = new System.Windows.Forms.Label();
            this.labelLogSize1 = new System.Windows.Forms.Label();
            this.labelLogSize2 = new System.Windows.Forms.Label();
            this.labelLogArchives1 = new System.Windows.Forms.Label();
            this.labelLogArchives2 = new System.Windows.Forms.Label();
            this.tooltipDefault = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialogLogFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.splitAll.Panel1.SuspendLayout();
            this.splitAll.Panel2.SuspendLayout();
            this.splitAll.SuspendLayout();
            this.groupGeneral.SuspendLayout();
            this.groupLogging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLogSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLogArchives)).BeginInit();
            this.SuspendLayout();
            // 
            // splitAll
            // 
            resources.ApplyResources(this.splitAll, "splitAll");
            this.splitAll.Name = "splitAll";
            // 
            // splitAll.Panel1
            // 
            resources.ApplyResources(this.splitAll.Panel1, "splitAll.Panel1");
            this.splitAll.Panel1.Controls.Add(this.groupGeneral);
            this.tooltipDefault.SetToolTip(this.splitAll.Panel1, resources.GetString("splitAll.Panel1.ToolTip"));
            // 
            // splitAll.Panel2
            // 
            resources.ApplyResources(this.splitAll.Panel2, "splitAll.Panel2");
            this.splitAll.Panel2.Controls.Add(this.groupLogging);
            this.tooltipDefault.SetToolTip(this.splitAll.Panel2, resources.GetString("splitAll.Panel2.ToolTip"));
            this.tooltipDefault.SetToolTip(this.splitAll, resources.GetString("splitAll.ToolTip"));
            // 
            // groupGeneral
            // 
            resources.ApplyResources(this.groupGeneral, "groupGeneral");
            this.groupGeneral.Controls.Add(this.checkboxAutoRemoveGroups);
            this.groupGeneral.Controls.Add(this.checkboxConfirmExit);
            this.groupGeneral.Controls.Add(this.checkboxAutoExpand);
            this.groupGeneral.Name = "groupGeneral";
            this.groupGeneral.TabStop = false;
            this.tooltipDefault.SetToolTip(this.groupGeneral, resources.GetString("groupGeneral.ToolTip"));
            // 
            // checkboxAutoRemoveGroups
            // 
            resources.ApplyResources(this.checkboxAutoRemoveGroups, "checkboxAutoRemoveGroups");
            this.checkboxAutoRemoveGroups.Checked = true;
            this.checkboxAutoRemoveGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxAutoRemoveGroups.Name = "checkboxAutoRemoveGroups";
            this.tooltipDefault.SetToolTip(this.checkboxAutoRemoveGroups, resources.GetString("checkboxAutoRemoveGroups.ToolTip"));
            this.checkboxAutoRemoveGroups.UseVisualStyleBackColor = true;
            this.checkboxAutoRemoveGroups.CheckedChanged += new System.EventHandler(this.onCheckboxAutoRemoveGroupsCheckedChanged);
            // 
            // checkboxConfirmExit
            // 
            resources.ApplyResources(this.checkboxConfirmExit, "checkboxConfirmExit");
            this.checkboxConfirmExit.Name = "checkboxConfirmExit";
            this.tooltipDefault.SetToolTip(this.checkboxConfirmExit, resources.GetString("checkboxConfirmExit.ToolTip"));
            this.checkboxConfirmExit.UseVisualStyleBackColor = true;
            this.checkboxConfirmExit.CheckedChanged += new System.EventHandler(this.onCheckboxConfirmExitCheckedChanged);
            // 
            // checkboxAutoExpand
            // 
            resources.ApplyResources(this.checkboxAutoExpand, "checkboxAutoExpand");
            this.checkboxAutoExpand.Name = "checkboxAutoExpand";
            this.tooltipDefault.SetToolTip(this.checkboxAutoExpand, resources.GetString("checkboxAutoExpand.ToolTip"));
            this.checkboxAutoExpand.UseVisualStyleBackColor = true;
            this.checkboxAutoExpand.CheckedChanged += new System.EventHandler(this.onCheckboxAutoExpandCheckedChanged);
            // 
            // groupLogging
            // 
            resources.ApplyResources(this.groupLogging, "groupLogging");
            this.groupLogging.Controls.Add(this.buttonUseDefaultLogFolder);
            this.groupLogging.Controls.Add(this.numericUpDownLogSize);
            this.groupLogging.Controls.Add(this.numericUpDownLogArchives);
            this.groupLogging.Controls.Add(this.buttonSelectLogFolder);
            this.groupLogging.Controls.Add(this.textboxLogFolder);
            this.groupLogging.Controls.Add(this.labelLogDirectory);
            this.groupLogging.Controls.Add(this.labelLogSize1);
            this.groupLogging.Controls.Add(this.labelLogSize2);
            this.groupLogging.Controls.Add(this.labelLogArchives1);
            this.groupLogging.Controls.Add(this.labelLogArchives2);
            this.groupLogging.Name = "groupLogging";
            this.groupLogging.TabStop = false;
            this.tooltipDefault.SetToolTip(this.groupLogging, resources.GetString("groupLogging.ToolTip"));
            // 
            // buttonUseDefaultLogFolder
            // 
            resources.ApplyResources(this.buttonUseDefaultLogFolder, "buttonUseDefaultLogFolder");
            this.buttonUseDefaultLogFolder.Name = "buttonUseDefaultLogFolder";
            this.tooltipDefault.SetToolTip(this.buttonUseDefaultLogFolder, resources.GetString("buttonUseDefaultLogFolder.ToolTip"));
            this.buttonUseDefaultLogFolder.UseVisualStyleBackColor = true;
            this.buttonUseDefaultLogFolder.Click += new System.EventHandler(this.onButtonUseDefaultLogFolderClick);
            // 
            // numericUpDownLogSize
            // 
            resources.ApplyResources(this.numericUpDownLogSize, "numericUpDownLogSize");
            this.numericUpDownLogSize.Maximum = new decimal(new int[] {
            20480,
            0,
            0,
            0});
            this.numericUpDownLogSize.Name = "numericUpDownLogSize";
            this.tooltipDefault.SetToolTip(this.numericUpDownLogSize, resources.GetString("numericUpDownLogSize.ToolTip"));
            this.numericUpDownLogSize.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownLogSize.Leave += new System.EventHandler(this.onNumericUpDownLogSizeLeave);
            // 
            // numericUpDownLogArchives
            // 
            resources.ApplyResources(this.numericUpDownLogArchives, "numericUpDownLogArchives");
            this.numericUpDownLogArchives.Name = "numericUpDownLogArchives";
            this.tooltipDefault.SetToolTip(this.numericUpDownLogArchives, resources.GetString("numericUpDownLogArchives.ToolTip"));
            this.numericUpDownLogArchives.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownLogArchives.Leave += new System.EventHandler(this.onNumericUpDownLogArchivesLeave);
            // 
            // buttonSelectLogFolder
            // 
            resources.ApplyResources(this.buttonSelectLogFolder, "buttonSelectLogFolder");
            this.buttonSelectLogFolder.Name = "buttonSelectLogFolder";
            this.tooltipDefault.SetToolTip(this.buttonSelectLogFolder, resources.GetString("buttonSelectLogFolder.ToolTip"));
            this.buttonSelectLogFolder.UseVisualStyleBackColor = true;
            this.buttonSelectLogFolder.Click += new System.EventHandler(this.onButtonSelectLogFolderClick);
            // 
            // textboxLogFolder
            // 
            resources.ApplyResources(this.textboxLogFolder, "textboxLogFolder");
            this.textboxLogFolder.Name = "textboxLogFolder";
            this.textboxLogFolder.ReadOnly = true;
            this.tooltipDefault.SetToolTip(this.textboxLogFolder, resources.GetString("textboxLogFolder.ToolTip"));
            // 
            // labelLogDirectory
            // 
            resources.ApplyResources(this.labelLogDirectory, "labelLogDirectory");
            this.labelLogDirectory.Name = "labelLogDirectory";
            this.tooltipDefault.SetToolTip(this.labelLogDirectory, resources.GetString("labelLogDirectory.ToolTip"));
            // 
            // labelLogSize1
            // 
            resources.ApplyResources(this.labelLogSize1, "labelLogSize1");
            this.labelLogSize1.Name = "labelLogSize1";
            this.tooltipDefault.SetToolTip(this.labelLogSize1, resources.GetString("labelLogSize1.ToolTip"));
            // 
            // labelLogSize2
            // 
            resources.ApplyResources(this.labelLogSize2, "labelLogSize2");
            this.labelLogSize2.Name = "labelLogSize2";
            this.tooltipDefault.SetToolTip(this.labelLogSize2, resources.GetString("labelLogSize2.ToolTip"));
            // 
            // labelLogArchives1
            // 
            resources.ApplyResources(this.labelLogArchives1, "labelLogArchives1");
            this.labelLogArchives1.Name = "labelLogArchives1";
            this.tooltipDefault.SetToolTip(this.labelLogArchives1, resources.GetString("labelLogArchives1.ToolTip"));
            // 
            // labelLogArchives2
            // 
            resources.ApplyResources(this.labelLogArchives2, "labelLogArchives2");
            this.labelLogArchives2.Name = "labelLogArchives2";
            this.tooltipDefault.SetToolTip(this.labelLogArchives2, resources.GetString("labelLogArchives2.ToolTip"));
            // 
            // folderBrowserDialogLogFolder
            // 
            resources.ApplyResources(this.folderBrowserDialogLogFolder, "folderBrowserDialogLogFolder");
            // 
            // Options
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitAll);
            this.MaximizeBox = false;
            this.Name = "Options";
            this.tooltipDefault.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onOptionsFormClosing);
            this.Load += new System.EventHandler(this.onOptionsLoad);
            this.splitAll.Panel1.ResumeLayout(false);
            this.splitAll.Panel2.ResumeLayout(false);
            this.splitAll.ResumeLayout(false);
            this.groupGeneral.ResumeLayout(false);
            this.groupGeneral.PerformLayout();
            this.groupLogging.ResumeLayout(false);
            this.groupLogging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLogSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLogArchives)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitAll;
        private System.Windows.Forms.GroupBox groupGeneral;
        private System.Windows.Forms.GroupBox groupLogging;
        private System.Windows.Forms.CheckBox checkboxConfirmExit;
        private System.Windows.Forms.CheckBox checkboxAutoExpand;
        private System.Windows.Forms.CheckBox checkboxAutoRemoveGroups;
        private System.Windows.Forms.ToolTip tooltipDefault;
        private System.Windows.Forms.Label labelLogDirectory;
        private System.Windows.Forms.Label labelLogSize1;
        private System.Windows.Forms.Label labelLogSize2;
        private System.Windows.Forms.Label labelLogArchives1;
        private System.Windows.Forms.Label labelLogArchives2;
        private System.Windows.Forms.Button buttonSelectLogFolder;
        private System.Windows.Forms.TextBox textboxLogFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogLogFolder;
        private System.Windows.Forms.NumericUpDown numericUpDownLogSize;
        private System.Windows.Forms.NumericUpDown numericUpDownLogArchives;
        private System.Windows.Forms.Button buttonUseDefaultLogFolder;
    }
}