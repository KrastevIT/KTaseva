using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTaseva.ViewModels.AboutMe;
using Microsoft.AspNetCore.Mvc;

namespace KTaseva.App.Controllers
{
    public class AboutMeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AboutMeInputModel model)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(AboutMeInputModel model)
        {
            return RedirectToAction("Index");
        }
    }
}
