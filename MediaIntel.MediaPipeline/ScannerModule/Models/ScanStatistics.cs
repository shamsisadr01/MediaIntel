namespace MediaIntel.MediaPipeline.ScannerModule.Models
{
    public class ScanStatistics
    {
        public int ScannedFolders { get; set; }
        public int ScannedFiles { get; set; }

        public int MatchedFolders { get; set; }
        public int MatchedFiles { get; set; }

        public bool ShouldStop { get; set; }
        public int MaxItems { get; set; } = 5000;

        public int TotalScannedItems => ScannedFolders + ScannedFiles;

        public void CheckLimit()
        {
            if (TotalScannedItems >= MaxItems)
                ShouldStop = true;
        }
    }
}
