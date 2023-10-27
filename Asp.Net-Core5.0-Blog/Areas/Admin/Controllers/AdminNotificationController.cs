using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Asp.Net_Core5._0_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminNotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult Index()
        {
            var value = nm.GetList();
            return View(value);
        }
        [HttpGet]
        public IActionResult AddNotification()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNotification(Notification p)
        {
            p.NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.NotificationStatus = true;
            p.NotificationColor = "preview-icon bg-" + p.NotificationColor;
            p.NotificationTypeSymbol = "mdi mdi-calendar";
            nm.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditNotification(int id)
        {
            var value = nm.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditNotification(Notification p)
        {
            nm.TUpdate(p);
            return RedirectToAction("Index");
        }   
        public IActionResult DeleteNotification(int id)
        {
            var value = nm.GetById(id);
            nm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
