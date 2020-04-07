using Microsoft.AspNetCore.Mvc;

namespace KTaseva.App.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
