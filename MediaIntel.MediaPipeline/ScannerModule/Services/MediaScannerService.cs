using MediaIntel.MediaPipeline.Application.Settings;
using MediaIntel.MediaPipeline.ScannerModule.Enums;
using MediaIntel.MediaPipeline.ScannerModule.Extensions;
using MediaIntel.MediaPipeline.ScannerModule.Models;

namespace MediaIntel.MediaPipeline.ScannerModule.Services
{
    public class MediaScannerService : IMediaScannerService
    {

        public FolderItem BuildTree(string rootPath, ScanMode mode = ScanMode.PairedMedia)
        {
            var rootNode = new FolderItem
            {
                DirectoryPath = rootPath,
            };

            var stats = new ScanStatistics();
            BuildChildren(rootNode, mode, stats);

            return rootNode;
        }

        private static bool BuildChildren(FolderItem parentNode, ScanMode mode, ScanStatistics stats)
        {
            if (stats.ShouldStop)
                return false;

            bool hasAnyFile = false;
            try
            {
                stats.ScannedFolders++;

                stats.CheckLimit();

                var files = Directory.EnumerateFiles(parentNode.DirectoryPath);

                stats.ScannedFiles += files.Count();

                List<VideoSubtitle> localFiles = new List<VideoSubtitle>();
                if (mode == ScanMode.OnlyVideos)
                {
                    var videos = files.Where(f => FileFormat.VideoFormats.Contains(Path.GetExtension(f)));
                    foreach (var video in videos)
                        localFiles.Add(new VideoSubtitle(video, null));
                }
                else if (mode == ScanMode.OnlySubtitles)
                {
                    var subtitles = files.Where(f => FileFormat.SubtitleFormats.Contains(Path.GetExtension(f)));
                    foreach (var subtitle in subtitles)
                        localFiles.Add(new VideoSubtitle(null, subtitle));
                }
                else
                {
                    var videos = files.Where(f => FileFormat.VideoFormats.Contains(Path.GetExtension(f)));
                    var subtitles = files.Where(f => FileFormat.SubtitleFormats.Contains(Path.GetExtension(f)));
                    foreach (var video in videos)
                    {
                        string videoName = video.GetFileName();
                        var subtitle = subtitles.FirstOrDefault(s =>
                        {
                            var subBase = s.GetFileName();
                            return string.Equals(subBase, videoName, StringComparison.OrdinalIgnoreCase)
                                || subBase.StartsWith(videoName, StringComparison.OrdinalIgnoreCase);
                        });

                        if (subtitle != null)
                            localFiles.Add(new VideoSubtitle(video, subtitle));
                    }
                }

                if (localFiles.Any())
                {
                    parentNode.Files = localFiles;
                    stats.MatchedFiles += localFiles.Count;
                    hasAnyFile = true;
                }

                var directories = Directory.EnumerateDirectories(parentNode.DirectoryPath);
                foreach (var dir in directories)
                {
                    var dirNode = new FolderItem { DirectoryPath = dir };

                    if (BuildChildren(dirNode, mode, stats))
                    {
                        if (parentNode.Folders == null) parentNode.Folders = new List<FolderItem>();
                        parentNode.Folders.Add(dirNode);
                        stats.MatchedFolders++;
                        hasAnyFile = true;
                    }
                }
            }
            catch
            {
                // throw;
            }

            return hasAnyFile;
        }
    }
}
