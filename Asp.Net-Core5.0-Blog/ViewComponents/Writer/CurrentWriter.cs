using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core5._0_Blog.ViewComponents.Writer
{
    public class CurrentWriter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            WriterManager wm = new WriterManager(new EfWriterRepository());
            var values = wm.GetCurrentUser(User.Identity.Name);
            return View(values);
        }
        
    }
}
