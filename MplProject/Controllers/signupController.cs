using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MplProject.Models;

namespace MplProject.Controllers
{
    public class signupController : Controller
    {
        // GET: signup
        CheckAndBalanceEntities _db;
        public signupController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult usersignup(signup s)
        {
            _db.signups.Add(s);
            _db.SaveChanges();
            return RedirectToAction("ImageUpload", "signup",new {id=s.id });
        }
        public ActionResult ImageUpload(int id)
        {
            var data = _db.signups.Single(signup => signup.id == id);
            //List<signup> result = (from k in _db.signups select k).ToList();
            return View(data);
        }
        [HttpPut]
        public ActionResult ImageUpload(HttpPostedFileBase file,signup u)
        {
            string realpath = Server.MapPath("/images") + "//" + file.FileName;
            file.SaveAs(realpath);

            var data = _db.signups.Single(signup => signup.id == u.id);
            //signup u = new signup();
            u.path = file.FileName;
            data.path = u.path;
            _db.SaveChanges();
            return RedirectToAction("ImageUpload", "signup",new { id=u.id});
        }
    }

}