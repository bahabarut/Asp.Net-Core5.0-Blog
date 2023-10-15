using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core5._0_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
