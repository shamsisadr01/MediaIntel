using MediaIntel.MediaPipeline.AIModule.Helpers;
using MediaIntel.MediaPipeline.AIModule.Models;
using System.Text.Json;

namespace MediaIntel.MediaPipeline.AIModule.Services
{
    public class LlmTranslationService
    {
        private IChatService _chatService;
        public string Language { get; init; }
        private int maxRetryCount = 5;
        private int batchSize = 25;
        private int delayTimeMs = 5000;
        private int MaxHistoryMessages = 2;
        private List<Message> chatHistory = new List<Message>();

        public LlmTranslationService(IChatService chatService, string language)
        {
            _chatService = chatService;
            Language = language;
        }

        public async Task TranslateSubtitlesInBatchesAsync(SubtitleItem[] subtitles, Func<TranslationBatchResult, Task> onBatchTranslatedAsync, CancellationToken cancellationToken)
        {
            chatHistory.Clear();
            int startIndex = 0;
            List<Task>? callbackTasks = new List<Task>();
            foreach (var subtitleBatch in subtitles.Chunk(batchSize))
            {
                cancellationToken.ThrowIfCancellationRequested();
                var translatedLines = await TranslateSubtitleBatchAsync(subtitleBatch, cancellationToken);

                if (onBatchTranslatedAsync is not null)
                {
                    var result = new TranslationBatchResult(startIndex, translatedLines);
                    callbackTasks.Add(onBatchTranslatedAsync(result));
                }
                startIndex += subtitleBatch.Length;
            }

            await Task.WhenAll(callbackTasks);
        }

        private async Task<string[]> TranslateSubtitleBatchAsync(SubtitleItem[] batch, CancellationToken cancellationToken)
        {
            var messages = BuildMessages(batch);

            for (int i = 0; i < maxRetryCount; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var translatedText = await _chatService.SendRequestAsync(messages, cancellationToken);
                watch.Stop();

                var translatedLines = TryParseJsonTranslation(translatedText, batch.Length);

                int remainingDelay = delayTimeMs - (int)watch.ElapsedMilliseconds;

                if (remainingDelay > 0)
                {
                    await Task.Delay(remainingDelay, cancellationToken);
                }


                if (translatedLines is not null)
                {
                    chatHistory.Add(new Message(MessageType.AI, translatedText));
                    return translatedLines;
                }
            }

            throw new Exception("Translation failed after maximum retry attempts.");


        }


        private string[]? TryParseJsonTranslation(string translatedText, int size)
        {
            try
            {
                var cleanJson = translatedText.Trim();
                var items = JsonSerializer.Deserialize<SubtitleItem[]>(cleanJson);
                if (items is null)
                    return null;

                if (items.Length != size)
                    return null;

                for (int i = 0; i < items.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(items[i].Text))
                        return null;
                }
                return items.Select(x => x.Text).ToArray();
            }
            catch
            {
                return null;
            }
        }

        private List<Message> BuildMessages(SubtitleItem[] batch)
        {
            var systemMessage = new Message(MessageType.System, TranslationPromptHelper.BuildSystemPrompt(Language));

            var userJson = JsonSerializer.Serialize(batch);
            var userMessage = new Message(MessageType.User, userJson);

            if (chatHistory.Count > MaxHistoryMessages)
            {
                chatHistory.RemoveRange(0, chatHistory.Count - MaxHistoryMessages);
            }
            chatHistory.Add(userMessage);

            return new List<Message> { systemMessage }.Concat(chatHistory).ToList();
        }
    }
}
