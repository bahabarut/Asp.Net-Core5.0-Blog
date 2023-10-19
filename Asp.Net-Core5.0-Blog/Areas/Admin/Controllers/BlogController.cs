using Asp.Net_Core5._0_Blog.Areas.Admin.Models;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;

namespace Asp.Net_Core5._0_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //yeni bir çalışma kağıdı oluşturuyoruz 
                worksheet.Cell(1, 1).Value = "Blog ID"; // 1,1 hücreye bu alanı ekliyoruz
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2; //veriler 2.satırdan basılmaya başlanacak çünkü ilk satır başlık satırı 3 dersek  3 den başlar yada 4
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++; //satırı her döngüde arttırıyoruz
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                    //return File(content, "application/vnd.ms-excel", "Calisma1.xlsx"); ikisi de kullanıla bilir
                }

            }
        }
        List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>() {
            new BlogModel { ID=1,BlogName="C# ile yazılım"},
            new BlogModel { ID=2,BlogName="Yazılım Kuralları"},
            };
            return bm;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }


        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //yeni bir çalışma kağıdı oluşturuyoruz 
                worksheet.Cell(1, 1).Value = "Blog ID"; // 1,1 hücreye bu alanı ekliyoruz
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2; //veriler 2.satırdan basılmaya başlanacak çünkü ilk satır başlık satırı 3 dersek  3 den başlar yada 4
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++; //satırı her döngüde arttırıyoruz
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma2.xlsx");
                    //return File(content, "application/vnd.ms-excel", "Calisma1.xlsx"); ikisi de kullanıla bilir
                }

            }
        }
        public List<BlogModel> BlogTitleList()
        {
            List<BlogModel> bm = new List<BlogModel>();
            using (var c = new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel
                {
                    ID = x.BlogID,
                    BlogName = x.BlogTitle
                }).ToList();
            }
            return bm;
        }
    }
}
