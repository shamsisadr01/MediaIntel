using System.Text.Json;

namespace MediaIntel.MediaPipeline.AIModule.Helpers
{
    public static class TranslationSchemaHelper
    {
        public static readonly JsonElement SubtitleSchema = JsonElement.Parse("""
        {
          "type": "array",
          "items": {
            "type": "object",
            "properties": {
              "index": { "type": "integer" },
              "text": { "type": "string" }
            },
            "required": ["index", "text"],
            "additionalProperties": false
          }
        }
        """);
    }
}
