using MediaIntel.MediaPipeline.ScannerModule.Extensions;
using System.ComponentModel;
using System.Reflection;

namespace MediaIntel.MediaPipeline.ScannerModule.Models
{
    public sealed class VideoSubtitle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        [Browsable(false)]
        public string? Video { get; set; }

        [Browsable(false)]
        public string? Subtitle { get; set; }

        [DisplayName("Video Name")]
        [HideColumnIfAllNullAttribute]
        public string VideoName => Video!.GetFileFullName();

        [DisplayName("Subtitle Name")]
        [HideColumnIfAllNullAttribute]
        public string SubtitleName => Subtitle!.GetFileFullName();


        private ProcessStatus status = ProcessStatus.NotProcessed;
        [Browsable(false)]
        public ProcessStatus Status
        {
            get => status;
            set
            {
                if (status != value)
                {
                    status = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProcessStatusText)));
                }
            }
        }

        [DisplayName("Status")]
        public string ProcessStatusText => Status.GetDescription();


        public VideoSubtitle(string? videoPath, string? subtitlePath)
        {
            Video = videoPath;
            Subtitle = subtitlePath;
        }

        public void TryDeleteSubtitle()
        {
            if (Subtitle != null)
            {
                if (File.Exists(Subtitle))
                    File.Delete(Subtitle);
            }
            if (Video != null)
            {
                if (File.Exists(Video))
                    File.Delete(Video);
            }
        }
    }

    public enum ProcessStatus
    {
        [Description("Not Processed")]
        NotProcessed = 0,

        [Description("Processing")]
        Processing = 1,

        [Description("Processed")]
        Processed = 2
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class HideColumnIfAllNullAttribute : Attribute
    {
    }

}
