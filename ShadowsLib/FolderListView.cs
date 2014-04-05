using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {
    public class FolderListView : System.Windows.Forms.ListBox {

        /// <summary>
        /// Returns the <i>FolderItem</i> in the ListBox if it was already added, otherwise returns <i>null</i>.
        /// </summary>
        /// <param name="folder">The folder to be looked up.</param>
        /// <returns>The retrieved FolderItem, or null.</returns>
        public FolderItem GetAddedFolder(FolderItem folder) {
            foreach(FolderItem item in Items) {
                if(item.Node.Path.Equals(folder.Node.Path)) {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the Parent <i>FolderItem</i> in the ListBox if a parent folder was already added, otherwise returns <i>null</i>.
        /// </summary>
        /// <param name="folder">The folder to be checked.</param>
        /// <returns>The retrieved Parent FolderItem, or null.</returns>
        public FolderItem GetAddedParentFolder(FolderItem folder) {
            foreach(FolderItem item in Items) {
                if(((System.IO.DirectoryInfo)folder).Parent.FullName.StartsWith(item.Node.Path)) {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns all subfolder <i>FolderItem</i>s in the ListBox that were already added. Returns an empty list if none were found.
        /// </summary>
        /// <param name="folder">The folder to be checked.</param>
        /// <returns>List of added subfolders or empty list.</returns>
        public IList<FolderItem> GetAddedSubfolders(FolderItem folder) {
            IList<FolderItem> ret = new List<FolderItem>();
            foreach(FolderItem item in Items) {
                System.IO.DirectoryInfo parent = ((System.IO.DirectoryInfo)item).Parent;
                if(parent != null && parent.FullName.StartsWith(folder.Node.Path)) {
                    ret.Add(item);
                }
            }
            return ret;
        }

        public IList<T> GetList<T>() {
            IList<T> ret = new List<T>(Items.Count);
            foreach(T item in Items) {
                ret.Add(item);
            }
            return ret;
        }
    }
}
