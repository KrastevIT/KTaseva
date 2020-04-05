using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTaseva.Models;
using KTaseva.Services.Appointments;
using KTaseva.ViewModels.Appointments;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KTaseva.App.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly UserManager<User> userManager;

        public AppointmentsController(
            IAppointmentService appointmentService,
            UserManager<User> userManager)
        {
            this.appointmentService = appointmentService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var model = this.appointmentService.GetBusyAppointment();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AppointmentInputModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            this.appointmentService.Add(model, userId);
            return RedirectToAction("Index", "Home");
        }
    }
}
