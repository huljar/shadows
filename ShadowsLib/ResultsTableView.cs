using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {
    public class ResultsTableView : System.Windows.Forms.DataGridView {

        private IList<ResultsGroup> groups = new List<ResultsGroup>(); 

        public void AddGroup(ResultsGroup group, bool expandAfterwards = false) {
            if(!groups.Contains(group)) {
                groups.Add(group);
                Rows.Add(group.Header);
                if(expandAfterwards && !group.Expanded) {
                    ExpandGroup(group);
                }
            }
        }

        public void RemoveGroup(ResultsGroup group) {
            if(groups.Contains(group)) {
                if(group.Expanded) {
                    CollapseGroup(group);
                }
                Rows.Remove(group.Header);
                groups.Remove(group);
            }
        }

        public void ExpandGroup(ResultsGroup group) {
            if(groups.Contains(group) && !group.Expanded) {
                int i = 0;
                foreach(ResultsTableViewEntry row in group.Entries) {
                    ++i;
                    Rows.Insert(group.Header.Index + i, row);
                }
                group.Expanded = true;
            }
        }

        public void CollapseGroup(ResultsGroup group) {
            if(groups.Contains(group) && group.Expanded) {
                foreach(ResultsTableViewEntry row in group.Entries) {
                    Rows.Remove(row);
                }
                group.Expanded = false;
            }
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<ResultsGroup> GetGroups() {
            return new System.Collections.ObjectModel.ReadOnlyCollection<ResultsGroup>(groups);
        }

        public void Reset() {
            foreach(ResultsGroup group in groups) {
                group.Dispose();
            }
            groups.Clear();
            Rows.Clear();
        }
    }
}
