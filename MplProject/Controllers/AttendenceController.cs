using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class AttendenceController : Controller
    {
        // GET: Attendence
        CheckAndBalanceEntities _db;
        public AttendenceController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            var AttnData = new AttendenceDTO()
            {
                attendenceList = _db.attendences.ToList()
            };
            //var results = (from row in _db.customers select row).ToList();
            return View(AttnData);
        }
        [HttpPost]
        public ActionResult AddAttendence( AttendenceDTO c)
        {
            
            _db.attendences.Add(c.attendenceData);
            _db.SaveChanges();
            return RedirectToAction("Index", "Attendence");
        }
        [HttpDelete]
        public ActionResult DeleteAttendence(int id)
        {
            var result = _db.attendences.Single(attendence => attendence.id == id);
            _db.attendences.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "Attendence");
        }
        [HttpPut]
        public ActionResult EditAttendence( AttendenceDTO s, int id)
        {
            
            attendence result = _db.attendences.Single(attendence => attendence.id == id);
            result.id= s.attendenceData.id;
            result.date = s.attendenceData.date;
            result.aattendence= s.attendenceData.aattendence;
            result.emp_id = s.attendenceData.emp_id;
            _db.SaveChanges();
            return RedirectToAction("Index", "Attendence");
        }
    }
}