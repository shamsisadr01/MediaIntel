namespace MediaIntel.MediaPipeline.AIModule
{
    public class AiServiceResolver
    {
        private readonly IEnumerable<IAiService> _services;

        public AiServiceResolver(IEnumerable<IAiService> services)
        {
            _services = services;
        }

        public IAiService GetProvider(string name)
        {
            return _services.FirstOrDefault(s => s.ProviderName == name)
                   ?? throw new Exception("Provider not found");
        }
    }
}
