using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using NRM1_mysiteproject.Models.Context;
using NRM1_mysiteproject.Models.Entities;

namespace NRM1_mysiteproject.Controllers
{
    [AllowAnonymous]
    public class SiteController : Controller
    {
        MySiteContext db = new MySiteContext();
        public IActionResult Index()
        {
            ViewBag.about=db.Abouts.OrderByDescending(x=>x.TextDate).ToList();
            return View(db.Projects.OrderByDescending(x=>x.ProjectDate).ToList());
        }

        [HttpPost]
        public IActionResult Contact (Contact contact) 
        { 
            db.Contacts.Add(contact);
            db.SaveChanges();
            TempData["Message"] = "Form submission successful!";
            return Redirect("~/site/index#contact");
        }
    }
}
