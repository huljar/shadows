using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowsLib {
    public abstract class ResultsTreeViewNode : System.Windows.Forms.TreeNode {

        public ResultsTreeViewNode(string name)
            : base(name) {
            Name = name;
        }
    }
}
