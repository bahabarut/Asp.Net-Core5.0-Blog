using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace Asp.Net_Core5._0_Blog.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryRepository());
            var values = cm.GetList();

            return View(values);
        }
    }
}
