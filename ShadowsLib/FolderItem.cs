using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {
    public class FolderItem {

        private ExpTreeLib.CShItem _node;

        public FolderItem(ExpTreeLib.CShItem node) {
            _node = node;
        }

        public FolderItem(string path) {
            _node = new ExpTreeLib.CShItem(path);
        }

        public ExpTreeLib.CShItem Node {
            get { return _node; }
        }

        public System.IO.DirectoryInfo GetDirectory() {
            return new System.IO.DirectoryInfo(Node.Path);
        }

        public override string ToString() {
            return Node.DisplayName + " (" + Node.Path + ")";
        }

        public bool CheckRealFolder() {
            return Node.IsFileSystem && Node.IsFolder;
        }

        public bool CheckRecycled() {
            return Node.Path.Contains(":\\$RECYCLE.BIN\\");
        }
    }
}
