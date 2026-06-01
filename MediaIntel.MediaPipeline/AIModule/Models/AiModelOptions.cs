using MediaIntel.MediaPipeline.AIModule.Enums;

namespace MediaIntel.MediaPipeline.AIModule.Models
{
    public class AiModelOptions
    {

        public string BaseUrl { get; set; } = "https://api.gapgpt.app/v1/responses";
        public string ApiKey { get; set; } = string.Empty;

        public Language Language { get; set; } = Language.Persian;
        public AiModel Model { get; set; } = AiModel.Gemini25FlashLite;
    }
}
