using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class EmpDashboardController : Controller
    {
        // GET: EmpDashboard
        CheckAndBalanceEntities _db;
        public EmpDashboardController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            var result = (from k in _db.tasks select k).ToList();
            return View(result);
        }
    }
}