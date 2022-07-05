using DemoWIUTGallery.BLL.Services.Abstractions;
using DemoWIUTGallery.DAL.Repositories.Abstractions;
using DemoWIUTGallery.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWIUTGallery.BLL.Services.Implementations
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        public PhotoService(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        public async Task<IEnumerable<PhotoViewModel>> GetPhotoesByFolder(int folderId)
        {
            var entities = await _photoRepository.GetPhotoesByFolder(folderId);

            var models = new List<PhotoViewModel>();

            foreach (var entity in entities)
                models.Add(entity.ToViewModel());

            return models;
        }

        public async Task<PhotoViewModel> GetById(int id)
        {
            var entity = await _photoRepository.GetByIdAsync(id);

            return entity.ToViewModel();
        }

        public async Task Add(PhotoAddViewModel model)
        {
            var entity = model.ToEntity();
            _photoRepository.Add(entity);

            await _photoRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _photoRepository.GetByIdAsync(id);

            if (entity == null)
                throw new Exception("Photo not found!");

            _photoRepository.Delete(entity);
            await _photoRepository.SaveChangesAsync();
        }
    }
}
