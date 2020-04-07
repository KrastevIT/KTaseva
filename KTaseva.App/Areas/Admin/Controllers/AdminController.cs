using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KTaseva.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public abstract class AdminController : Controller
    {
    }
}
