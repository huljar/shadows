using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {

    public delegate void ComparisonStartedEventHandler(object sender, ComparisonStartedEventArgs e);

    public class ComparisonStartedEventArgs : EventArgs {

        private readonly int _FilesTotal;

        public ComparisonStartedEventArgs(int filesTotal) {
            _FilesTotal = filesTotal;
        }

        public int FilesTotal {
            get { return _FilesTotal; }
        }
    }
}
