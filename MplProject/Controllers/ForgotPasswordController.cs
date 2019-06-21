using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class ForgotPasswordController : Controller
    {
        // GET: ForgotPassword
        CheckAndBalanceEntities _db;
        public ForgotPasswordController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AccountIdentify(string uname)
        {
            var results = (from row in _db.signups select row);
            foreach (var i in results)
            {
                if (uname == i.username)
                {
                    Session["username"] = uname;

                    //return RedirectToAction("Index", "Profile", new { username = uname });
                    var data = _db.signups.Single(signup => signup.username == uname);
                    return View(data);
                }
            }
            return RedirectToAction("Index","ForgotPassword");
        }
        public ActionResult ResetPasswordThrough(FormCollection frm)
        {

            string ans = frm["acc"].ToString();
            if(ans == "yes")
            {
                return View();
            }
            else
            {
                return RedirectToAction("AccountIdentify", "ForgotPassword");
            }
        }
        public ActionResult SecurityQuestion(string ans)
        {
            if(ans == "Security Question")
            {
                return View();
            }
            else if(ans == "email")
            {
                return RedirectToAction("email", "ForgotPassword");
            }
            return RedirectToAction("ResetPasswordThrough", "ForgotPassword");
        }
        public ActionResult email()
        {
            return View();
        }
        [HttpPost]
        public ActionResult email(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("Puter3176@gmail.com", "I m boondr");
                    var receiverEmail = new MailAddress(receiver, "Receiver");
                    var password = "aabb112233";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }
        public ActionResult ResetPassword(string question, string answer)
        {
            string uname = Session["username"].ToString();
            var data = _db.signups.Single(signup => signup.username == uname);
                if (question == data.SecQuestion && answer==data.SecAnswer)
                {
                    return View(data);
                }
           
            return RedirectToAction("ResetPasswordThrough", "ForgotPassword");
        }
        [HttpPut]
        public ActionResult SetPassword(signup u)
        {
            string uname = Session["username"].ToString();
            var data = _db.signups.Single(signup => signup.username == uname);
            data.password = u.password;
            _db.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    }
}