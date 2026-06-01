using MediaIntel.MediaPipeline.AIModule.Enums;

namespace MediaIntel.MediaPipeline.AIModule.Extensions
{
    public static class LanguageExtensions
    {
        public static string ToLanguageCode(this Language language) => language switch
        {
            Language.Persian => "fa",
            Language.English => "en",
            Language.Arabic => "ar",
            Language.Turkish => "tr",
            Language.French => "fr",
            Language.German => "de",
            Language.Spanish => "es",
            Language.Italian => "it",
            Language.Russian => "ru",
            Language.Chinese => "zh",
            Language.Japanese => "ja",
            Language.Korean => "ko",
            Language.Hindi => "hi",
            Language.Urdu => "ur",
            Language.Portuguese => "pt",
            Language.Dutch => "nl",
            Language.Swedish => "sv",
            Language.Norwegian => "no",
            Language.Danish => "da",
            Language.Finnish => "fi",
            Language.Polish => "pl",
            Language.Ukrainian => "uk",
            Language.Greek => "el",
            Language.Hebrew => "he",
            Language.Thai => "th",
            Language.Vietnamese => "vi",
            Language.Indonesian => "id",
            Language.Malay => "ms",
            _ => throw new ArgumentOutOfRangeException(nameof(language), language, "Unsupported language")
        };

        // اگر خواستی برای لاگ/نمایش
        public static string ToDisplayName(this Language language) => language switch
        {
            Language.Persian => "Persian",
            Language.English => "English",
            Language.Arabic => "Arabic",
            Language.Turkish => "Turkish",
            Language.French => "French",
            Language.German => "German",
            Language.Spanish => "Spanish",
            Language.Italian => "Italian",
            Language.Russian => "Russian",
            Language.Chinese => "Chinese",
            Language.Japanese => "Japanese",
            Language.Korean => "Korean",
            Language.Hindi => "Hindi",
            Language.Urdu => "Urdu",
            Language.Portuguese => "Portuguese",
            Language.Dutch => "Dutch",
            Language.Swedish => "Swedish",
            Language.Norwegian => "Norwegian",
            Language.Danish => "Danish",
            Language.Finnish => "Finnish",
            Language.Polish => "Polish",
            Language.Ukrainian => "Ukrainian",
            Language.Greek => "Greek",
            Language.Hebrew => "Hebrew",
            Language.Thai => "Thai",
            Language.Vietnamese => "Vietnamese",
            Language.Indonesian => "Indonesian",
            Language.Malay => "Malay",
            _ => language.ToString()
        };
    }

}
