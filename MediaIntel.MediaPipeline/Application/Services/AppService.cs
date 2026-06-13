using MediaIntel.MediaPipeline.Application.Models;
using MediaIntel.MediaPipeline.Application.Settings;
using MediaIntel.MediaPipeline.FFmpegModule.Services;
using MediaIntel.MediaPipeline.ScannerModule.Enums;
using MediaIntel.MediaPipeline.ScannerModule.Extensions;
using MediaIntel.MediaPipeline.ScannerModule.Models;
using MediaIntel.MediaPipeline.ScannerModule.Services;
using MediaIntel.MediaPipeline.SubtitlesModule.Translator;

namespace MediaIntel.MediaPipeline.Application.Services
{
    public class AppService
    {
        protected readonly IMediaScannerService _scannerService;
        private readonly IFFmpegService _fFmpegService;
        private readonly ISubtitleTranslatorService _subtitleTranslatorService;
        protected readonly AppSettings settings;

        private CancellationTokenSource cancellationTokenSource;

        public AppService(ServiceFactory serviceFactory)
        {
            _fFmpegService = serviceFactory.CreateFFmpegService();
            _subtitleTranslatorService = serviceFactory.CreateSubtitleTranslatorService();
            _scannerService = serviceFactory.CreateScannerService();
            settings = serviceFactory.Settings;
            cancellationTokenSource = new CancellationTokenSource();
        }

        public void UpdateBatchJob()
        {
            var job = settings.Container.Get<BatchJob>();
            settings.Container.Save(job);
        }

        public int CreateJob(string folderPath, List<BatchAction> actions)
        {
            var job = new BatchJob
            {
                TargetFolderPath = folderPath,
                Steps = actions.Select(action => new JobStep(action)).ToList()
            };

            PrepareNextStep(job);

            if (job.IsFinished)
                return 0;

            settings.Container.Save(job);
            return 1;
        }

        private void PrepareNextStep(BatchJob job)
        {
            while (job.CurrentStepIndex < job.Steps.Count)
            {
                var currentStep = job.Steps[job.CurrentStepIndex];
                currentStep.Data = CreateDataForJobStep(currentStep.Action, job.TargetFolderPath);
                if (currentStep.Data == null || currentStep.IsCompleted)
                {
                    currentStep.IsCompleted = true;
                    job.CurrentStepIndex++;
                    continue;
                }
                break;
            }
        }

        public FolderItem? CreateDataForJobStep(BatchAction action, string folderPath)
        {
            switch (action)
            {
                case BatchAction.BurnSubtitle:
                    return _scannerService.BuildTree(folderPath, ScanMode.PairedMedia);
                case BatchAction.TranslateSubtitle:
                    return _scannerService.BuildTree(folderPath, ScanMode.OnlySubtitles);
                default:
                    return null;
            }
        }

        public FolderItem? LoadDataForView(int currentStepIndex = 0, bool useCustomIndex = false)
        {
            var job = settings.Container.Get<BatchJob>();

            if (job.Steps == null || !job.Steps.Any())
                return null;

            JobStep? jobStep = job.IsFinished
                        ? job.Steps.LastOrDefault()
                        : job.Steps.ElementAtOrDefault(useCustomIndex ? currentStepIndex : job.CurrentStepIndex);

            return jobStep.Data;
        }

        public async Task<bool> RunProcessAsync(Action<VideoSubtitle> action)
        {
            BatchJob job = settings.Container.Get<BatchJob>();

            if (job.IsFinished == true) return false;

            var jobStep = job.Steps[job.CurrentStepIndex];

            VideoSubtitle currentItem = null;

            try
            {
                switch (jobStep.Action)
                {
                    case BatchAction.BurnSubtitle:
                        foreach (var videoSubtitle in jobStep.Data.EnumerateFile(ProcessStatus.NotProcessed))
                        {
                            currentItem = videoSubtitle;
                            videoSubtitle.Status = ProcessStatus.Processing;
                            action(videoSubtitle);
                            var isSuccess = await _fFmpegService.BurnSubtitlesToVideoAsync(styleOptions =>
                            {
                                styleOptions.SubtitleFile = videoSubtitle.Subtitle;
                                styleOptions.InputVideo = videoSubtitle.Video;
                            }, cancellationTokenSource.Token);

                            if (isSuccess)
                            {
                                videoSubtitle.Status = ProcessStatus.Processed;
                                videoSubtitle.TryDeleteSubtitle();
                            }
                        }
                        break;

                    case BatchAction.TranslateSubtitle:
                        foreach (var videoSubtitle in jobStep.Data.EnumerateFile(ProcessStatus.NotProcessed))
                        {
                            currentItem = videoSubtitle;
                            videoSubtitle.Status = ProcessStatus.Processing;
                            action(videoSubtitle);
                            var isSuccess = await _subtitleTranslatorService.ProcessSubtitleInBatchesAsync(videoSubtitle.Subtitle, cancellationTokenSource.Token);
                            if (isSuccess)
                            {
                                videoSubtitle.Status = ProcessStatus.Processed;
                                videoSubtitle.TryDeleteSubtitle();
                            }
                        }
                        break;

                    default:
                        return false;
                }

                jobStep.IsCompleted = true;
                job.CurrentStepIndex++;

                PrepareNextStep(job);

                return true;
            }
            catch
            {
                if (currentItem != null)
                    currentItem.Status = ProcessStatus.NotProcessed;
                throw;
            }
            finally
            {
                settings.Container.Save(job);
            }
        }

        public void CancelProccess()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            cancellationTokenSource = new CancellationTokenSource();
        }
    }
}
