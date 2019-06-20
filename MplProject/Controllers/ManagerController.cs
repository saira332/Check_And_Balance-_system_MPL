using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class ManagerController : Controller
    {

        // GET: Manager
        Models.CheckAndBalanceEntities _db;
        public ManagerController()
        {
            _db = new CheckAndBalanceEntities();
        }

        public ActionResult Index()
        {
            var ManData = new ManagerDTO()
            {
                managerList = _db.managers.ToList()
            };
            //var results = (from row in _db.customers select row).ToList();
            return View(ManData);
        }
        [HttpPost]
        public ActionResult AddManager(HttpPostedFileBase file, ManagerDTO c)
        {
            string realpath = Server.MapPath("/images") + "//" + file.FileName;
            file.SaveAs(realpath);
            _db.managers.Add(c.managerData);
            _db.SaveChanges();
            return RedirectToAction("Index", "Manager");
        }
        [HttpDelete]
        public ActionResult DeleteManager(int id)
        {
            var result = _db.managers.Single(manager => manager.id== id);
            _db.managers.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "Manager");
        }
        [HttpPut]
        public ActionResult EditManager(HttpPostedFileBase file, ManagerDTO s, int id, string name)
        {
            string realpath = Server.MapPath("/images") + "//" + file.FileName;
            file.SaveAs(realpath);
            manager result = _db.managers.Single(manager => manager.id == id);
            result.name = name;
            result.email = s.managerData.email;
            result.gender = s.managerData.gender;
            result.address = s.managerData.address;
            result.contact_no = s.managerData.contact_no;
            result.insurance = s.managerData.insurance;
            result.salary = s.managerData.salary;
            result.start_date = s.managerData.start_date;
            result.terminated_date = s.managerData.terminated_date;
            result.CNIC = s.managerData.CNIC;
            result.bonous = s.managerData.bonous;
            _db.SaveChanges();
            return RedirectToAction("Index", "Manager");
        }
    }
}