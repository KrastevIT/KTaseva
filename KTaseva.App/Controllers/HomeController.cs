using KTaseva.Services.Procedures;
using KTaseva.ViewModels;
using KTaseva.ViewModels.Procedures;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace KTaseva.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProcedureService procedureService;

        public HomeController(IProcedureService procedureService)
        {
            this.procedureService = procedureService;
        }

        public IActionResult Index()
        {
            var procedures = this.procedureService.All();
            return View(procedures);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
