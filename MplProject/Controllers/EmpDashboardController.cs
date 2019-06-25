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
        public ActionResult dash()
        {
            if(Session["username"]== null)
            {
                return RedirectToAction("Index", "LoginView");
            }
            else
            {
                string name = Session["username"].ToString();
                var result = _db.signups.Single(signup => signup.username == name);
                if (result.status == "Admin")
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (result.status == "Employee")
                {
                    return RedirectToAction("Index", "EmpDashboard");
                }
                return RedirectToAction("Index", "Home");
            }
           
        }
    }
}