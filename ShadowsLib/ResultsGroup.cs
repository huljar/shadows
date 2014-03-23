using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ShadowsLib {
    public class ResultsGroup : IDisposable {

        private ResultsTableViewHeader _Header;
        private IList<ResultsTableViewEntry> _Entries;
        private bool _Expanded;

        public ResultsGroup(ResultsTableViewHeader header, IList<ResultsTableViewEntry> items, bool expanded = false) {
            header.ContainerGroup = this;

            foreach(ResultsTableViewEntry entry in items) {
                entry.ContainerGroup = this;
            }

            _Header = header;
            _Entries = items;
            _Expanded = expanded;
        }

        public ResultsTableViewHeader Header {
            get { return _Header; }
            set { _Header = value; }
        }

        public IList<ResultsTableViewEntry> Entries {
            get { return _Entries; }
        }

        public bool Expanded {
            get { return _Expanded; }
            set { _Expanded = value; }
        }

        public IList<FileInfoWrapper> GetFilesAssociated() {
            IList<FileInfoWrapper> ret = new List<FileInfoWrapper>(Entries.Count);
            foreach(ResultsTableViewEntry entry in Entries) {
                ret.Add(entry.FileAssociated);
            }
            return ret;
        }

        public void Dispose() {
            _Header.Dispose();
            _Header = null;
            foreach(ResultsTableViewEntry entry in _Entries) {
                entry.Dispose();
            }
            _Entries.Clear();
            _Entries = null;
        }
    }
}
