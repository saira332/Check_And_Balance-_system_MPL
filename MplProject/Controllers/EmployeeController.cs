using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class EmployeeController : Controller
    {
        Models.CheckAndBalanceEntities _db;
        public EmployeeController()
        {
            _db = new CheckAndBalanceEntities();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var ProData = new EmployeeDTO()
            {
                employeeList = _db.employees.ToList()
            };
            //var results = (from row in _db.customers select row).ToList();
            return View(ProData);
        }
        [HttpPost]
        public ActionResult AddProduct(EmployeeDTO c)
        {
            _db.employees.Add(c.employeeData);
            _db.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
        [HttpDelete]
        public ActionResult DeleteEmployee(int id)
        {
            var result = _db.employees.Single(employee => employee.E_id == id);
            _db.employees.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
        [HttpPut]
        public ActionResult EditEmployee(EmployeeDTO s, int id, string name)
        {
            employee result = _db.employees.Single(employee => employee.E_id == id);
            result.E_name = name;
            //result.pro_name = s.productData.pro_name;
            //result.price = s.productData.price;
            //result.quantity = s.productData.quantity;
            //result.quality = s.productData.quality;
            //result.description = s.productData.description;
            _db.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
    }
}