using MediaIntel.MediaPipeline.ScannerModule.Models;

namespace MediaIntel.MediaPipeline.ScannerModule.Extensions
{
    public static class FolderExtensions
    {
        public static IEnumerable<VideoSubtitle> EnumerateFile(this FolderItem root, params ProcessStatus[] statuses)
        {
            if (root is null) yield break;

            bool HasStatus(ProcessStatus status) => statuses == null || statuses.Length == 0 || statuses.Contains(status);

            if (root.Files is not null)
            {
                foreach (var media in root.Files)
                {
                    if (HasStatus(media.Status))
                        yield return media;
                }
            }

            if (root.Folders is not null)
            {
                foreach (var child in root.Folders)
                {
                    if (root.IsProcessed == false)
                    {
                        foreach (var media in child.EnumerateFile())
                            yield return media;
                    }
                }
            }
        }
    }

}
