using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {

    public delegate void DirectorySkippedEventHandler(object sender, DirectorySkippedEventArgs e);

    public class DirectorySkippedEventArgs : EventArgs {

        private readonly System.IO.DirectoryInfo _Directory;
        private readonly string _Reason;

        public DirectorySkippedEventArgs(System.IO.DirectoryInfo dir, string reason) {
            _Directory = dir;
            _Reason = reason;
        }

        public System.IO.DirectoryInfo Directory {
            get { return _Directory; }
        }

        public string Reason {
            get { return _Reason; }
        }

    }
}
