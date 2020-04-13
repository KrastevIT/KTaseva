using KTaseva.Models;
using KTaseva.Services.Appointments;
using KTaseva.Services.Procedures;
using KTaseva.ViewModels.Appointments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KTaseva.App.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService appointmentService;
        private readonly IProcedureService procedureService;
        private readonly UserManager<User> userManager;

        public AppointmentsController(
            IAppointmentService appointmentService,
            IProcedureService procedureService,
            UserManager<User> userManager)
        {
            this.appointmentService = appointmentService;
            this.procedureService = procedureService;
            this.userManager = userManager;
        }

        public IActionResult Add()
        {
            var model = this.appointmentService.GetBusyAppointment();
            model.Procedures = this.procedureService.GetProceduresDropDownList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AppointmentInputModel model)
        {
            var userId = this.userManager.GetUserId(this.User);
            var isValid = this.appointmentService.Add(model, userId);
            if (!isValid)
            {
                this.ViewData["error"] = $"Часът в {model.Date.Hour}:00 е зает!";
                return View(model);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
