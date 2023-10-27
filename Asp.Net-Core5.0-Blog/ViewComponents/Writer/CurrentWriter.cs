using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core5._0_Blog.ViewComponents.Writer
{
    public class CurrentWriter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            UserManager um = new UserManager(new EfUserRepository());
            var val = um.GetByUserName(User.Identity.Name);
            return View(val);
        }
        
    }
}
