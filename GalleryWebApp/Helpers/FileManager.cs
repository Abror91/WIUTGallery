using Microsoft.AspNetCore.Http;

namespace GalleryWebApp.Helpers
{
    public class FileManager : IFileManager
    {
        public void CreateDirectory(string path)
        {
            System.IO.Directory.CreateDirectory(path);
        }
        public void SaveFile(string path, IFormFile file)
        {
            using(var stream = System.IO.File.Create(path))
            {
                file.CopyTo(stream);
            }
        }
        public void DeleteFile(string path)
        {
            System.IO.File.Delete(path);    
        }
    }
}
