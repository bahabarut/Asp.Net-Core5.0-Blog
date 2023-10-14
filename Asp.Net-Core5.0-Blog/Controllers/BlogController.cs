using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();

            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.blogId = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var values = bm.GetBlogListWithCategoryByWriter(1);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> BlogAdd()
        {

            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName.ToString(),
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();

            ViewBag.catVal = categoryValues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BLogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");

            }
            else
            {
                foreach (var res in results.Errors)
                {
                    ModelState.AddModelError(res.PropertyName, res.ErrorMessage);
                }
                List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                       select new SelectListItem
                                                       {
                                                           Text = x.CategoryName.ToString(),
                                                           Value = x.CategoryID.ToString()

                                                       }).ToList();

                ViewBag.catVal = categoryValues;
                return View(p);
            }
        }
        public IActionResult BlogDelete(int id)
        {
            var blogVal = bm.GetById(id);
            bm.TDelete(blogVal);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        [HttpGet]
        public IActionResult BlogEdit(int id)
        {

            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName.ToString(),
                                                       Value = x.CategoryID.ToString()

                                                   }).ToList();
            ViewBag.catVal = categoryValues;
            var blogVal = bm.GetById(id);
            return View(blogVal);
        }

        [HttpPost]
        public IActionResult BlogEdit(Blog p)
        {
            bm.TUpdate(p);
            return RedirectToAction("BLogListByWriter", "Blog");
        }
    }
}
