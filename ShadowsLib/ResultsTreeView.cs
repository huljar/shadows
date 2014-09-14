using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Etier.IconHelper;

namespace ShadowsLib {
    public class ResultsTreeView : System.Windows.Forms.TreeView {

        private IList<FolderItem> _RootFolders = new List<FolderItem>();
        private IconListManager _IconManager;

        private ContextMenuStrip dirNodeMenu = null;
        private ContextMenuStrip fileNodeMenu = null;

        public ResultsTreeView()
            : base() {
            PathSeparator = Path.DirectorySeparatorChar.ToString();
            ImageList = new ImageList();
            ImageList.ColorDepth = ColorDepth.Depth32Bit; // makes icons prettier
            _IconManager = new IconListManager(ImageList, IconReader.IconSize.Small);
            ImageList.Images.Add(IconReader.GetFolderIcon(IconReader.IconSize.Small, IconReader.FolderType.Closed));
            ImageList.Images.Add(IconReader.GetFolderIcon(IconReader.IconSize.Small, IconReader.FolderType.Open)); // TODO: support special directory icons?
        }

        public void AddShadow(IList<FileInfoWrapper> shadowSet) {
            BeginUpdate();
            foreach(FileInfoWrapper file in shadowSet) {
                InsertFileNode(file, shadowSet);
            }
            Sort();
            EndUpdate();
        }

        public void SetDirNodeMenu(ContextMenuStrip menuStrip) {
            dirNodeMenu = menuStrip;
        }

        public void SetFileNodeMenu(ContextMenuStrip menuStrip) {
            fileNodeMenu = menuStrip;
        }

        public void Reset() {
            BeginUpdate();
            Nodes.Clear();
            RootFolders.Clear();
            EndUpdate();
        }

        private void InsertFileNode(FileInfoWrapper file, IList<FileInfoWrapper> shadowSet) {
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
            ResultsTreeViewNode currentNode = null;
            foreach(TreeNode node in Nodes) {
                if(node.Name.Equals(root.Node.Path)) {
                    currentNode = (ResultsTreeViewNode)node;
                    break;
                }
            }
            // Add root node if it does not exist yet
            if(currentNode == null) {
                currentNode = new ResultsTreeViewDirectoryNode(root.Node.Path, 0, 1, new DirectoryInfo(root.Node.Path));
                currentNode.ContextMenuStrip = dirNodeMenu;
                Nodes.Add(currentNode);
            }

            // Iterate over the path of the file and add child nodes if necessary
            while(!currentNode.FullPathByName.Equals(file.File.DirectoryName)) {
                bool childFound = false;
                foreach(ResultsTreeViewNode node in currentNode.Nodes) {
                    if(file.File.FullName.StartsWith(node.FullPathByName + Path.DirectorySeparatorChar)) {
                        currentNode = node;
                        childFound = true;
                        break;
                    }
                }
                if(!childFound) {
                    string path = currentNode.FullPathByName;
                    ResultsTreeViewNode newNode = new ResultsTreeViewDirectoryNode(
                        file.File.FullName.Substring(path.Length + 1, file.File.FullName.IndexOf(Path.DirectorySeparatorChar, path.Length + 1) - (path.Length + 1)),
                        0, 1,
                        new DirectoryInfo(file.File.FullName.Substring(0, file.File.FullName.IndexOf(Path.DirectorySeparatorChar, path.Length + 1))));
                    newNode.ContextMenuStrip = dirNodeMenu;
                    currentNode.Nodes.Add(newNode);
                }
            }

            // Insert the file node
            foreach(TreeNode node in currentNode.Nodes) {
                if(file.File.Name.Equals(node.Name)) {
                    throw new Exception("Error: TreeView: File was already added.");
                }
            }
            int iconIndex = _IconManager.AddFileIcon(file.File.FullName);
            ResultsTreeViewNode fileNode = new ResultsTreeViewFileNode(file.File.Name, iconIndex, iconIndex, file, shadowSet);
            fileNode.ContextMenuStrip = fileNodeMenu;
            currentNode.Nodes.Add(fileNode);

            // Update the texts of all parent/grandparent etc. nodes of the new file node
            for(TreeNode parent = currentNode; parent != null; parent = parent.Parent) {
                ResultsTreeViewDirectoryNode dirNode = parent as ResultsTreeViewDirectoryNode;
                if(dirNode != null) {
                    dirNode.UpdateText(true);
                }
            }
        }

        public IList<FolderItem> RootFolders {
            get { return _RootFolders; }
        }

        public IconListManager IconManager {
            get { return _IconManager; }
        }
    }
}
