using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

using ShadowsLib;

namespace Shadows {
    static class Util {

        public enum SearchState {
            Ready,
            Counting,
            Scanning,
            Paused,
            Aborted,
            Finished
        }

        public enum StateChange {
            Start,
            Stop,
            Pause,
            Resume,
            Complete
        }

        public enum DeletionResult {
            Success,
            Canceled,
            Aborted
        }

        public static bool IsValidExtensionInput(string input) {
            // Check for illegal characters
            foreach(char illegalChar in System.IO.Path.GetInvalidFileNameChars()) {
                if(input.Contains(illegalChar.ToString())) {
                    return false;
                }
            }
            return true;
        }

        public static System.Collections.Specialized.StringCollection FormatForSettings(string input, char splitChar) {
            System.Collections.Specialized.StringCollection ret = new System.Collections.Specialized.StringCollection();
            if(String.IsNullOrEmpty(input)) {
                return ret;
            }

            string[] split = input.Split(new char[] { splitChar }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string ext in split) {
                ret.Add(ext.Trim());
            }

            return ret;
        }

        public static void ChangeControlStateRecursive(System.Windows.Forms.Control rootControl, bool enable) {
            if(rootControl.HasChildren) {
                foreach(System.Windows.Forms.Control child in rootControl.Controls) {
                    ChangeControlStateRecursive(child, enable);
                }
            }
            rootControl.Enabled = enable;
        }

        public static bool IsValidRegex(string pattern) {
            if(string.IsNullOrEmpty(pattern)) return false;

            try {
                System.Text.RegularExpressions.Regex.Match("", pattern);
            }
            catch(ArgumentException) {
                return false;
            }

            return true;
        }

        public static string HumanReadableSize(long bytes) {
            string[] sizes = { "Byte", "KB", "MB", "GB" };
            double length = bytes;
            byte unit = 0;

            while(length >= 1024 && unit + 1 < sizes.Length) {
                ++unit;
                length /= 1024;
            }

            return String.Format("{0:0.##} {1}", length, sizes[unit]);
        }

        public static bool CheckDragDropOnlyDirectories(System.Windows.Forms.IDataObject dragData) {
            if(!dragData.GetDataPresent(DataFormats.FileDrop)) {
                return false;
            }
            string[] files = (string[])dragData.GetData(DataFormats.FileDrop);
            try {
                foreach(string file in files) {
                    if((File.GetAttributes(file) & FileAttributes.Directory) != FileAttributes.Directory) {
                        return false;
                    }
                }
            }
            catch(Exception) {
                return false;
            }
            return true;
        }
    }
}