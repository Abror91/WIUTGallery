using System;
using System.Collections.Generic;
using System.Text;

namespace DemoWIUTGallery.Models.ViewModels
{
    public class FolderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AddEditFolderViewModel ToAddEditViewModel()
        {
            return new AddEditFolderViewModel() { Id = Id, Name = Name };
        }
    }
}
