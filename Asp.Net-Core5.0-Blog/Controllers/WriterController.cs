using Asp.Net_Core5._0_Blog.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Drawing.Charts;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel value = new UserUpdateViewModel()
            {
                namesurname = user.NameSurname,
                username = user.UserName,
                mail = user.Email,
                imageurl = user.ImageUrl
            };
            return View(value);

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateViewModel p)
        {
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            currentUser.NameSurname = p.namesurname;
            currentUser.UserName = p.username;
            currentUser.Email = p.mail;
            currentUser.ImageUrl=p.imageurl;
            currentUser.PasswordHash = _userManager.PasswordHasher.HashPassword(currentUser, p.password);
            var result = await _userManager.UpdateAsync(currentUser);   
            //WriterValidator wv = new WriterValidator();
            //ValidationResult results = wv.Validate(p);
            //if (results.IsValid)
            //{
            //    wm.TUpdate(p);
            //    return RedirectToAction("Index", "Dashboard");
            //}
            //else
            //{
            //    foreach (var err in results.Errors)
            //    {
            //        ModelState.AddModelError(err.PropertyName, err.ErrorMessage);

            //    }
            //}
            return View(p);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfilImage p)
        {
            Writer w = new Writer();

            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName); //dosya uzantısını verir bize
                var newImageName = Guid.NewGuid() + extension; //random bir isim oluşturarak uzantıyı sonuna ekliyor
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);// dosyanın tam yolunu verir bize
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
