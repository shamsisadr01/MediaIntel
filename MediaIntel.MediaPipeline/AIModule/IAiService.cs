namespace MediaIntel.MediaPipeline.AIModule
{
    public interface IAiService
    {
        string ProviderName { get; }
        Task<string> SendRequsetAsync(string prompt, CancellationToken cancellationToken = default);
    }
}
