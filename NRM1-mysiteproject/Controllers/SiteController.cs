using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;



namespace NRM1_mysiteproject.Controllers
{
    [AllowAnonymous]
    public class SiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
