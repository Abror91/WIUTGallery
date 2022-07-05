using DemoWIUTGallery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWIUTGallery.BLL.Services.Abstractions
{
    public interface IPhotoService
    {
        Task<IEnumerable<PhotoViewModel>> GetPhotoesByFolder(int folderId);
        Task<PhotoViewModel> GetById(int id);
        Task Add(PhotoAddViewModel model);
        Task Delete(int id);
    }
}
