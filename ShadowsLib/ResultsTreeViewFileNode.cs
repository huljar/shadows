using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowsLib {
    public class ResultsTreeViewFileNode : ResultsTreeViewNode, IFileAssociated {

        private FileInfoWrapper _FileAssociated;

        public ResultsTreeViewFileNode(string name, FileInfoWrapper fileAssociated, IList<FileInfoWrapper> shadowSet)
            : base(name) {
            _FileAssociated = fileAssociated;
        }

        public ResultsTreeViewFileNode(string name, int imageIndex, int selectedImageIndex, FileInfoWrapper fileAssociated, IList<FileInfoWrapper> shadowSet)
            : base(name, imageIndex, selectedImageIndex) {
            _FileAssociated = fileAssociated;
        }

        public FileInfoWrapper FileAssociated {
            get { return _FileAssociated; }
            set { _FileAssociated = value; }
        }
    }
}
