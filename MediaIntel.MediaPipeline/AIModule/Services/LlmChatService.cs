using Google.GenAI;
using MediaIntel.MediaPipeline.AIModule.Enums;
using MediaIntel.MediaPipeline.AIModule.Extensions;
using MediaIntel.MediaPipeline.AIModule.Helpers;
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

namespace MediaIntel.MediaPipeline.AIModule.Services
{
    public class LlmChatService : IChatService
    {
        private readonly IChatClient _chatClient;

        public LlmChatService(AiProvider provider,string apiKey, string modelId)
        {
            _chatClient = CreateClient(provider, apiKey, modelId);
        }

        private IChatClient CreateClient(AiProvider provider, string apiKey, string model)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                apiKey = "None";

            switch (provider)
            {
                case AiProvider.OpenAI:
                    return new OpenAIClient(
                        new ApiKeyCredential(apiKey)
                    ).GetChatClient(model).AsIChatClient();

                case AiProvider.OpenRouter:
                    return new OpenAIClient(
                        new ApiKeyCredential(apiKey),
                        new OpenAIClientOptions
                        {
                            Endpoint = new Uri("https://openrouter.ai/api/v1")
                        })
                        .GetChatClient(model)
                        .AsIChatClient();
                case AiProvider.Groq:
                    return new OpenAIClient(
                        new ApiKeyCredential(apiKey),
                        new OpenAIClientOptions
                        {
                            Endpoint = new Uri("https://api.groq.com/openai/v1")
                        })
                        .GetChatClient(model)
                        .AsIChatClient();

                case AiProvider.Gapgpt:
                    return new OpenAIClient(
                        new ApiKeyCredential(apiKey),
                        new OpenAIClientOptions
                        {
                            Endpoint = new Uri("https://api.gapgpt.app/v1/")
                        })
                        .GetChatClient(model)
                        .AsIChatClient();

                case AiProvider.Google:
                    return new Client(apiKey: apiKey)
                        .AsIChatClient(model);

                default:
                    throw new NotSupportedException();
            }
        }



        public async Task<string> SendRequestAsync(IEnumerable<Message> messages, CancellationToken cancellationToken = default)
        {
            var chatMessages = messages.Select(m => new ChatMessage(m.messageType.ToChatRole(), m.context));

            var chatResponse = await _chatClient.GetResponseAsync(chatMessages,
            new ChatOptions
            {
                ResponseFormat = new ChatResponseFormatJson(
                    schema: TranslationSchemaHelper.SubtitleSchema,
                    schemaName: "subtitle_translation",
                    schemaDescription: "Translate subtitles preserving structure"
                ),
            },
            cancellationToken);
            return chatResponse.Text;
        }
    }

    public static class MessageExtensions
    {
        public static ChatRole ToChatRole(this MessageType type) => type switch
        {
            MessageType.System => ChatRole.System,
            MessageType.User => ChatRole.User,
            _ => ChatRole.Assistant
        };
    }

    public enum AiProvider
    {
        OpenAI,
        OpenRouter,
        Groq,
        Google,
        Gapgpt
    }

}
