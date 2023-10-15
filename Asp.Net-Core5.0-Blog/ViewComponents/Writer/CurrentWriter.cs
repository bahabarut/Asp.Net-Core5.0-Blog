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
            var id = int.Parse(User.Identity.Name);
            var values = wm.GetById(id);
            return View(values);
        }
        
    }
}
