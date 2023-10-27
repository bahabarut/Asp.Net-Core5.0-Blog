using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Asp.Net_Core5._0_Blog.ViewComponents.Blog
{
    public class BlogListDashboard: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BlogManager bm = new BlogManager(new EfBlogRepository());
            var values = bm.GetBlogListWithCategory().OrderByDescending(x=>x.BlogID).Take(5).ToList();
            return View(values);
        }
    }
}
