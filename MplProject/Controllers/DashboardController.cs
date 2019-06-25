using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class employeetask
    {
        public int emp_id;
        public int id;
        public string tassks;
        public string status;
    }
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
            var employe = (from a in _db.employees select a).ToList();
            var order = (from a in _db.orders select a).ToList();

            DashboardItems d = new DashboardItems();
            d.customerList = customers;
            d.productList = products;
            d.employeeList = employe;
            d.orderList = order;



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
            var emptask = (from s in _db.tasks
                                 from g in _db.employees
                                 where
                                 s.emp_id == g.emp_id
                           select s).ToList();
           ViewBag.employeeetask = emptask;
            return View();
        }
        [HttpPost]
        public ActionResult Tasks(int employees, task t)
        {
            employee c = _db.employees.Single(data => data.emp_id == employees);
            t.employee = c;
            _db.tasks.Add(t);
            _db.SaveChanges();

            return RedirectToAction("Tasks", "Dashboard");
        }
        public ActionResult VisitorsLog()
        {
            var user = new userDTO()
            {
                userList = _db.signups.ToList()
            };
            return View(user);
        }
        public ActionResult orders()
        {
            var result = (from k in _db.orders select k).ToList();
            return View(result);
        }

    }
}