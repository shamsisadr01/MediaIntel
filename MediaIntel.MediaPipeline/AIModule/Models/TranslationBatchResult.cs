namespace MediaIntel.MediaPipeline.AIModule.Models
{
    public sealed class TranslationBatchResult
    {
        public int StartIndex { get; }
        public string[] TranslatedLines { get; }

        public TranslationBatchResult(int startIndex, string[] translatedLines)
        {
            StartIndex = startIndex;
            TranslatedLines = translatedLines;
        }
    }
}
