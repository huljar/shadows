using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowsLib {
    public interface IDirectoryAssociated {
        System.IO.DirectoryInfo DirectoryAssociated { get; set; }
    }
}
