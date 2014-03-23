using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {
    public class ResultsTableViewEntry : ResultsTableViewRow {

        private FileInfoWrapper _FileAssociated;

        public ResultsTableViewEntry(FileInfoWrapper fileAssociated)
            : base() {
            _FileAssociated = fileAssociated;
        }

        public FileInfoWrapper FileAssociated {
            get { return _FileAssociated; }
            set { _FileAssociated = value; }
        }
    }
}
