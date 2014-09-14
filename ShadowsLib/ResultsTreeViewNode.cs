using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowsLib {
    public abstract class ResultsTreeViewNode : System.Windows.Forms.TreeNode {

        public ResultsTreeViewNode(string name)
            : base(name) {
            Name = string.Copy(name);
        }

        public ResultsTreeViewNode(string name, int imageIndex, int selectedImageIndex)
            : base(name, imageIndex, selectedImageIndex) {
            Name = string.Copy(name);
        }

        public string FullPathByName {
            get {
                if(TreeView == null) {
                    throw new InvalidOperationException();
                }
                if(Parent == null) {
                    return Name;
                }
                ResultsTreeViewNode parent = Parent as ResultsTreeViewNode;
                if(parent != null) {
                    return parent.FullPathByName + TreeView.PathSeparator + Name;
                }
                throw new InvalidOperationException();
            }
        }
    }
}
