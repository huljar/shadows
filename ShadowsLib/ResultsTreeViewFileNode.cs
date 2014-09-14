using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowsLib {
    public class ResultsTreeViewFileNode : ResultsTreeViewNode {

        private FileInfoWrapper _FileAssociated;

        public ResultsTreeViewFileNode(string name, FileInfoWrapper fileAssociated)
            : base(name) {
            _FileAssociated = fileAssociated;
        }

        public FileInfoWrapper FileAssociated {
            get { return _FileAssociated; }
            set { _FileAssociated = value; }
        }
    }
}
