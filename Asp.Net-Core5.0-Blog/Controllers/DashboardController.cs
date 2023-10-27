using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
            var userId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y=>y.Id).FirstOrDefault();
            //var userMail = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Email).FirstOrDefault();
            //var userId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.allBlogCount = c.Blogs.Count();
            ViewBag.currentUserBlogCount = c.Blogs.Where(x => x.UserID == userId).Count();
            ViewBag.allCategoryCount = c.Categories.Count();
            return View();
        }
    }
}
