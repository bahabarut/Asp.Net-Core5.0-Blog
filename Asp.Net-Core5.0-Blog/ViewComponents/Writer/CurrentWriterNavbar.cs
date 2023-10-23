using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core5._0_Blog.ViewComponents.Writer
{
    public class CurrentWriterNavbar : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var val = wm.GetCurrentUser(User.Identity.Name);
            return View(val);
        }
    }
}
