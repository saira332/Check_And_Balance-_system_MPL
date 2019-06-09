using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        CheckAndBalanceEntities _db;
        public ProfileController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index(string username)
        {
            ViewBag.username = username;
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "login");
            }
            else
            {
                var result = _db.signups.Single(signup => signup.username == username);
                return View(result);
            }
        }
        [HttpDelete]
        public ActionResult DeleteProfile()
        {
            var username = Session["username"];
            var result = _db.signups.Single(signup => signup.username == username);
            _db.signups.Remove(result);
            _db.SaveChanges();
            return Redirect("/");
        }
        public ActionResult EditProfile()
        {
            var username = Session["username"];
            var result = _db.signups.Single(signup => signup.username == username);
            return View(result);
        }
        [HttpPut]
        public ActionResult EditProfile(signup u)
        {
            signup result = _db.signups.Single(signup => signup.username == u.username);
            result.firstName = u.firstName;
            result.lastName = u.lastName;
            result.email = u.email;
            result.username = u.username;
            result.password = u.password;
            _db.SaveChanges();
            return View();
        }
    }
}