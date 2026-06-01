namespace MediaIntel.MediaPipeline.ScannerModule.Extensions
{
    public static class PathExtensions
    {
        public static string GetFileName(this string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }

        public static string GetFileFullName(this string path)
        {
            return Path.GetFileName(path);
        }
    }
}
