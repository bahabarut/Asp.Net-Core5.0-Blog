using Asp.Net_Core5._0_Blog.Models;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Drawing;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
            if (ModelState.IsValid)
            {
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return View();
            }
            // bu 4 parametre alır 1.username 2.password 3.bool türünde (isPresistent) bilgileri hatırlasın mı gibi 4. de bool(lockoutOnFailure) sisteme 5 defa yanlış girerse kilitlenir (varsayılanı 5 değişebilir)

        }

        //[HttpPost]
        //public async Task<IActionResult> Index(Writer p)
        //{
        //    Context c = new Context();
        //    var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
        //    if (dataValue != null)
        //    {
        //        var claims = new List<Claim> {
        //        new Claim(ClaimTypes.Email, p.WriterMail),
        //        new Claim(ClaimTypes.Name, dataValue.WriterID.ToString())
        //        };
        //        var userIdentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal pricipal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(pricipal);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}


//Context c = new Context();
//var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
//if (dataValue != null)
//{
//    HttpContext.Session.SetString("username", p.WriterMail);
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View();

//}