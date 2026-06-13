using System.Text.Json.Serialization;

namespace MediaIntel.MediaPipeline.AIModule.Models
{
    public sealed class SubtitleItem
    {
        [JsonPropertyName("index")]
        public int Index { get; init; }

        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;
    }
}
