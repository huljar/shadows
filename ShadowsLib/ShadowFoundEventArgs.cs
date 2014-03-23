using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {

    public delegate void ShadowFoundEventHandler(object sender, ShadowFoundEventArgs e);

    public class ShadowFoundEventArgs : EventArgs {

        private readonly Set<FileInfoWrapper> _ShadowSet;

        public ShadowFoundEventArgs(Set<FileInfoWrapper> shadowSet) {
            _ShadowSet = shadowSet;
        }

        public Set<FileInfoWrapper> ShadowSet {
            get { return _ShadowSet; }
        }
    }
}
