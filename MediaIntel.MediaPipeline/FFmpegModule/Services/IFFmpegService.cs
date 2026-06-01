using MediaIntel.MediaPipeline.FFmpegModule.Models;

namespace MediaIntel.MediaPipeline.FFmpegModule.Services
{
    public interface IFFmpegService
    {
        Task<bool> BurnSubtitlesToVideoAsync(Action<BurnSubtitleRequest> action,
            CancellationToken cancellationToken = default);

        Task<bool> AddSoftSubtitleAsync(Action<BurnSubtitleRequest> action,
            CancellationToken cancellationToken = default);
    }
}