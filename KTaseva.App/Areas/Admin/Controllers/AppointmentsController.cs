using KTaseva.Services.Admin;
using KTaseva.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminDisableDateInputModel model)
        {
            this.adminService.AddDisableDate(model);
            return RedirectToAction("Index");
        }
    }
}
