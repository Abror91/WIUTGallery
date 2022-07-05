using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWIUTGallery.Models.ViewModels
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int FolderId { get; set; }
    }
}
