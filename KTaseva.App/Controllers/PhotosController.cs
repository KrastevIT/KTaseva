using KTaseva.Models;
using KTaseva.Services.Cloudinary;
using KTaseva.Services.Photos;
using KTaseva.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace KTaseva.App.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ICloudinaryService cloudinaryService;
        private readonly UserManager<User> userManager;
        private readonly IPhotoService photoService;

        public PhotosController(
            ICloudinaryService cloudinaryService,
            UserManager<User> userManager,
            IPhotoService photoService)
        {
            this.cloudinaryService = cloudinaryService;
            this.userManager = userManager;
            this.photoService = photoService;
        }

        public IActionResult Index()
        {
            var models = this.photoService.GetAllPhotos();
            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdminPhotoInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var userId = this.userManager.GetUserId(this.User);
            await this.cloudinaryService.UploadImageAsync(model.Photo, userId);
            return RedirectToAction(nameof(Index));
        }
    }
}
