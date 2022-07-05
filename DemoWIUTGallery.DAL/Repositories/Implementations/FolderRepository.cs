using DemoWIUTGallery.DAL.Repositories.Abstractions;
using DemoWIUTGallery.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWIUTGallery.DAL.Repositories.Implementations
{
    public class FolderRepository : GenericRepository<Folder>, IFolderRepository
    {
        public FolderRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
