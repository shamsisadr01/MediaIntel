using FFMpegCore;

namespace MediaIntel.MediaPipeline.FFmpegModule.Extensions
{
    public static class FFmpegExtensions
    {
        public static FFMpegArgumentOptions WithSubtitleCodec(
            this FFMpegArgumentOptions options, string ext)
        {
            string codec = ext switch
            {
                ".mp4" or ".mov" => "mov_text",
                ".webm" => "webvtt",
                _ => "srt"
            };
            return options.WithCustomArgument($"-c:s {codec}");
        }
    }
}
