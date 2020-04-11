using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTaseva.Models;
using KTaseva.Services.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KTaseva.App.Areas.Admin.Controllers
{
    public class HomeController : AdminController
    {
        private readonly IAdminService adminService;

        public HomeController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            var models = this.adminService.GetAppointment();
            return View(models);
        }
    }
}
