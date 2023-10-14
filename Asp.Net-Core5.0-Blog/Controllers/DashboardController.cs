using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.allBlogCount = c.Blogs.Count();
            ViewBag.currentUserBlogCount = c.Blogs.Where(x => x.WriterID == 1).Count();
            ViewBag.allCategoryCount = c.Categories.Count();
            return View();
        }
    }
}
