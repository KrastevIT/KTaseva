using KTaseva.Common;
using KTaseva.Services.Admin;
using KTaseva.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace KTaseva.App.Areas.Admin.Controllers
{
    public class AppointmentsController : AdminController
    {
        private readonly IAdminService adminService;

        public AppointmentsController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        public IActionResult Index()
        {
            var model = new AdminDisableDateInputModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AdminDisableDateInputModel model)
        {
            this.adminService.AddDisableDate(model);

            this.TempData["successfully"] = string.Format(
                SuccessfullyMessages.SuccessfullyAddDisableDate, model.DisabledDates);

            return RedirectToAction("Index");
        }
    }
}
