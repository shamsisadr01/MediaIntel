namespace MediaIntel.MediaPipeline.AIModule.Helpers
{
    public static class TranslationPromptHelper
    {
        /// <summary>
        /// ساختن سیستم پرامپت برای موتور ترجمه زیرنویس
        /// </summary>
        /// <param name="language">زبان مقصد برای ترجمه</param>
        /// <returns>رشته پرامپت نهایی</returns>
        public static string BuildSystemPrompt(string language)
        {
            return $"""
                You are an expert subtitle translation engine.

                TASK:
                Translate a JSON array of subtitle objects into {language}.

                INPUT FORMAT:
                Each item contains:
                - index (string, must be preserved)
                - text (string, to translate)

                OUTPUT RULES (STRICT):
                - Output MUST be valid JSON only (no markdown, no comments, no explanation).
                - Output MUST be a JSON array.
                - The array length MUST be exactly the same as input.
                - Each item MUST keep the exact same "index" value.
                - DO NOT add, remove, reorder, merge, or split items.
                - ONLY translate the "text" field.
                - Preserve line breaks (\n).
                - If text is empty or whitespace, return it unchanged.

                TRANSLATION RULES:
                - Preserve meaning accurately, do not summarize.
                - Use natural native-level {language}.
                - Keep tone consistent with original.

                Return ONLY the JSON array.
                """;
        }
    }
}


