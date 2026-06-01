using MediaIntel.MediaPipeline.AIModule;
using MediaIntel.MediaPipeline.Application.Settings;
using MediaIntel.MediaPipeline.SubtitlesModule.Extensions;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Core.SubtitleFormats;
using System.Text.RegularExpressions;

namespace MediaIntel.MediaPipeline.SubtitlesModule.Translator
{
    public class SubtitleTranslatorService : ISubtitleTranslatorService
    {
        private readonly IAiService _aiService;
        private readonly int maxRetryCount;
        private readonly string language;
        private readonly IProgress<double> progress;

        public SubtitleTranslatorService(IAiService aiService, IProgress<double> progress = null, string language = "fa", int maxRetryCount = 3)
        {
            _aiService = aiService;
            this.maxRetryCount = maxRetryCount;
            this.language = language;
            this.progress = progress;
        }

        public async Task<bool> ProcessSubtitleInBatchesAsync(string filePath, CancellationToken cancellationToken)
        {
            if (!Path.Exists(filePath))
                return false;

            var newFilePath = SubtitleExtensions.GetLocalizedFilePath(filePath, language);

            try
            {
                var subtitle = Subtitle.Parse(filePath);

                var sentences = SubtitleExtensions.SentenceDetection(subtitle.Paragraphs);
                int maxCount = subtitle.Paragraphs.Count;
                int index = 0;
                foreach (var sentence in sentences)
                {
                    var inputText = string.Join("\n",
                              sentence.Select((l, i) => $"[{i}] {l.Text}")
                      );


                    index += sentence.Count;
                    progress?.Report((index * 100) / maxCount);

                    cancellationToken.ThrowIfCancellationRequested();

                    var lines = await TranslateSubtitleRangeAsync(inputText, sentence.Count,cancellationToken);
                    for (int i = 0; i < sentence.Count; i++)
                    {
                        sentence[i].Text = SubtitleExtensions.ApplyRtlEmbedding(lines[i]);
                    }
             
                }

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


        private async Task<string[]> TranslateSubtitleRangeAsync(string inputText, int count, CancellationToken cancellationToken = default, int retryCount = 0)
        {
            var translatedText = await _aiService.SendRequsetAsync(inputText, cancellationToken);

            string pattern = @"(?:^|\r?\n)\[\d+\]\s*";
            string[] translatedLines = Regex.Split(translatedText, pattern)
                                .Where(s => !string.IsNullOrWhiteSpace(s))
                                .ToArray();

            if (count != translatedLines.Length)
            {
                if (retryCount >= maxRetryCount)
                {
                    throw new Exception(
                        $"Translation failed after {maxRetryCount} retries because the translated segment count did not match."
                    );
                }

                return await TranslateSubtitleRangeAsync(inputText, count,cancellationToken, retryCount + 1);
            }

            return translatedLines;
        }
    }
}
