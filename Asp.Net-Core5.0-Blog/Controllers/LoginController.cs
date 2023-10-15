﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();
            var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if (dataValue != null)
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.Email, p.WriterMail),
                new Claim(ClaimTypes.Name, dataValue.WriterID.ToString())
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal pricipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(pricipal);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            }
        }
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