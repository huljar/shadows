using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {

    public delegate void ScanningNewFileEventHandler(object sender, ScanningNewFileEventArgs e);

    public class ScanningNewFileEventArgs : EventArgs {

        private readonly System.IO.FileInfo _NewFile;
        private readonly int _FilesScanned;
        private readonly int _FilesTotal;

        public ScanningNewFileEventArgs(System.IO.FileInfo newFile, int filesScanned, int filesTotal) {
            _NewFile = newFile;
            _FilesScanned = filesScanned;
            _FilesTotal = filesTotal;
        }

        public System.IO.FileInfo NewFile {
            get { return _NewFile; }
        }

        public int FilesScanned {
            get { return _FilesScanned; }
        }

        public int FilesTotal {
            get { return _FilesTotal; }
        }
    }
}
