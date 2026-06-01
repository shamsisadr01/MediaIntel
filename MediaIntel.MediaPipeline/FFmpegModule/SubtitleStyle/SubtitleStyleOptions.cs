using FFMpegCore.Arguments;
using System.Drawing;

namespace MediaIntel.MediaPipeline.FFmpegModule.SubtitleStyle
{
    public class SubtitleStyleOptions
    {
        public string FontName { get; set; } = "Segoe UI";
        public int FontSize { get; set; } = 17;

        public Color TextColor { get; set; } = Color.White;
        public Color OutlineColor { get; set; } = Color.Empty;
        public Color BackColor { get; set; } = Color.FromArgb(100, Color.Black);
        public int Outline { get; set; } = 1;
        public int Shadow { get; set; } = 0;
        public SubtitleAlignment Alignment { get; set; } = SubtitleAlignment.BottomCenter;

        public int MarginL { get; set; } = 0;
        public int MarginR { get; set; } = 0;
        public int MarginV { get; set; } = 12;
        public int Bold { get; set; } = -1;

        public SubtitleHardBurnOptions Build(string subtitleFile)
        {
            var style = StyleOptions.Create()
                .WithParameter("FontName", FontName)
                .WithParameter("FontSize", FontSize.ToString())
                .WithParameter("BorderStyle", "4")
                .WithParameter("Bold", Bold.ToString())
                .WithParameter("PrimaryColour", ToAssColor(TextColor))
                .WithParameter("OutlineColour", ToAssColor(OutlineColor))
                .WithParameter("BackColour", ToAssColor(BackColor))
                .WithParameter("Outline", Outline.ToString())
                .WithParameter("Shadow", Shadow.ToString())
                .WithParameter("Alignment", ((int)Alignment).ToString())
                .WithParameter("MarginL", MarginL.ToString())
                .WithParameter("MarginR", MarginR.ToString())
                .WithParameter("MarginV", MarginV.ToString());

            return SubtitleHardBurnOptions
              .Create(subtitleFile)
              .SetCharacterEncoding("UTF-8")
              .WithStyle(style);
        }

        private static string ToAssColor(Color c)
        {
            byte assAlpha = (byte)(255 - c.A); // ASS alpha is inverted
            return $"&H{assAlpha:X2}{c.B:X2}{c.G:X2}{c.R:X2}";
        }
    }

}
