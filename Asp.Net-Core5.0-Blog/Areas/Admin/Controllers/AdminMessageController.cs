using Asp.Net_Core5._0_Blog.Areas.Admin.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Asp.Net_Core5._0_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager msm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        public IActionResult Inbox()
        {
            int userId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var values = msm.GetInboxListByWriter(userId);
            return View(values);
            return View();
        }
        public IActionResult Sendbox()
        {
            int userId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var values = msm.GetSendBoxListByWriter(userId);
            return View(values);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ComposeMessage(AdminMessageViewModel p)
        {
            Message2 newMsg = new Message2();
            int SenderId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            newMsg.SenderID = SenderId;
            newMsg.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            newMsg.MessageStatus = true;
            newMsg.ReceiverID = c.Users.Where(x => x.Email == p.receiverMail).Select(y => y.Id).FirstOrDefault();
            newMsg.Subject = p.subject;
            newMsg.MessageDetails = p.content;
            msm.TAdd(newMsg);
            return RedirectToAction("Sendbox");
        }
        public IActionResult ViewMessage(int id)
        {
            var value = msm.GetByIdWithSender(id);
            return View(value);
        }
    }
}
