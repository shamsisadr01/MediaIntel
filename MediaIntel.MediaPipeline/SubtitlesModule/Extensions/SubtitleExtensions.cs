using Nikse.SubtitleEdit.Core.Common;
using System.Text;

namespace MediaIntel.MediaPipeline.SubtitlesModule.Extensions
{
    public static class SubtitleExtensions
    {
        private const char RLE = '‫';
        private const char PDF = '‬';
        public static string ApplyRtlEmbedding(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }
            StringBuilder sb = new StringBuilder(text.Length + 2);
            sb.Append(RLE);
            sb.Append(text);
            sb.Append(PDF);
            return sb.ToString();
        }

        public static List<List<Paragraph>> SentenceDetection(List<Paragraph> paragraphs)
        {
            var result = new List<List<Paragraph>>();
            List<Paragraph>? currentSentence = null;

            foreach (var paragraph in paragraphs)
            {
                currentSentence ??= new List<Paragraph>();
                currentSentence.Add(paragraph);

                if (paragraph.Text.HasSentenceEnding())
                {
                    result.Add(currentSentence);
                    currentSentence = null;
                }
            }

            if (currentSentence is not null && currentSentence.Count > 0)
                result.Add(currentSentence);

            return result;
        }

        public static string GetLocalizedFilePath(string fileName, string language = "fa")
        {
            var directoryPath = Path.GetDirectoryName(fileName);
            var originalFileName = Path.GetFileNameWithoutExtension(fileName);
            var extension = Path.GetExtension(fileName);
            var newName = $"{originalFileName}_{language}{extension}";
            return Path.Combine(directoryPath, newName);
        }

        public static bool TryDeleteFile(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
