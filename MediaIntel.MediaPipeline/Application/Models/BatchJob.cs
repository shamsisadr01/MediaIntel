namespace MediaIntel.MediaPipeline.Application.Models
{
    public class BatchJob
    {
        public string TargetFolderPath { get; set; } = string.Empty;
        // public string[]? TargetFilePaths { get; set; } = null;

        public int CurrentStepIndex { get; set; }
        public List<JobStep> Steps { get; set; } = new List<JobStep>();

        public bool IsFinished => CurrentStepIndex >= Steps.Count;
    }
}
