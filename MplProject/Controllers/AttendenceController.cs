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
        public ActionResult AddAttendence(HttpPostedFileBase file, AttendenceDTO c)
        {
            string realpath = Server.MapPath("/images") + "//" + file.FileName;
            file.SaveAs(realpath);
            c.attendenceData.path = file.FileName;
            _db.attendences.Add(c.attendenceData);
            _db.SaveChanges();
            return RedirectToAction("Index", "Attendence");
        }
        [HttpDelete]
        public ActionResult DeleteAttendence(int id)
        {
            var result = _db.attendences.Single(attendence => attendence.Attn_id == id);
            _db.attendences.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "Attendence");
        }
        [HttpPut]
        public ActionResult EditAttendence(HttpPostedFileBase file, AttendenceDTO s, int id)
        {
            string realpath = Server.MapPath("/images") + "//" + file.FileName;
            file.SaveAs(realpath);
            attendence result = _db.attendences.Single(attendence => attendence.Attn_id == id);
            result.Attn_id= s.attendenceData.Attn_id;
            result.date = s.attendenceData.date;
            result.atendence = s.attendenceData.atendence;
            result.emp_id = s.attendenceData.emp_id;
            result.path = file.FileName;
            _db.SaveChanges();
            return RedirectToAction("Index", "Attendence");
        }
    }
}