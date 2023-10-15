using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
