using MediaIntel.MediaPipeline.AIModule.Models;
using MediaIntel.MediaPipeline.AIModule.Services;
using MediaIntel.MediaPipeline.SubtitlesModule.Extensions;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Core.SubtitleFormats;

namespace MediaIntel.MediaPipeline.SubtitlesModule.Translator
{
    public class SubtitleTranslatorService : ISubtitleTranslatorService
    {
        private readonly LlmTranslationService translationService;
        private readonly IProgress<double> progress;


        public SubtitleTranslatorService(IProgress<double> progress, LlmTranslationService translationService)
        {
            this.progress = progress;
            this.translationService = translationService;
        }

        public async Task<bool> ProcessSubtitleInBatchesAsync(string filePath, CancellationToken cancellationToken)
        {
            if (!File.Exists(filePath))
                return false;

            var newFilePath = SubtitleExtensions.GetLocalizedFilePath(filePath, translationService.Language);

            try
            {
                var subtitle = Subtitle.Parse(filePath);

                var subtitleItems = subtitle.Paragraphs.Select(p => new SubtitleItem
                {
                    Index = p.Number,
                    Text = p.Text
                }).ToArray();


                int processedCount = 0;
                await translationService.TranslateSubtitlesInBatchesAsync(subtitleItems, async batch =>
                {
                    for (int i = 0; i < batch.TranslatedLines.Length; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        subtitle.Paragraphs[batch.StartIndex + i].Text = SubtitleExtensions.ApplyRtlEmbedding(batch.TranslatedLines[i]);
                        int currentProcessed = Interlocked.Increment(ref processedCount);
                        progress?.Report((processedCount / (double)subtitleItems.Length) * 100d);
                        await Task.Delay(150, cancellationToken);
                    }
                }, cancellationToken);

                var extension = Path.GetExtension(filePath);
                string finalText = extension.ToLowerInvariant() switch
                {
                    ".srt" => subtitle.ToText(new SubRip()),
                    ".vtt" => subtitle.ToText(new WebVTT()),
                    ".ass" => subtitle.ToText(new AdvancedSubStationAlpha()),
                    ".ssa" => subtitle.ToText(new SubStationAlpha()),
                    _ => throw new Exception($"Unsupported subtitle format: {extension}")
                };

                await File.WriteAllTextAsync(newFilePath, finalText);
                return true;
            }
            catch (Exception e)
            {
                SubtitleExtensions.TryDeleteFile(newFilePath);
                throw new Exception(Path.GetFileName(filePath) + " ===> " + e.Message);
            }
        }

    }
}
