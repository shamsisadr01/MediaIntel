namespace MediaIntel.MediaPipeline.Application.Settings
{
    public static class FileFormat
    {
        public static readonly HashSet<string> VideoFormats = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".mp4", ".mkv", ".avi", ".mov", ".webm",
            ".flv", ".ts", ".m4v", ".3gp", ".wmv", ".ogv"
        };

        public static readonly HashSet<string> SubtitleFormats = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".srt",
            ".ass",
            ".ssa",
            ".vtt"
        };
    }
}
