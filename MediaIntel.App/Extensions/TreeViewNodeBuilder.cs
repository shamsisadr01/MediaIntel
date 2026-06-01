using MediaIntel.MediaPipeline.ScannerModule.Extensions;
using MediaIntel.MediaPipeline.ScannerModule.Models;

namespace MediaIntel.App.Extensions
{
    public static class TreeViewNodeBuilder
    {
        public static TreeNode CreateTreeNodeFromFolder(FolderItem folder, Action<TreeNode> action)
        {
            var folderName = LRE + folder.DirectoryPath.GetFileFullName() + PDF;
            var node = new TreeNode(folderName)
            {
                Tag = folder
            };

            if (folder.IsExpand)
                node.Expand();

            if (folder.IsSelected)
            {
                action(node);
            }

            if (folder.Folders != null)
            {
                foreach (var subFolder in folder.Folders)
                    node.Nodes.Add(CreateTreeNodeFromFolder(subFolder, action));
            }
            return node;
        }

        private const string LRE = "\u202A";
        private const string PDF = "\u202C";
    }
}
