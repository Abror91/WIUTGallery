using DemoWIUTGallery.BLL.Services.Abstractions;
using DemoWIUTGallery.Models.ViewModels;
using GalleryWebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GalleryWebApp.Controllers
{
    public class PhotoesController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IFileManager _fileManager;
        public PhotoesController(IPhotoService photoService, IFileManager fileManager)
        {
            _photoService = photoService;
            _fileManager = fileManager;
        }
        public async Task<IActionResult> Index(int folderId, string folderName)
        {
            var model = new FolderPhotoesViewModel();
            model.FolderId = folderId;
            model.FolderName = folderName;
            model.Photoes = await _photoService.GetPhotoesByFolder(folderId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoes(FolderPhotoesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var files = model.AddedFiles;

            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    var addModel = new PhotoAddViewModel();
                    var guid = Guid.NewGuid().ToString();
                    var directoryPath = "wwwroot/photography/";
                    var filePath = directoryPath + guid + file.FileName;
                    var fileName = guid + file.FileName;
                    try
                    {
                        _fileManager.CreateDirectory(directoryPath);
                        _fileManager.SaveFile(filePath, file);

                        addModel.Name = fileName;
                        addModel.Path = filePath;
                        addModel.Title = file.FileName;
                        addModel.FolderId = model.FolderId;
                        await _photoService.Add(addModel);
                    }
                    catch (Exception ex)
                    {
                        _fileManager.DeleteFile(filePath);
                        throw;
                    }

                }
                return RedirectToAction("Index", new { folderId = model.FolderId, folderName = model.FolderName });
            }

            return RedirectToAction("Index", new { folderId = model.FolderId, folderName = model.FolderName });
        }

        public async Task<IActionResult> Delete(int photoId, string path, int folderId, string folderName)
        {
            try
            {
                await _photoService.Delete(photoId);
                _fileManager.DeleteFile(path);
            }
            catch(Exception ex)
            {
                throw;
            }

            return RedirectToAction("Index", new { folderId = folderId, folderName = folderName });
        }
    }
}
