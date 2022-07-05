using DemoWIUTGallery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWIUTGallery.BLL.Services.Abstractions
{
    public interface IFolderService
    {
        Task<IEnumerable<FolderViewModel>> GetFolders();
        Task<FolderViewModel> GetById(int id);
        Task Add(AddEditFolderViewModel model);
        Task Edit(AddEditFolderViewModel model);
        Task Delete(int id);
    }
}
