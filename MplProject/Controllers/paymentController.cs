using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class paymentController : Controller
    {
        // GET: payment
        CheckAndBalanceEntities _db;
        public paymentController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            var PayData = new PaymentDTO()
            {
                paymentList = _db.payments.ToList()
            };
            //var results = (from row in _db.customers select row).ToList();
            return View(PayData);
        }
        [HttpPost]
        public ActionResult AddPayment(HttpPostedFileBase file, PaymentDTO c)
        {
            string realpath = Server.MapPath("/images") + "//" + file.FileName;
            file.SaveAs(realpath);
            c.paymentData.path = file.FileName;
            _db.payments.Add(c.paymentData);
            _db.SaveChanges();
            return RedirectToAction("Index", "Payments");
        }
        [HttpDelete]
        public ActionResult DeletePayment(int id)
        {
            var result = _db.payments.Single(payment => payment.pay_id == id);
            _db.payments.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "Payments");
        }
        [HttpPut]
        public ActionResult EditPayment(HttpPostedFileBase file, PaymentDTO s, int id)
        {
            string realpath = Server.MapPath("/images") + "//" + file.FileName;
            file.SaveAs(realpath);
            payment result = _db.payments.Single(payment => payment.pay_id == id);
            result.total_price = s.paymentData.total_price;
            result.discount = s.paymentData.discount;
            result.source = s.paymentData.source;
            result.paid_price = s.paymentData.paid_price;
            result.path = file.FileName;
            _db.SaveChanges();
            return RedirectToAction("Index", "Payments");
        }
    }
}