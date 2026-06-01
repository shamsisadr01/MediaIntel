using MediaIntel.MediaPipeline.ScannerModule.Enums;
using MediaIntel.MediaPipeline.ScannerModule.Models;

namespace MediaIntel.MediaPipeline.ScannerModule.Services
{
    public interface IMediaScannerService
    {
        FolderItem BuildTree(string rootPath, ScanMode mode = ScanMode.PairedMedia);
    }
}