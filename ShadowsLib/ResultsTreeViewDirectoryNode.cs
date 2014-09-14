using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowsLib {
    public class ResultsTreeViewDirectoryNode : ResultsTreeViewNode {

        private int _ShadowCount;
        private int _FileCount;

        public ResultsTreeViewDirectoryNode(string name)
            : base(name) {

        }

        public void UpdateText() {
            Text = Name + " (" + ShadowCount + "/" + FileCount + ")";
        }

        public int ShadowCount {
            get {
                int ret = _ShadowCount;
                foreach(System.Windows.Forms.TreeNode node in Nodes) {
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
                foreach(System.Windows.Forms.TreeNode node in Nodes) {
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
