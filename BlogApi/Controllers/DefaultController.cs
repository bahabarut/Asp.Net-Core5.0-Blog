using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee e)
        {
            using var c = new Context();
            c.Employees.Add(e);
            c.SaveChanges();
            return Ok(e);
        }
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var emp = c.Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(emp);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var emp = c.Employees.Find(id);
            if (emp == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(emp);
                c.SaveChanges();
                return Ok(emp);
            }
        }
        [HttpPut]
        public IActionResult EmployeeUpdate(Employee emp)
        {
            using var c = new Context();
            //var employe = c.Employees.Find(emp.ID);
            var employe = c.Find<Employee>(emp.ID);
            if (employe == null)
            {
                return NotFound();
            }
            else
            {
                employe.Name = emp.Name;
                c.Update(employe);
                c.SaveChanges();
                return Ok(emp);
            }
        }
    }
}
