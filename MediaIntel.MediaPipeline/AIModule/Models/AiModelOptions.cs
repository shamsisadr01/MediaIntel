using MediaIntel.MediaPipeline.AIModule.Enums;
using MediaIntel.MediaPipeline.AIModule.Services;

namespace MediaIntel.MediaPipeline.AIModule.Models
{
    public class AiModelOptions
    {
        public AiProvider aiProvider { get; set; } = AiProvider.Google;
        public string ApiKey { get; set; } = "None";

        public Language Language { get; set; } = Language.Persian;
        public AiModel Model { get; set; } = AiModel.Gemini25FlashLite;

    }
}
