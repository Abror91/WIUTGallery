using DemoWIUTGallery.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoWIUTGallery.Models.ViewModels
{
    public class EditFolderViewModel
    {
        [Required]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
