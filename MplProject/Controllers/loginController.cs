using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MplProject.Models;
using Facebook;
using System.Web.Security;

namespace MplProject.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        CheckAndBalanceEntities _db;
        public loginController()
        {
            _db = new CheckAndBalanceEntities();
        }
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            if(Session["username"] != null)
            {
               return RedirectToAction("Index", "Profile", new {username = Session["username"].ToString() });
            } 
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult userLogin(string name, string password)
        {
            var results = (from row in _db.signups select row);
            foreach(var i in results)
            {
                if (name == i.username  && password == i.password)
                {
                    Session["username"] = name;

                    return RedirectToAction("Index", "Profile", new { username = name });
                }
            }

            return View();
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "login");
        }
        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = "282005856012240",
                client_secret = "f0ee58aebda5ef05504d4f98dc0dba9b",
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });

            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "282005856012240",
                client_secret = "f0ee58aebda5ef05504d4f98dc0dba9b",
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            Session["AccessToken"] = accessToken;

            fb.AccessToken = accessToken;
            dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
            string email = me.email;
            string firstname = me.first_name;
            string middlename = me.middle_name;
            string lastname = me.last_name;

            FormsAuthentication.SetAuthCookie(email, false);
            return RedirectToAction("Index", "Home");
        }
    }
}
