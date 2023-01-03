using Microsoft.AspNetCore.Mvc;

namespace NRM1_mysiteproject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
