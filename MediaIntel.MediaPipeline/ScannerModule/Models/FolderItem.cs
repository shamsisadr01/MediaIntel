namespace MediaIntel.MediaPipeline.ScannerModule.Models
{
    public class FolderItem
    {
        public string? DirectoryPath { get; set; }

        public bool IsExpand { get; set; }
        public bool IsSelected { get; set; }

        public List<VideoSubtitle>? Files { get; set; }

        public List<FolderItem>? Folders { get; set; }

        public bool IsProcessed => Files != null && Files.Any(f => f.Status == ProcessStatus.NotProcessed || f.Status == ProcessStatus.Processing);

        public FolderItem? FindFolder(string? path = null)
        {
            if (string.Equals(DirectoryPath, path, StringComparison.OrdinalIgnoreCase))
                return this;

            if (Folders == null || Folders.Count == 0)
                return null;

            foreach (var folder in Folders)
            {
                var result = folder.FindFolder(path);
                if (result != null)
                    return result;
            }

            return null;
        }
    }


}
