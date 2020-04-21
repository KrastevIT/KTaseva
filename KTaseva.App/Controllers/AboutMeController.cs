using KTaseva.Services.AboutMe;
using KTaseva.ViewModels.AboutMe;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KTaseva.App.Controllers
{
    public class AboutMeController : Controller
    {
        private readonly IAboutMeService aboutMeService;

        public AboutMeController(IAboutMeService aboutMeService)
        {
            this.aboutMeService = aboutMeService;
        }

        public IActionResult Index()
        {
            var models = this.aboutMeService.All<AboutMeViewModel>();
            return View(models);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AboutMeInputModel model)
        {
            this.aboutMeService.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string id)
        {
            var model = this.aboutMeService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AboutMeInputModel model)
        {
            this.aboutMeService.Edit(model);
            return RedirectToAction("Index");
        }
    }
}
