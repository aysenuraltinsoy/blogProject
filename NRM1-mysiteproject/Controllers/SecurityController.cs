using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NRM1_mysiteproject.Models.Context;
using NRM1_mysiteproject.Models.Entities;
using System.Security.Claims;

namespace NRM1_mysiteproject.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        MySiteContext db=new MySiteContext();
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(AdminUser admin) 
        {
            var data=db.AdminUsers.FirstOrDefault(x=>x.KullaniciAdi==admin.KullaniciAdi && x.Sifre==admin.Sifre);
            if (data!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.KullaniciAdi)
                };
                var userIdentity=new ClaimsIdentity(claims,"Security");
                ClaimsPrincipal principle=new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync(principle);

                return RedirectToAction("Index", "Admin");
            }

            return View();  
        }

        public IActionResult Logout() 
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
