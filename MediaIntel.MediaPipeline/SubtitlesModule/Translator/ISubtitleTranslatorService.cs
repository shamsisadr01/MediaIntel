namespace MediaIntel.MediaPipeline.SubtitlesModule.Translator
{
    public interface ISubtitleTranslatorService
    {
        Task<bool> ProcessSubtitleInBatchesAsync(string filePath, CancellationToken cancellationToken);
    }
}