using MediaIntel.MediaPipeline.AIModule.Enums;
using MediaIntel.MediaPipeline.AIModule.Services;

namespace MediaIntel.MediaPipeline.AIModule.Extensions
{
    public static class AiModelExtensions
    {
        public static string ToApiModelString(this AiModel model)
        {
            return model switch
            {
                AiModel.GapgptQwen35 => "gapgpt-qwen-3.5",
                AiModel.GapgptQwen35Thinking => "gapgpt-qwen-3.5-thinking",

                AiModel.Gpt52 => "gpt-5.2",
                AiModel.Gpt52ChatLatest => "gpt-5.2-chat-latest",
                AiModel.Gpt52Codex => "gpt-5.2-codex",
                AiModel.Gpt52Pro => "gpt-5.2-pro",
                AiModel.Gpt53ChatLatest => "gpt-5.3-chat-latest",
                AiModel.Gpt53Codex => "gpt-5.3-codex",
                AiModel.Gpt53CodexSpark => "gpt-5.3-codex-spark",

                AiModel.ClaudeOpus412250805 => "claude-opus-4-1-20250805",
                AiModel.ClaudeOpus420250514 => "claude-opus-4-20250514",
                AiModel.ClaudeOpus4520251101 => "claude-opus-4-5-20251101",
                AiModel.ClaudeOpus46 => "claude-opus-4-6",
                AiModel.ClaudeSonnet420250514 => "claude-sonnet-4-20250514",
                AiModel.ClaudeSonnet4520250929 => "claude-sonnet-4-5-20250929",
                AiModel.ClaudeSonnet46 => "claude-sonnet-4-6",
                AiModel.Claude35Haiku20241022 => "claude-3-5-haiku-20241022",
                AiModel.Claude35Sonnet20241022 => "claude-3-5-sonnet-20241022",
                AiModel.Claude37Sonnet20250219 => "claude-3-7-sonnet-20250219",

                AiModel.Gemini15Flash => "gemini-1.5-flash",
                AiModel.Gemini15Flash8b => "gemini-1.5-flash-8b",
                AiModel.Gemini15FlashLatest => "gemini-1.5-flash-latest",
                AiModel.Gemini15Pro => "gemini-1.5-pro",
                AiModel.Gemini15ProLatest => "gemini-1.5-pro-latest",
                AiModel.Gemini20Flash => "gemini-2.0-flash",
                AiModel.Gemini20FlashExp => "gemini-2.0-flash-exp",
                AiModel.Gemini20FlashLite => "gemini-2.0-flash-lite",
                AiModel.Gemini20FlashLitePreview => "gemini-2.0-flash-lite-preview",
                AiModel.Gemini20FlashLive001 => "gemini-2.0-flash-live-001",
                AiModel.Gemini20FlashThinkingExp => "gemini-2.0-flash-thinking-exp",
                AiModel.Gemini20ProExp => "gemini-2.0-pro-exp",
                AiModel.Gemini25Flash => "gemini-2.5-flash",
                AiModel.Gemini25FlashExpNativeAudioThinkingDialog => "gemini-2.5-flash-exp-native-audio-thinking-dialog",
                AiModel.Gemini25FlashLite => "gemini-2.5-flash-lite",
                AiModel.Gemini25FlashPreviewNativeAudioDialog => "gemini-2.5-flash-preview-native-audio-dialog",
                AiModel.Gemini25Pro => "gemini-2.5-pro",
                AiModel.Gemini25ProExp0325 => "gemini-2.5-pro-exp-03-25",
                AiModel.Gemini25ProPreview0325 => "gemini-2.5-pro-preview-03-25",
                AiModel.Gemini3FlashPreview => "gemini-3-flash-preview",
                AiModel.Gemini3ProPreview => "gemini-3-pro-preview",
                AiModel.Gemini31FlashLitePreview => "gemini-3.1-flash-lite-preview",
                AiModel.Gemini31ProPreview => "gemini-3.1-pro-preview",
                AiModel.GeminiFlashLiteLatest => "gemini-flash-lite-latest",
                AiModel.GeminiLive25FlashPreview => "gemini-live-2.5-flash-preview",
                AiModel.GeminiExp1206 => "gemini-exp-1206",
                AiModel.Gemma327bIt => "gemma-3-27b-it",

                AiModel.Grok3 => "grok-3",
                AiModel.Grok3Fast => "grok-3-fast",
                AiModel.Grok3Mini => "grok-3-mini",
                AiModel.Grok3MiniFast => "grok-3-mini-fast",
                AiModel.Grok4 => "grok-4",

                AiModel.Chatgpt4oLatest => "chatgpt-4o-latest",
                AiModel.Gpt41 => "gpt-4.1",
                AiModel.Gpt41Mini => "gpt-4.1-mini",
                AiModel.Gpt41Nano => "gpt-4.1-nano",
                AiModel.Gpt45Preview => "gpt-4.5-preview",
                AiModel.Gpt4o => "gpt-4o",
                AiModel.Gpt4oAudioPreview => "gpt-4o-audio-preview",
                AiModel.Gpt4oMini => "gpt-4o-mini",
                AiModel.Gpt5 => "gpt-5",
                AiModel.Gpt5ChatLatest => "gpt-5-chat-latest",
                AiModel.Gpt5Codex => "gpt-5-codex",
                AiModel.Gpt5Mini => "gpt-5-mini",
                AiModel.Gpt5Nano => "gpt-5-nano",
                AiModel.Gpt51 => "gpt-5.1",
                AiModel.Gpt51ChatLatest => "gpt-5.1-chat-latest",
                AiModel.Gpt51Codex => "gpt-5.1-codex",
                AiModel.Gpt51CodexMini => "gpt-5.1-codex-mini",
                AiModel.Gpt54 => "gpt-5.4",
                AiModel.O1Mini => "o1-mini",
                AiModel.O3Mini => "o3-mini",
                AiModel.O3MiniHigh => "o3-mini-high",
                AiModel.O3MiniLow => "o3-mini-low",
                AiModel.O4Mini => "o4-mini",

                AiModel.DeepseekChat => "deepseek-chat",
                AiModel.DeepseekR1 => "deepseek-r1",
                AiModel.DeepseekReasoner => "deepseek-reasoner",

                AiModel.Qwen35B_A3B_FP8 => "Qwen/Qwen3.5-35B-A3B-FP8",
                AiModel.Qwen3235B_A22B => "qwen3-235b-a22b",
                AiModel.Qwen3235B_A22B_Instruct2507 => "qwen3-235b-a22b-instruct-2507",
                AiModel.Qwen3Coder => "qwen3-coder",
                AiModel.Qwen3Coder480B_A35B_Instruct => "qwen3-coder-480b-a35b-instruct",

                _ => throw new ArgumentOutOfRangeException(nameof(model), model, null)
            };
        }
    }
}
