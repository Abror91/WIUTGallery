using DemoWIUTGallery.Models.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoWIUTGallery.Models.Entities
{
    public class Folder : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Photo> Photoes { get; set; }



        public FolderViewModel ToViewModel()
        {
            return new FolderViewModel() { Id = Id, Name = Name };
        }
    }
}
