using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTaseva.ViewModels.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace KTaseva.App.Controllers
{
    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AppointmentInputModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
