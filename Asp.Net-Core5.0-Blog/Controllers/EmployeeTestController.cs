using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net_Core5._0_Blog.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var resMessage = await httpClient.GetAsync("https://localhost:44361/api/Default");
            var jsonString = await resMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmp = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmp, Encoding.UTF8, "application/json");
            var resMessage = await httpClient.PostAsync("https://localhost:44361/api/Default", content);
            if (resMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var httpClient = new HttpClient();
            var resMessage = await httpClient.GetAsync($"https://localhost:44361/api/Default/{id}");
            if (resMessage.IsSuccessStatusCode)
            {
                var jsonEmp = await resMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Class1>(jsonEmp);
                return View(value);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmp = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmp, Encoding.UTF8, "application/json");
            var resMessage = await httpClient.PutAsync("https://localhost:44361/api/Default", content);
            if (resMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var httpClient = new HttpClient();
            var resMessage = await httpClient.DeleteAsync($"https://localhost:44361/api/Default/{id}");
            if (resMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
