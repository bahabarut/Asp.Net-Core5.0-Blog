using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            ContactValidator cv = new ContactValidator();
            ValidationResult results = cv.Validate(contact);
            if (results.IsValid)
            {
                contact.ContactStatus = true;
                contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                cm.TAdd(contact);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach(var res in results.Errors)
                {
                    ModelState.AddModelError(res.PropertyName, res.ErrorMessage);
                }
                return View(contact);
            }

        }
    }
}
