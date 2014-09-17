using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowsLib {
    public class FolderListView : System.Windows.Forms.ListBox {

        public enum FolderAddStatus {
            OK,
            VirtualDirectory,
            Recycled,
            AlreadyAdded,
            ParentAdded,
            SingleSubdirectoryAdded,
            MultipleSubdirectoriesAdded
        }

        public struct FolderAddResult {
            public FolderAddResult(FolderAddStatus status, FolderItem triggeringFolder = null) {
                this.status = status;
                this.triggeringFolder = triggeringFolder;
            }

            public FolderAddStatus status;
            public FolderItem triggeringFolder;
        }

        /// <summary>
        /// Adds a folder to the list and optionally aborts with a warning if subdirectories of <i>folder</i> have already been added.
        /// </summary>
        /// <param name="folder">The FolderItem to be added</param>
        /// <param name="warnAddedSubdirs">true to return with an error if subdirectories of <i>folder</i> are already in the list. Defaults to true.</param>
        /// <returns><i>FolderAddResults</i> struct containing information about the result of the addition of the folder.</returns>
        public FolderAddResult AddFolder(FolderItem folder, bool warnAddedSubdirs) {
            // Check that the folder is not virtual
            if(!folder.CheckRealFolder()) {
                return new FolderAddResult(FolderAddStatus.VirtualDirectory);
            }

            // Check that the folder is not in the recycle bin
            if(folder.CheckRecycled()) {
                return new FolderAddResult(FolderAddStatus.Recycled);
            }

            // Check if the folder has already been added
            FolderItem addedFolder = GetAddedFolder(folder);
            if(addedFolder != null) {
                ClearSelected();
                SelectedItem = addedFolder;
                return new FolderAddResult(FolderAddStatus.AlreadyAdded);
            }

            // Check if a parent folder has already been added
            FolderItem addedParent = GetAddedParentFolder(folder);
            if(addedParent != null) {
                ClearSelected();
                SelectedItem = addedParent;
                return new FolderAddResult(FolderAddStatus.ParentAdded, addedParent);
            }

            // Check if subdirectories of the added folder have already been added
            IList<FolderItem> addedSubfolders = GetAddedSubfolders(folder);
            if(addedSubfolders.Count != 0) {
                if(warnAddedSubdirs) {
                    ClearSelected();
                    foreach(FolderItem item in addedSubfolders) {
                        SelectedItem = item;
                    }
                    if(addedSubfolders.Count == 1) {
                        return new FolderAddResult(FolderAddStatus.SingleSubdirectoryAdded, addedSubfolders[0]);
                    }
                    else {
                        return new FolderAddResult(FolderAddStatus.MultipleSubdirectoriesAdded);
                    }
                }

                foreach(FolderItem item in addedSubfolders) {
                    Items.Remove(item);
                }
            }

            // Add the folder if the function reaches this point
            Items.Add(folder);
            return new FolderAddResult(FolderAddStatus.OK);
        }

        public void RemoveFolder(FolderItem folder) {
            Items.Remove(folder);
        }

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
                System.IO.DirectoryInfo itemParent = folder.GetDirectory().Parent;
                if(itemParent != null && itemParent.FullName.StartsWith(item.Node.Path)) {
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
                System.IO.DirectoryInfo parent = item.GetDirectory().Parent;
                if(parent != null && parent.FullName.StartsWith(folder.Node.Path)) {
                    ret.Add(item);
                }
            }
            return ret;
        }
    }
}
