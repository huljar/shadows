using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {

    public delegate void ScanningNewFolderEventHandler(object sender, ScanningNewFolderEventArgs e);

    public class ScanningNewFolderEventArgs : EventArgs {

        private readonly System.IO.DirectoryInfo _NewFolder;

        public ScanningNewFolderEventArgs(System.IO.DirectoryInfo newFolder) {
            _NewFolder = newFolder;
        }

        public System.IO.DirectoryInfo NewFolder {
            get { return _NewFolder; }
        }
    }
}
