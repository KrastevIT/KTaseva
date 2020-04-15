using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KTaseva.App.Areas.Admin.Controllers
{
    public class AppointmentsController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
