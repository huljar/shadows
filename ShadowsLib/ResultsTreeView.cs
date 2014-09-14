using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ShadowsLib {
    public class ResultsTreeView : System.Windows.Forms.TreeView {

        private IList<FolderItem> _RootFolders = new List<FolderItem>();

        public void AddShadow(IList<FileInfoWrapper> shadowSet) { // TODO: ROOT NODES MUST BE FOLDERS THAT WERE ADDED TO THE SEARCH!!!!!
            BeginUpdate();
            foreach(FileInfoWrapper file in shadowSet) {
                InsertFileNode(file);
            }
            EndUpdate();
        }

        public void Reset() {
            BeginUpdate();
            Nodes.Clear();
            RootFolders.Clear();
            EndUpdate();
        }

        private void InsertFileNode(FileInfoWrapper file) {
            // Find the root folder that was added to the search which is a parent of the file
            FolderItem root = null;
            foreach(FolderItem rootFolder in RootFolders) {
                if(file.File.FullName.StartsWith(rootFolder.Node.Path + Path.DirectorySeparatorChar)) {
                    root = rootFolder;
                    break;
                }
            }
            if(root == null) {
                throw new Exception("Error: TreeView: file was supposed to be added which is not a child of a folder added to the search");
            }

            // Retrieve the tree node of the root folder
            TreeNode currentNode = null;
            foreach(TreeNode node in Nodes) {
                if(node.Name.Equals(root.Node.Path)) {
                    currentNode = node;
                    break;
                }
            }
            // Add root node if it does not exist yet
            if(currentNode == null) {
                currentNode = new ResultsTreeViewDirectoryNode(root.Node.Path);
                Nodes.Add(currentNode);
            }

            // Iterate over the path of the file and add child nodes if necessary
            while(!currentNode.FullPath.Equals(file.File.DirectoryName)) {
                bool childFound = false;
                foreach(TreeNode node in currentNode.Nodes) {
                    if(file.File.FullName.StartsWith(node.FullPath + Path.DirectorySeparatorChar)) {
                        currentNode = node;
                        childFound = true;
                        break;
                    }
                }
                if(!childFound) {
                    ResultsTreeViewDirectoryNode newNode = new ResultsTreeViewDirectoryNode(
                        file.File.FullName.Substring(currentNode.FullPath.Length + 1, file.File.FullName.IndexOf(Path.DirectorySeparatorChar, currentNode.FullPath.Length + 1) - currentNode.FullPath.Length - 1));
                    currentNode.Nodes.Add(newNode);
                }
            }

            // Insert the file node
            foreach(TreeNode node in currentNode.Nodes) {
                if(file.File.Name.Equals(node.Name)) {
                    throw new Exception("Error: TreeView: File was already added.");
                }
            }
            ResultsTreeViewFileNode fileNode = new ResultsTreeViewFileNode(file.File.Name, file);
            currentNode.Nodes.Add(fileNode);
        }

        public IList<FolderItem> RootFolders {
            get { return _RootFolders; }
        }
    }
}
