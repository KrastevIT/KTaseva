using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTaseva.Services.Admin;
using KTaseva.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;

namespace KTaseva.App.Controllers
{
    public class PhotosController : Controller
    {
        private readonly IAdminService adminService;

        public PhotosController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminInputAddPhoto model)
        {
            this.adminService.AddPhoto(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
