using Microsoft.AspNetCore.Http;

namespace GalleryWebApp.Helpers
{
    public interface IFileManager
    {
        void CreateDirectory(string path);
        void SaveFile(string path, IFormFile file);
        void DeleteFile(string path);
    }
}
