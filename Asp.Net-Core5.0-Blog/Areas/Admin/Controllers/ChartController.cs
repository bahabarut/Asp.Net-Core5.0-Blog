﻿using Asp.Net_Core5._0_Blog.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Asp.Net_Core5._0_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass { categoryname = "Teknoloji", categorycount = 10 });
            list.Add(new CategoryClass { categoryname = "Yazılım", categorycount = 14 });
            list.Add(new CategoryClass { categoryname = "Spor", categorycount = 5 });
            return Json(new { jsonlist = list });
        }
    }
}
