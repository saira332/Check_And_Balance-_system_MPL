using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class emplyeeController : Controller
    {
        Models.CheckAndBalanceEntities _db;
        public emplyeeController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            var empData = new employeeDTO()
            {
                employeeList = _db.employees.ToList()
            };
            return View(empData);
        }
        [HttpPost]
        public ActionResult Addemplyee(employeeDTO c)
        {
            //string realpath = Server.MapPath("/images") + "//" + file.FileName;
            //file.SaveAs(realpath);
            //c.employeeData.path = file.FileName;
            _db.employees.Add(c.employeeData);
            _db.SaveChanges();
            return RedirectToAction("Index", "emplyee");
        }
        [HttpDelete]
        public ActionResult Deleteemplyee(int id)
        {
            var result = _db.employees.Single(employee => employee.emp_id == id);
            _db.employees.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "emplyee");
        }
        [HttpPut]
        public ActionResult Editemplyee(employeeDTO s, int id)
        {
            //string realpath = Server.MapPath("/images") + "//" + file.FileName;
            //file.SaveAs(realpath);
            employee result = _db.employees.Single(employee => employee.emp_id == id);
            result.emp_id = s.employeeData.emp_id;
            result.name = s.employeeData.name;
            result.salary = s.employeeData.salary;
            result.gender = s.employeeData.gender;
            result.contact_no = s.employeeData.contact_no;
            result.email = s.employeeData.email;
            result.address = s.employeeData.address;
            result.task = s.employeeData.task;
            result.insurance = s.employeeData.insurance;
            result.overtime = s.employeeData.overtime;
            result.start_date = s.employeeData.start_date;
            result.terminated_date = s.employeeData.terminated_date;
            result.CNIC = s.employeeData.CNIC;
            result.bonous = s.employeeData.bonous;
            //result.path = file.FileName;
            _db.SaveChanges();
            return RedirectToAction("Index", "emplyee");
        }
    }
}