using Asp.Net_Core5._0_Blog.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Asp.Net_Core5._0_Blog.Controllers
{

    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        int userId;
        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();

            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.blogId = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogListByWriter()
        {
            userId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var values = bm.GetBlogListWithCategoryByWriter(userId);
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
        public IActionResult BlogAdd(BlogAddViewModel p)
        {
            if (ModelState.IsValid)
            {
                Blog newBlog = new Blog();
                if (p.imageFile != null)
                {
                    var extension = Path.GetExtension(p.imageFile.FileName);
                    var newImage = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/BlogImageFiles/", newImage);
                    var stream = new FileStream(location, FileMode.Create);
                    p.imageFile.CopyTo(stream);
                    newBlog.BLogImage = newImage;
                }
                else
                {
                    newBlog.BLogImage = "defaultBlogImage.jpg";
                }
                newBlog.BlogTitle = p.title;
                newBlog.BlogContent = p.content;
                newBlog.CategoryID = p.catId;
                userId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
                newBlog.BlogStatus = true;
                newBlog.BLogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                newBlog.UserID = userId;
                bm.TAdd(newBlog);
                return RedirectToAction("BlogListByWriter", "Blog");

            }
            else
            {
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
        [AllowAnonymous]
        public IActionResult BlogByCategory(int id)
        {
            var values = bm.GetBlogByCategory(id);
            return View("Index", values);
        }
    }
}
