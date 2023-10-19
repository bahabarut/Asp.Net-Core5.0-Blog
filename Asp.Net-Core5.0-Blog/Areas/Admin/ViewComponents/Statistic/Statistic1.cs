using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using System.Linq;
using System.Xml.Linq;

namespace Asp.Net_Core5._0_Blog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Context c = new Context();
            ViewBag.allBlogCount = c.Blogs.Count();
            ViewBag.allContactCount = c.Contacts.Count();
            ViewBag.allCommentCount = c.Comments.Count();
            string location = "antalya";
            ViewBag.location = location;
            string api = "505b63ee2b82143413d12a79512a139d";
            string connection = $"https://api.openweathermap.org/data/2.5/weather?q={location}&mode=xml&lang=tr&units=metric&appid={api}";
            XDocument document = XDocument.Load(connection);
            ViewBag.temp = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
