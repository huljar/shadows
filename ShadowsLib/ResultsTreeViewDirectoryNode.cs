using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShadowsLib {
    public class ResultsTreeViewDirectoryNode : ResultsTreeViewNode {

        private System.IO.DirectoryInfo directory;
        private int _ShadowCount = 0;
        private int _FileCount = 0;

        public ResultsTreeViewDirectoryNode(string name, System.IO.DirectoryInfo dir)
            : base(name) {
            directory = dir;
            UpdateText(false, true);
        }

        public ResultsTreeViewDirectoryNode(string name, int imageIndex, int selectedImageIndex, System.IO.DirectoryInfo dir)
            : base(name, imageIndex, selectedImageIndex) {
            directory = dir;
            UpdateText(false, true);
        }

        public void UpdateText(bool updateShadowCount = false, bool updateFileCount = false) {
            if(updateShadowCount) {
                _ShadowCount = 0;
                foreach(TreeNode node in Nodes) {
                    if(node is ResultsTreeViewFileNode) {
                        ++_ShadowCount;
                    }
                }
            }
            if(updateFileCount) {
                _FileCount = directory.GetFiles().Length; // TODO: hidden files?
            }
            Text = Name + " (" + ShadowCount + "/" + FileCount + ")";
        }

        public int ShadowCount {
            get {
                int ret = _ShadowCount;
                foreach(TreeNode node in Nodes) {
                    if(node is ResultsTreeViewDirectoryNode) {
                        ResultsTreeViewDirectoryNode dirNode = node as ResultsTreeViewDirectoryNode;
                        ret += dirNode.ShadowCount;
                    }
                }
                return ret;
            }
            set {
                _ShadowCount = value;
                UpdateText();
            }
        }

        public int FileCount {
            get {
                int ret = _FileCount;
                foreach(TreeNode node in Nodes) {
                    if(node is ResultsTreeViewDirectoryNode) {
                        ResultsTreeViewDirectoryNode dirNode = node as ResultsTreeViewDirectoryNode;
                        ret += dirNode.FileCount;
                    }
                }
                return ret;
            }
            set {
                _FileCount = value;
                UpdateText();
            }
        }
    }
}
