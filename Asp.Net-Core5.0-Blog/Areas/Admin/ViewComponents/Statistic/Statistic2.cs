using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Asp.Net_Core5._0_Blog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            ViewBag.lastBlog = c.Blogs.OrderByDescending(x => x.BlogID).Select(y => y.BlogTitle).Take(1).FirstOrDefault();

            return View();
        }
    }
}
