using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Shadows.Properties;

namespace Shadows {
    public partial class Options : Form {

        public Options() {
            InitializeComponent();
        }

        private void onOptionsLoad(object sender, EventArgs e) {
            ApplySettings();
        }

        private void onOptionsFormClosing(object sender, FormClosingEventArgs e) {
            // TODO: find better way
            onNumericUpDownLogSizeLeave(sender, e);
            onNumericUpDownLogArchivesLeave(sender, e);

            LogHelper.SetUpLogger(Settings.Default.LogLevel, Settings.Default.LogActive);
        }

        private void ApplySettings() {
            checkboxConfirmExit.Checked = Settings.Default.ConfirmExit;
            checkboxAutoExpand.Checked = Settings.Default.ResultsInitiallyExpanded;
            checkboxAutoRemoveGroups.Checked = Settings.Default.RemoveGroupsWithOneEntry;

            textboxLogFolder.Text = String.IsNullOrEmpty(Settings.Default.LogDirectory) ? LogHelper.DefaultLogDirectory : Settings.Default.LogDirectory;
            numericUpDownLogSize.Value = Settings.Default.LogMaxSize;
            numericUpDownLogArchives.Value = Settings.Default.LogArchives;
        }

        private void onButtonSelectLogFolderClick(object sender, EventArgs e) {
            if(folderBrowserDialogLogFolder.ShowDialog() == DialogResult.OK) {
                textboxLogFolder.Text = folderBrowserDialogLogFolder.SelectedPath;
                Settings.Default.LogDirectory = folderBrowserDialogLogFolder.SelectedPath;
            }
        }

        private void onButtonUseDefaultLogFolderClick(object sender, EventArgs e) {
            Settings.Default.LogDirectory = String.Empty;
            textboxLogFolder.Text = LogHelper.DefaultLogDirectory;
        }

        private void onNumericUpDownLogSizeLeave(object sender, EventArgs e) {
            Settings.Default.LogMaxSize = (int)numericUpDownLogSize.Value;
        }

        private void onNumericUpDownLogArchivesLeave(object sender, EventArgs e) {
            Settings.Default.LogArchives = (int)numericUpDownLogArchives.Value;
        }

        private void onCheckboxConfirmExitCheckedChanged(object sender, EventArgs e) {
            Settings.Default.ConfirmExit = checkboxConfirmExit.Checked;
        }

        private void onCheckboxAutoExpandCheckedChanged(object sender, EventArgs e) {
            Settings.Default.ResultsInitiallyExpanded = checkboxAutoExpand.Checked;
        }

        private void onCheckboxAutoRemoveGroupsCheckedChanged(object sender, EventArgs e) {
            Settings.Default.RemoveGroupsWithOneEntry = checkboxAutoRemoveGroups.Checked;
        }
    }
}
