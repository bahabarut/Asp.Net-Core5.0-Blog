using Asp.Net_Core5._0_Blog.Areas.Admin.Models;
using Asp.Net_Core5._0_Blog.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Core5._0_Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")] //Admin veye moderator olanlar erişebiliyor
    public class AdminRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult RoleAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleAdd(RoleViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole()
                {
                    Name = p.name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View();
        }
        [HttpGet]
        public IActionResult RoleEdit(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel value = new RoleUpdateViewModel()
            {
                id = role.Id,
                name = role.Name
            };

            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleUpdateViewModel p)
        {
            if (ModelState.IsValid)
            {
                var value = _roleManager.Roles.Where(x => x.Id == p.id).FirstOrDefault();
                value.Name = p.name;
                var result = await _roleManager.UpdateAsync(value);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(p);
        }
        public async Task<IActionResult> RoleDelete(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {

            //bütün rolleri ve seçtiğimiz kullanıcıyı çekiyoruz 
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            //seçtiğimiz kullanıcının rollerini çekiyoruz
            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssingViewModel> model = new List<RoleAssingViewModel>();
            foreach (var item in roles)
            {
                RoleAssingViewModel m = new RoleAssingViewModel();
                m.RoleID = item.Id;//role id sini atıyoruz
                m.Name = item.Name;//role adını atıyoruz
                m.Exists = userRoles.Contains(item.Name); //rol bu kullanıcıda kayıtlı mı değil mi onu beliriyoruz bool olarak
                model.Add(m);

            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssingViewModel> p)
        {
            var userid = (int)TempData["UserId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in p)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("UserRoleList");
        }
    }
}
