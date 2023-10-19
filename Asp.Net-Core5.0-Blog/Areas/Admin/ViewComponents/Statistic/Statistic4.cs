using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core5._0_Blog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        AdminManager adm = new AdminManager(new EfAdminRepository());
        public IViewComponentResult Invoke()
        {
            var value = adm.GetById(1);
            return View(value);
        }
    }
}
