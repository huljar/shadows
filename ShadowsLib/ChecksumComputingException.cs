using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {
    public class ChecksumComputingException : Exception {

        private readonly System.IO.FileInfo _File;

        public ChecksumComputingException(string message, System.IO.FileInfo file)
            : base(message) {
            _File = file;
        }

        public ChecksumComputingException(string message, System.IO.FileInfo file, Exception innerException)
            : base(message, innerException) {
            _File = file;
        }

        public System.IO.FileInfo File {
            get { return _File; }
        }
    }
}
