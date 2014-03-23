using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {
    public class SearchResult {

        private readonly IList<Set<FileInfoWrapper>> _AllShadows;
        private readonly int _FilesScanned;
        private readonly bool _WasCanceled;

        public SearchResult(IList<Set<FileInfoWrapper>> allShadows, int filesScanned, bool wasCanceled) {
            _AllShadows = allShadows;
            _FilesScanned = filesScanned;
            _WasCanceled = wasCanceled;
        }

        public IList<Set<FileInfoWrapper>> AllShadows {
            get { return _AllShadows; }
        }

        public int FilesScanned {
            get { return _FilesScanned; }
        }

        public bool WasCanceled {
            get { return _WasCanceled; }
        }
    }
}
