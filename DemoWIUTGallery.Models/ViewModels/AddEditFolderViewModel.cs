using DemoWIUTGallery.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace DemoWIUTGallery.Models.ViewModels
{
    public class AddEditFolderViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        public Folder ToEntity()
        {
            return new Folder() { Name = Name };
        }
    }
}
