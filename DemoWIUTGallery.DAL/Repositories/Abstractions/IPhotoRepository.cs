using DemoWIUTGallery.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoWIUTGallery.DAL.Repositories.Abstractions
{
    public interface IPhotoRepository : IGenericRepository<Photo>
    {
        Task<IEnumerable<Photo>> GetPhotoesByFolder(int folderId);
    }
}
