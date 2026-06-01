namespace MediaIntel.MediaPipeline.Application.Settings
{
    public class SettingsContainer
    {
        private readonly Dictionary<Type, object> _cache = new();

        public T Get<T>() where T : class, new()
        {
            if (!_cache.TryGetValue(typeof(T), out var value))
            {
                value = SettingsStorage.LoadFromFile<T>();
                _cache[typeof(T)] = value;
            }
            return (T)value;
        }

        public void Set<T>(T value)
        {
            _cache[typeof(T)] = value;
        }


        public T Save<T>(T value)
        {
            SettingsStorage.SaveToFile(value);
            _cache[typeof(T)] = value;
            return value;
        }

        public void Delete<T>()
        {
            if (_cache.ContainsKey(typeof(T)))
            {
                _cache.Remove(typeof(T));
            }

            SettingsStorage.DeleteFile<T>();
        }
    }
}
