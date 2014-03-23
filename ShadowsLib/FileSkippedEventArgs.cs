using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {

    public delegate void FileSkippedEventHandler(object sender, FileSkippedEventArgs e);

    public class FileSkippedEventArgs : EventArgs {

        private readonly System.IO.FileInfo _File;
        private readonly string _Reason;

        public FileSkippedEventArgs(System.IO.FileInfo file, string reason) {
            _File = file;
            _Reason = reason;
        }

        public System.IO.FileInfo File {
            get { return _File; }
        }

        public string Reason {
            get { return _Reason; }
        }
    }
}
