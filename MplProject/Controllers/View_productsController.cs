using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class View_productsController : Controller
    {
        CheckAndBalanceEntities _db;
        public View_productsController()
        {
            _db = new CheckAndBalanceEntities();
        }
        // GET: View_products
        public ActionResult Index()
        {
            var proData = new ProductsDTO()
            {
                productList = _db.products.ToList()
            };
            return View(proData);
        }
        [HttpPost]
        public ActionResult Cart(int id,int price,cart c)
        {
            
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "LoginView");
            }
            else
            {
                string uname = Session["username"].ToString();
                c.cus_id = uname;
                c.total = price;
                c.pro_id = id;
                c.price = price;
                _db.carts.Add(c);
                _db.SaveChanges();
                return RedirectToAction("Index","View_products");
            }
        }
        public ActionResult Cart()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "LoginView");
            }
            else
            {
                string uname = Session["username"].ToString();
                List<cart> result = (from a in _db.carts select a).ToList();
                foreach(var i in result)
                {
                    if(i.cus_id == uname)
                    {
                        return View(result);
                    }
                }

                return RedirectToAction("Index", "View_products");
            }
        }
        public ActionResult DeleteCart(int id, cart c)
        {
            var result = _db.carts.Single(cart => cart.id == id);
            _db.carts.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Cart", "View_Products");
            
        }
        [HttpPost]
        public ActionResult Orders(order o,int total)
        {
            ViewBag.Total = total;
            Session["total"] = total;
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "LoginView");
            }
            else
            {
                string uname = Session["username"].ToString();
                o.cus_id = uname;
                o.status = "In Progress";
                _db.orders.Add(o);
                _db.SaveChanges();
                return RedirectToAction("Orders", "View_products");
            }

        }
        public ActionResult Orders()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "LoginView");
            }
            else
            {
                string name = Session["username"].ToString();
                var result = (from a in _db.orders select a).ToList();
                //var result = _db.orders.Single(order => order.cus_id == name);
                return View();
            }
        }
        public ActionResult Payement()
        {
            ViewBag.Total = Session["total"];
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "LoginView");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Payement(payment p, int total)
        {
            p.total_price = total;
            _db.payments.Add(p);
            _db.SaveChanges();
            Session["pay_price"] = p.paid_price;
            if(p.paid_price == total)
            {
                var return_price = 0;
                Session["return_price"] = return_price;
            }
            else if(p.paid_price > total)
            {
                var return_price = total - p.paid_price;
                Session["return_price"] = return_price;
            }
            else
            {
                var return_price = 0;
                Session["return_price"] = return_price;
            }
            var re = (from k in _db.carts select k).ToList();
            _db.carts.RemoveRange(re);
            _db.SaveChanges();
            return RedirectToAction("Bill","View_products");
        }
        public ActionResult Bill(payment p)
        {
            var return_price = Session["return_price"];
            var total_price = Session["total"];
            var uname = Session["username"];
            var paid_price = Session["pay_price"];
            return View();
        }
    }
}