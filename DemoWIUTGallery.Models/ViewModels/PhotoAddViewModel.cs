using DemoWIUTGallery.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoWIUTGallery.Models.ViewModels
{
    public class PhotoAddViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Path is required")]
        [StringLength(255)]
        public string Path { get; set; }

        public int FolderId { get; set; }

        public Photo ToEntity()
        {
            return new Photo() { Title = Title, Name = Name, Path = Path, FolderId = FolderId };
        }
    }
}
