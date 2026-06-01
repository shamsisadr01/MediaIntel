namespace MediaIntel.MediaPipeline.FFmpegModule.SubtitleStyle
{
    /// <summary>
    /// Alignment values for ASS subtitles (used in FFmpeg force_style).
    /// Numbering starts from bottom-left (1) to top-right (9).
    /// </summary>
    public enum SubtitleAlignment
    {
        /// <summary>Bottom left (پایین چپ)</summary>
        BottomLeft = 1,

        /// <summary>Bottom center (پایین وسط) - معمول‌ترین حالت زیرنویس</summary>
        BottomCenter = 2,

        /// <summary>Bottom right (پایین راست) - مناسب برای فارسی راست‌چین</summary>
        BottomRight = 3,

        /// <summary>Middle left (وسط چپ)</summary>
        MiddleLeft = 4,

        /// <summary>Middle center (وسط وسط)</summary>
        MiddleCenter = 5,

        /// <summary>Middle right (وسط راست)</summary>
        MiddleRight = 6,

        /// <summary>Top left (بالا چپ)</summary>
        TopLeft = 7,

        /// <summary>Top center (بالا وسط)</summary>
        TopCenter = 8,

        /// <summary>Top right (بالا راست)</summary>
        TopRight = 9
    }

}
