using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {
    public abstract class ResultsTableViewRow : System.Windows.Forms.DataGridViewRow {

        private ResultsGroup _ContainerGroup;

        public ResultsGroup ContainerGroup {
            get { return _ContainerGroup; }
            set { _ContainerGroup = value; }
        }
    }
}
