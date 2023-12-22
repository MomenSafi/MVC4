using Microsoft.AspNetCore.Mvc;
using MVC3.Data;
using MVC3.Models;
using System.Collections.Generic;

namespace MVC3.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ManagerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string email)
        {
            var obj = _db.Employees.FirstOrDefault(e => e.Email == email);
            List<Employee> objEmployeeList = _db.Employees.Where(e => e.UserId == 3).ToList();
            return View(objEmployeeList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            obj.UserId = 3;
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
            obj.UserId = 3;
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
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(string email, string password)
        {
            var user = _db.Employees.FirstOrDefault(u => u.Email == email);
            if (user.Email == email && user.Password == password)
            {
                if (user.UserId == 2)
                    return RedirectToAction("Index", new { email = user.Email });
                else if (user.UserId == 1)
                    return RedirectToAction("Index", "Admin", new { email = user.Email });
                else
                    return RedirectToAction("Employee", new { email = user.Email });
            }
            else
            {
                ModelState.AddModelError("Email", "Invalid email or password");
                return View();
            }

        }
        public IActionResult Employee(string email)
        {
            var obj = _db.Employees.FirstOrDefault(e => e.Email == email);

            return View(obj);
        }

    }
}
