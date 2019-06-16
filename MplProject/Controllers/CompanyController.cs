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
            var CoData = new CompanyDTO()
            {
                companyList = _db.company_details.ToList()
            };
            //var results = (from row in _db.company_details select row).ToList();
            return View(CoData);
        }
       
       
        [HttpPost]
        public ActionResult AddCompany(CompanyDTO a)
        {
            _db.company_details.Add(a.companyData);
            _db.SaveChanges();
            return RedirectToAction("Index", "Company");
        }
        [HttpDelete]
        public ActionResult DeleteCompany(int id)
        {
            var result = _db.company_details.Single(company_details=> company_details.company_id == id);
            _db.company_details.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "Company");
        }
        [HttpPut]
        public ActionResult EditCompany(CompanyDTO s, int id)
        {
            company_details result = _db.company_details.Single(company_details => company_details.company_id == id);

            result.company_name = s.companyData.company_name;
            result.email = s.companyData.email;
            result.address = s.companyData.address;
            result.contact_no = s.companyData.contact_no;
            _db.SaveChanges();
            return RedirectToAction("Index", "Company");
        }
    }
}