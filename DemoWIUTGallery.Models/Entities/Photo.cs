using DemoWIUTGallery.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace DemoWIUTGallery.Models.Entities
{
    public class Photo : BaseEntity
    {
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Path { get; set; }

        public int FolderId { get; set; }
        public Folder Folder { get; set; }

        public PhotoViewModel ToViewModel()
        {
            return new PhotoViewModel() { Id = Id, Title = Title, Name = Name, Path = Path, FolderId = FolderId };
        }


    }
}
