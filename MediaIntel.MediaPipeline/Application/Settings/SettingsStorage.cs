using Newtonsoft.Json;

namespace MediaIntel.MediaPipeline.Application.Settings
{
    public class SettingsStorage
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Error = (sender, args) => { args.ErrorContext.Handled = true; },
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto
        };

        public static void SaveToFile<T>(T folderInfo)
        {
            var fileName = GetPath(typeof(T).Name + ".json");
            string json = JsonConvert.SerializeObject(folderInfo, Settings);
            File.WriteAllText(fileName, json);
        }

        public static T LoadFromFile<T>() where T : class, new()
        {
            var fileName = GetPath(typeof(T).Name + ".json");
            if (!File.Exists(fileName))
            {
                var newInstance = new T();
                SaveToFile(newInstance);
                return newInstance;
            }
            string json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<T>(json, Settings) ?? new T();
        }

        public static void DeleteFile<T>()
        {
            var fileName = GetPath(typeof(T).Name + ".json");
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        private static string GetPath(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), fileName);
        }
    }
}
