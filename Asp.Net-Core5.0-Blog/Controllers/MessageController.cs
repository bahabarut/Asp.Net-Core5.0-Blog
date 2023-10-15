using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager msm = new Message2Manager(new EfMessage2Repository());
        [AllowAnonymous]
        public IActionResult InBox()
        {
            var id = int.Parse(User.Identity.Name);
            var values = msm.GetInboxListByWriter(id);
            return View(values);
        }
        [AllowAnonymous]

        public IActionResult MessageDetails(int id)
        {
            var values = msm.GetById(id);
            return View(values);
        }
    }
}
