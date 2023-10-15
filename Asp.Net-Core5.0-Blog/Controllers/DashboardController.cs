using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new Context();
            var id = int.Parse(User.Identity.Name);
            ViewBag.allBlogCount = c.Blogs.Count();
            ViewBag.currentUserBlogCount = c.Blogs.Where(x => x.WriterID == id).Count();
            ViewBag.allCategoryCount = c.Categories.Count();
            return View();
        }
    }
}
