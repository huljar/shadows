using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {
    public class EmptyFoldersSearchResult {
        
        private readonly int _FoldersScanned;
        private readonly int _FoldersDeleted;
        private readonly bool _Canceled;

        public EmptyFoldersSearchResult(int foldersScanned, int foldersDeleted, bool canceled) {
            _FoldersScanned = foldersScanned;
            _FoldersDeleted = foldersDeleted;
            _Canceled = canceled;
        }

        public int FoldersScanned {
            get { return _FoldersScanned; }
        }

        public int FoldersDeleted {
            get { return _FoldersDeleted; }
        }

        public bool Canceled {
            get { return _Canceled; }
        }
    }
}
