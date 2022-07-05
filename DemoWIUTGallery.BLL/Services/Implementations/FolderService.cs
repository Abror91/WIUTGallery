using DemoWIUTGallery.BLL.Services.Abstractions;
using DemoWIUTGallery.DAL.Repositories.Abstractions;
using DemoWIUTGallery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWIUTGallery.BLL.Services.Implementations
{
    public class FolderService : IFolderService
    {
        private readonly IFolderRepository _folderRepository;

        public FolderService(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }
        public async Task Add(AddEditFolderViewModel model)
        {
            var entity = model.ToEntity();
            _folderRepository.Add(entity);

            await _folderRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _folderRepository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Folder is not found!");

            _folderRepository.Delete(entity);

            await _folderRepository.SaveChangesAsync();
        }

        public async Task Edit(AddEditFolderViewModel model)
        {
            var entity = await _folderRepository.GetByIdAsync((int)model.Id);

            if (entity == null)
                throw new Exception("Folder is not found!");

            entity.Name = model.Name;

            //_folderRepository.Update(entity);
            await _folderRepository.SaveChangesAsync();
        }

        public async Task<FolderViewModel> GetById(int id)
        {
            var entity = await _folderRepository.GetByIdAsync(id);

            return entity.ToViewModel();
        }

        public async Task<IEnumerable<FolderViewModel>> GetFolders()
        {
            var entities = await _folderRepository.GetAllAsync();

            var models = new List<FolderViewModel>();
            foreach (var entity in entities)
                models.Add(entity.ToViewModel());

            return models;
        }
    }
}
