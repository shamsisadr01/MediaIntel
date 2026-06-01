using MediaIntel.MediaPipeline.AIModule.Models;
using MediaIntel.MediaPipeline.FFmpegModule.SubtitleStyle;

namespace MediaIntel.MediaPipeline.Application.Settings
{
    public class AppSettings
    {
        public SettingsContainer Container { get; set; }

        public IProgress<double> TaskProgress { get; set; }

        public AppSettings()
        {
            Container = new SettingsContainer();
        }

        public void DeleteAllSettings()
        {
            Container.Delete<AiModelOptions>();
            Container.Delete<SubtitleStyleOptions>();
        }
    }

}
