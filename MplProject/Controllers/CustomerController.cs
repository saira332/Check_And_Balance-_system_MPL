using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CheckAndBalanceEntities _db;
        public CustomerController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            var CusData = new CusomerDTO()
            {
                customerList = _db.customers.ToList()
            };
            //var results = (from row in _db.customers select row).ToList();
            return View(CusData);
        }
       
        [HttpPost]
        public ActionResult AddCustomer(CusomerDTO c)
        {
            _db.customers.Add(c.customerData);
            _db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        

        [HttpPut]
        public ActionResult EditCustomer(CusomerDTO s, int id)
        {
            customer result = _db.customers.Single(customer => customer.id == id);
            result.name = s.customerData.name;
            result.gender = s.customerData.gender;
            result.email = s.customerData.email;
            result.address = s.customerData.address;
            result.contact_no = s.customerData.contact_no;
            _db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        [HttpDelete]
        public ActionResult DeleteCustomer(int id)
        {
            var result = _db.customers.Single(customer => customer.id == id);
            _db.customers.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}