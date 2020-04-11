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
        private readonly UserManager<User> userManager;

        public HomeController(IAdminService adminService, UserManager<User> userManager)
        {
            this.adminService = adminService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = this.userManager.GetUserId(this.User);
            var models = this.adminService.GetAppointment(userId);
            return View();
        }
    }
}
