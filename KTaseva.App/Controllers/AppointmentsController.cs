using KTaseva.Common;
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
    [Route("Appointments")]
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
            var model = new AppointmentInputModel
            {
                Procedures = this.procedureService.GetProceduresDropDownList(),
                DisabledDates = this.appointmentService.GetDisabledDates()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AppointmentInputModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Procedures = this.procedureService.GetProceduresDropDownList();
                model.DisabledDates = this.appointmentService.GetDisabledDates();
                this.ViewData["invalid"] = ErrorMessages.AppointmentInvalidAdd;
                return View(model);
            }

            var userId = this.userManager.GetUserId(this.User);
            var isValid = this.appointmentService.Add(model, userId);
            if (!isValid)
            {
                this.ViewData["error"] = string.Format(ErrorMessages.AppointmentBusy, model.Hour);
                model.Procedures = this.procedureService.GetProceduresDropDownList();
                return View(model);
            }

            this.TempData["successfully"] = string.Format(
                ErrorMessages.AppointmentSuccessfullyAdd, model.Date.ToShortDateString(), model.Hour);

            return RedirectToAction("Index", "Home");
        }
    }
}
