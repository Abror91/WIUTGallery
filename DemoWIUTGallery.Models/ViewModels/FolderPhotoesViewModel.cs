using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoWIUTGallery.Models.ViewModels
{
    public class FolderPhotoesViewModel
    {
        public int FolderId { get; set; }
        public string FolderName { get; set; }

        [Required(ErrorMessage = "Photo is required!")]
        public List<IFormFile> AddedFiles { get; set; }
        public IEnumerable<PhotoViewModel> Photoes { get; set; }
    }
}
