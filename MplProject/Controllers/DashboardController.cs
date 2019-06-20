using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        CheckAndBalanceEntities _db;
        public DashboardController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {

            var customers = (from a in _db.customers select a).ToList();
            var products = (from a in _db.products select a).ToList();

            DashboardItems d = new DashboardItems();
            d.customerList = customers;
            d.productList = products;
           

            return View(d);
        }
        public ActionResult OnlineUsers()
        {
            return View();
        }
        public ActionResult Tasks()
        {
            List<employee> em = (from a in _db.employees select a).ToList();
            ViewBag.employees = em;
            return View();
        }
        [HttpPost]
        public ActionResult Tasks(int employe,task t)
        {
            employee c = _db.employees.Single(data => data.id == employe);
            t.employee = c;
            _db.tasks.Add(t);
            _db.SaveChanges();

            return RedirectToAction("Tasks", "Dashboard");
        }
    }
}