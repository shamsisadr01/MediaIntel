using MediaIntel.MediaPipeline.Application.Settings;

namespace MediaIntel.MediaPipeline.FFmpegModule.Models
{

    public class BurnSubtitleRequest
    {
        public string InputVideo { get; set; }
        public string SubtitleFile { get; set; }
        public string OutputVideo { get; set; }

        public void Validate()
        {
            // Required checks
            if (string.IsNullOrWhiteSpace(InputVideo))
                throw new ArgumentException("InputVideo is required.", nameof(InputVideo));

            if (string.IsNullOrWhiteSpace(SubtitleFile))
                throw new ArgumentException("SubtitleFile is required.", nameof(SubtitleFile));

            // Normalize paths (optional but recommended)
            InputVideo = Path.GetFullPath(InputVideo);
            SubtitleFile = Path.GetFullPath(SubtitleFile);

            // File existence checks
            if (!File.Exists(InputVideo))
                throw new FileNotFoundException("Input video file not found.", InputVideo);

            if (!File.Exists(SubtitleFile))
                throw new FileNotFoundException("Subtitle file not found.", SubtitleFile);

            var subExt = Path.GetExtension(SubtitleFile).ToLowerInvariant();
            if (!FileFormat.SubtitleFormats.Contains(subExt))
            {
                throw new NotSupportedException(
                    $"Unsupported subtitle format: {subExt}. Supported: {string.Join(", ", FileFormat.VideoFormats)}");
            }

            var videoExt = Path.GetExtension(InputVideo).ToLowerInvariant();
            if (!FileFormat.VideoFormats.Contains(videoExt))
            {
                throw new NotSupportedException(
                    $"Unsupported video format: {videoExt}. Supported: {string.Join(", ", FileFormat.SubtitleFormats)}");
            }

            // Output handling
            if (string.IsNullOrWhiteSpace(OutputVideo))
            {
                var dir = Path.GetDirectoryName(InputVideo)!;
                var name = Path.GetFileNameWithoutExtension(InputVideo);
                var ext = Path.GetExtension(InputVideo);

                OutputVideo = Path.Combine(dir, $"{name}.subburn{ext}");
            }
            else
            {
                OutputVideo = Path.GetFullPath(OutputVideo);
            }

            // Prevent accidental overwrite
            if (string.Equals(InputVideo, OutputVideo, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("OutputVideo must be different from InputVideo.", nameof(OutputVideo));

            Directory.CreateDirectory(Path.GetDirectoryName(OutputVideo)!);
        }
    }


}
