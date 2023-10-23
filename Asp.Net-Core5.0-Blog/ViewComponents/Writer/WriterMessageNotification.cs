using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Asp.Net_Core5._0_Blog.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager msm = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            int userId;
            using (Context c = new Context())
            {
                userId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            }
            var values = msm.GetInboxListByWriter(userId);
            return View(values);
        }
    }
}
