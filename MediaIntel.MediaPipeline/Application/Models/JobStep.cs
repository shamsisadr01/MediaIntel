using MediaIntel.MediaPipeline.ScannerModule.Models;

namespace MediaIntel.MediaPipeline.Application.Models
{
    public class JobStep
    {
        public JobStep(BatchAction action)
        {
            Action = action;
        }

        public BatchAction Action { get; set; }

        public FolderItem? Data { get; set; } = null;

        public bool IsCompleted { get; set; }
    }
}
