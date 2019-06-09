using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        CheckAndBalanceEntities _db;
        public CompanyController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            var results = (from row in _db.company_details select row).ToList();
            return View(results);
        }
        //public JsonResult ViewCompany()
        //{
        //    List<company_details> ComList = (from row in _db.company_details select row).ToList();
        //    return Json(ComList, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult AddCompany()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCompany(company_details a)
        {
            _db.company_details.Add(a);
            _db.SaveChanges();
            return View();
        }
        public ActionResult EditCompany(int id)
        {
            var result = _db.company_details.Single(company_details => company_details.company_id == id);
            return View(result);
        }

        [HttpPut]
        public ActionResult EditCompany(company_details s)
        {
            company_details result = _db.company_details.Single(company_details => company_details.company_id == s.company_id);
            result.company_name = s.company_name;
            result.email = s.email;
            result.address = s.address;
            result.contact_no = s.contact_no;
            _db.SaveChanges();
            return View();
        }
        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            var result = _db.company_details.Single(company_details => company_details.company_id == id);
            _db.company_details.Remove(result);
            _db.SaveChanges();
            return Redirect("/");
        }
    }
}