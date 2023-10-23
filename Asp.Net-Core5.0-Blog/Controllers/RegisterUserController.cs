using Asp.Net_Core5._0_Blog.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.IO;
using System;
using System.Threading.Tasks;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel p)
        {


            if (!p.IsAcceptedTheContract)
            {
                ModelState.AddModelError("IsAcceptedTheContract", "Kayıt olabilmek için gizlilik sözleşmesini kabul etmeniz gerekiyor!");
                return View(p);
            }
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    PhoneNumber = p.Password,
                    Email = p.Mail,
                    UserName = p.UserName,
                    NameSurname = p.NameSurname
                };
                if (p.UserImage != null)
                {
                    var extension = Path.GetExtension(p.UserImage.FileName); //dosya uzantısını verir bize
                    var newImageName = Guid.NewGuid() + extension; //random bir isim oluşturarak uzantıyı sonuna ekliyor
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);// dosyanın tam yolunu verir bize
                    var stream = new FileStream(location, FileMode.Create);
                    p.UserImage.CopyTo(stream);
                    user.ImageUrl = newImageName;
                }
                else
                {
                    user.ImageUrl = "defaultProfile.png";
                }

                var result = await _userManager.CreateAsync(user, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            return View(p);

        }
    }
}
