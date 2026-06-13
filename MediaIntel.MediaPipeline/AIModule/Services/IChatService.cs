namespace MediaIntel.MediaPipeline.AIModule.Services
{
    public interface IChatService
    {
        Task<string> SendRequestAsync(IEnumerable<Message> messages, CancellationToken cancellationToken = default);
    }
}
