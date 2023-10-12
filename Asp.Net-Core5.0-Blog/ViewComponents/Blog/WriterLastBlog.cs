﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core5._0_Blog.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BlogManager bm = new BlogManager(new EfBlogRepository());
            var values = bm.GetBlogListByWriter(1);
            return View(values);
        }
    }
}