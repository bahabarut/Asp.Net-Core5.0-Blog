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
            Context c = new Context();
            var userMail = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Email).FirstOrDefault();
            var userId = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

            var values = msm.GetInboxListByWriter(userId);
            return View(values);
        }
    }
}
