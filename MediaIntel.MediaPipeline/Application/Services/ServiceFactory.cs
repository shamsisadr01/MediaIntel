using MediaIntel.MediaPipeline.AIModule.Extensions;
using MediaIntel.MediaPipeline.AIModule.Models;
using MediaIntel.MediaPipeline.AIModule.Providers;
using MediaIntel.MediaPipeline.Application.Settings;
using MediaIntel.MediaPipeline.FFmpegModule.Services;
using MediaIntel.MediaPipeline.ScannerModule.Services;
using MediaIntel.MediaPipeline.SubtitlesModule.Translator;

namespace MediaIntel.MediaPipeline.Application.Services
{
    public class ServiceFactory
    {
        private readonly AppSettings _settings;
        public AppSettings Settings { get { return _settings; } }

        public ServiceFactory(AppSettings settings)
        {
            _settings = settings;
        }

        public IMediaScannerService CreateScannerService()
        {
            return new MediaScannerService();
        }

        public IFFmpegService CreateFFmpegService()
        {
            return new FFmpegService(_settings);
        }

        public ISubtitleTranslatorService CreateSubtitleTranslatorService()
        {
            var modelOptions = _settings.Container.Get<AiModelOptions>();
            var gapgptService = new GapgptService(modelOptions);
            return new SubtitleTranslatorService(gapgptService, _settings.TaskProgress, modelOptions.Language.ToLanguageCode());
        }
    }

}
