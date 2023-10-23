using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager msm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();

        public IActionResult InBox()
        {
            int userId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var values = msm.GetInboxListByWriter(userId);
            return View(values);
        }
        public IActionResult SendBox()
        {
            int userId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            var values = msm.GetSendBoxListByWriter(userId);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var values = msm.GetById(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            GetReveivers();
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            int SenderId = c.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Id).FirstOrDefault();
            p.SenderID = SenderId;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            msm.TAdd(p);
            return RedirectToAction("SendBox");
        }

        [HttpGet]
        public IActionResult MessageEdit(int id)
        {
            GetReveivers();
            var value = msm.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult MessageEdit(Message2 p)
        {
            msm.TUpdate(p);
            return RedirectToAction("SendBox");
        }
        public IActionResult MessageDelete(int id)
        {
            msm.TDelete(msm.GetById(id));
            return RedirectToAction("SendBox");
        }
        void GetReveivers()
        {
            ViewBag.Receivers = c.Users.ToList();
        }
    }
}
