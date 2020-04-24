using KTaseva.Common;
using KTaseva.Services.Procedures;
using KTaseva.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc;

namespace KTaseva.App.Areas.Admin.Controllers
{
    public class ProceduresController : AdminController
    {
        private readonly IProcedureService procedureService;

        public ProceduresController(IProcedureService procedureService)
        {
            this.procedureService = procedureService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminProcedureInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.procedureService.Add(model);
            this.ViewData["alert"] = string.Format(
                SuccessfullyMessages.SuccessfullyAddProcedure, model.Name);
            return View();
        }
    }
}
