﻿using KTaseva.Data;
using KTaseva.ViewModels.Admin;
using KTaseva.ViewModels.Photos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTaseva.App.ViewComponents
{
    public class AddPhotoViewComponent : ViewComponent
    {
        public AddPhotoViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            var model = new AdminPhotoInputModel();
            return View(model);
        }
    }
}
