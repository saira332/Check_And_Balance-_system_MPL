using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class Bookin_EngineController : Controller
    {
        // GET: Bookin_Engine
        CheckAndBalanceEntities _db;
        public Bookin_EngineController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            var BkData = new BookingEngineDTO()
            {
                booking_engineList = _db.booking_engine.ToList()
            };
            //var results = (from row in _db.customers select row).ToList();
            return View(BkData);
     
        }
        [HttpPost]
        public ActionResult AddBooking_Engine( BookingEngineDTO c)
        {
            _db.booking_engine.Add(c.booking_engineData);
            _db.SaveChanges();
            return RedirectToAction("Index", "Bookin_Engine");
        }
        [HttpDelete]
        public ActionResult DeleteBooking_Engine(int id)
        {
            var result = _db.booking_engine.Single(booking_engine => booking_engine.booking_id == id);
            _db.booking_engine.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "Bookin_Engine");
        }
        [HttpPut]
        public ActionResult EditBookin_Engine(HttpPostedFileBase file, BookingEngineDTO s, int id)
        {
            string realpath = Server.MapPath("/images") + "//" + file.FileName;
            file.SaveAs(realpath);
            booking_engine result = _db.booking_engine.Single(booking_engine => booking_engine.booking_id == id);
            result.booking_id = s.booking_engineData.booking_id;
            result.cus_id = s.booking_engineData.cus_id;
            result.pro_id = s.booking_engineData.pro_id;
           // result.paid_price = s.paymentData.paid_price;
       
            _db.SaveChanges();
            return RedirectToAction("Index", "Bookin_Engine");
        }
    }
}