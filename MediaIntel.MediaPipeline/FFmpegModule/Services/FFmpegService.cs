using FFMpegCore;
using FFMpegCore.Enums;
using MediaIntel.MediaPipeline.Application.Settings;
using MediaIntel.MediaPipeline.FFmpegModule.Extensions;
using MediaIntel.MediaPipeline.FFmpegModule.Models;
using MediaIntel.MediaPipeline.FFmpegModule.SubtitleStyle;

namespace MediaIntel.MediaPipeline.FFmpegModule.Services
{
    public class FFmpegService : IFFmpegService
    {
        private readonly AppSettings _settings;

        public FFmpegService(AppSettings settings)
        {
            _settings = settings;
        }

        public async Task<bool> BurnSubtitlesToVideoAsync(Action<BurnSubtitleRequest> action, CancellationToken cancellationToken = default)
        {
            var options = new BurnSubtitleRequest();
            action(options);
            options.Validate();

            var mediaInfo = await FFProbe.AnalyseAsync(options.InputVideo);
            var subtitleStyleOptions = _settings.Container.Get<SubtitleStyleOptions>();
            var burnOptions = _settings.Container.Get<SubtitleStyleOptions>().Build(options.SubtitleFile);

            return await FFMpegArguments
                .FromFileInput(options.InputVideo)
                .OutputToFile(options.OutputVideo, true, opt => opt
                    .WithVideoFilters(filter => filter.HardBurnSubtitle(burnOptions)))
                //.WithCustomArgument("-crf 0 -preset ultrafast"))
                .NotifyOnProgress(p => _settings.TaskProgress?.Report(p), mediaInfo.Duration)
                .CancellableThrough(cancellationToken)
                .ProcessAsynchronously();
        }

        public async Task<bool> AddSoftSubtitleAsync(Action<BurnSubtitleRequest> action, CancellationToken cancellationToken = default)
        {
            var burnSubtitleOptions = new BurnSubtitleRequest();
            action(burnSubtitleOptions);
            burnSubtitleOptions.Validate();

            var mediaInfo = await FFProbe.AnalyseAsync(burnSubtitleOptions.InputVideo);
            var duration = mediaInfo.Duration;

            var allIndexes = mediaInfo.VideoStreams.Select(v => v.Index)
                .Concat(mediaInfo.AudioStreams.Select(a => a.Index))
                .Concat(mediaInfo.SubtitleStreams.Select(s => s.Index));

            string ext = Path.GetExtension(burnSubtitleOptions.OutputVideo).ToLower();

            return await FFMpegArguments
                 .FromFileInput(burnSubtitleOptions.InputVideo)
                 .AddFileInput(burnSubtitleOptions.SubtitleFile)
                 .OutputToFile(burnSubtitleOptions.OutputVideo, true, options => options
                   .SelectStreams(allIndexes)
                   .SelectStream(0, 1, Channel.Subtitle)
                   .WithVideoCodec("copy")
                   .WithAudioCodec("copy")
                   .WithSubtitleCodec(ext)
                   .WithCustomArgument("-metadata:s:s:0 language=fa")
                   .WithCustomArgument("-disposition:s:0 default")
                   )
                   .NotifyOnProgress(progressPercent =>
                   {
                       _settings.TaskProgress?.Report(progressPercent);
                   }, duration)
                  .CancellableThrough(cancellationToken)
                 .ProcessAsynchronously();
        }
    }
}
