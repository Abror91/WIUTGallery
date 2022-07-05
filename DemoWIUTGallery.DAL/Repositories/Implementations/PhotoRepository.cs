using DemoWIUTGallery.DAL.Repositories.Abstractions;
using DemoWIUTGallery.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWIUTGallery.DAL.Repositories.Implementations
{
    public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Photo>> GetPhotoesByFolder(int folderId)
        {
            return await _entities.Where(s => s.FolderId == folderId).ToListAsync();
        }
    }
}
