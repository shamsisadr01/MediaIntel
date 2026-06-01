using MediaIntel.MediaPipeline.AIModule.Enums;
using MediaIntel.MediaPipeline.AIModule.Extensions;
using MediaIntel.MediaPipeline.AIModule.Models;
using RestSharp;

namespace MediaIntel.MediaPipeline.AIModule.Providers
{
    public abstract class BaseAiService
    {
        protected readonly RestClient _client;
        protected readonly AiModel _modelAI = AiModel.Gemini25FlashLite;
        protected readonly Language _language;

        protected BaseAiService(AiModelOptions aiModelOptions)
        {
            var options = new RestClientOptions(aiModelOptions.BaseUrl)
            {
                Timeout = TimeSpan.FromSeconds(30),
                UserAgent = "MyAiWrapper/1.0"
            };

            _client = new RestClient(options);

            _client.AddDefaultHeader("Authorization", $"Bearer {aiModelOptions.ApiKey}");
            _language = aiModelOptions.Language;
            _modelAI = aiModelOptions.Model;
        }

        protected string GetPrompt(string text)
        {
            return $@"
            You are a strict subtitle translator. Translate the following text into {_language.ToDisplayName()}.
            CRITICAL RULES:
            1. Translate EXACTLY line-by-line. 
            2. NEVER merge lines, even if a sentence is split across multiple lines. Translate only the exact words present in that specific line.
            3. Every single index tag (e.g., [0], [1], ..., [27]) MUST have its corresponding translated text next to it.
            4. Output exactly the same number of lines as the input.
            {text}";
        }
    }
}
