using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {

    public delegate void ProgressMadeEventHandler(object sender, ProgressMadeEventArgs e);

    public class ProgressMadeEventArgs : EventArgs {

        private readonly int _ProgressPercentage;

        public ProgressMadeEventArgs(int progressPercentage) {
            _ProgressPercentage = progressPercentage;
        }

        public int ProgressPercentage {
            get { return _ProgressPercentage; }
        }
    }
}
