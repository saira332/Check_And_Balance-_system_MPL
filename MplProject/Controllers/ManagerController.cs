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
        public ActionResult AddManager(ManagerDTO c)
        {
            _db.managers.Add(c.managerData);
            _db.SaveChanges();
            return RedirectToAction("Index", "Manager");
        }
        [HttpDelete]
        public ActionResult DeleteManager(int id)
        {
            var result = _db.managers.Single(manager => manager.id == id);
            _db.managers.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "Manager");
        }
        [HttpPut]
        public ActionResult EditManager(ManagerDTO s, int id, string name)
        {
            manager result = _db.managers.Single(manager => manager.id == id);
            result.name = name;
            //result.pro_name = s.productData.pro_name;
            //result.price = s.productData.price;
            //result.quantity = s.productData.quantity;
            //result.quality = s.productData.quality;
            //result.description = s.productData.description;
            _db.SaveChanges();
            return RedirectToAction("Index", "Manager");
        }
    }
}