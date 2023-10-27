using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core5._0_Blog.Areas.Admin.ViewComponents.User
{
    public class CurrentUser : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            UserManager um = new UserManager(new EfUserRepository());
            var value = um.GetByUserName(User.Identity.Name);
            return View(value);
        }
    }
}
