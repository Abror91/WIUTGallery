using DemoWIUTGallery.BLL.Services.Abstractions;
using DemoWIUTGallery.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GalleryWebApp.Controllers
{
    public class FoldersController : Controller
    {
        private readonly IFolderService _folderService;
        public FoldersController(IFolderService folderService)
        {
            _folderService = folderService;
        }
        public async Task<IActionResult> Index()
        {
            var models = await _folderService.GetFolders();

            return View(models);
        }

        public async Task<IActionResult> AddOrEdit(int? id)
        {
            ViewBag.PageName = id == null ? "Create Folder" : "Edit Folder";
            ViewBag.IsEdit = id == null ? false : true;

            if (id == null)
            {
                return View();
            }
            else
            {
                var folder = await _folderService.GetById((int)id);

                if(folder == null)
                    return NotFound();

                return View(folder.ToAddEditViewModel());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name")] AddEditFolderViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Id > 0)
                {
                    await _folderService.Edit(model);
                }
                else
                {
                    await _folderService.Add(model);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var model = await _folderService.GetById((int)id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _folderService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
