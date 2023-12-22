using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC3.Data;
using MVC3.Migrations;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string email)
        {
            var obj = _db.Employees.FirstOrDefault(e => e.Email == email);
            List<Employee> objEmployeeList = _db.Employees.Where(e => e.UserId == 2).ToList();
            return View(objEmployeeList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            obj.UserId = 2;
            _db.Employees.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Employee created successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee? employeeFromDb = _db.Employees.Find(id);
            return View(employeeFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            obj.UserId = 2;
            _db.Employees.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Employee updated successfully";
            return RedirectToAction("Index");


        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee? employeeFromDb = _db.Employees.Find(id);
            return View(employeeFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Employee? obj = _db.Employees.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Employee deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

