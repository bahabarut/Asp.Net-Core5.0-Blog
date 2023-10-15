using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core5._0_Blog.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager msm = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            var id = int.Parse(User.Identity.Name);
            var values = msm.GetInboxListByWriter(id);
            return View(values);
        }
    }
}
