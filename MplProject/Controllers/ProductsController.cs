using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        CheckAndBalanceEntities _db;
        public ProductsController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            var ProData = new ProductsDTO()
            {
                productList = _db.products.ToList()
            };
            //var results = (from row in _db.customers select row).ToList();
            return View(ProData);
        }
     
        [HttpPost]
        public ActionResult AddProduct(HttpPostedFileBase file, ProductsDTO c)
        {
            string realpath = Server.MapPath("/images") + "//" + file.FileName;
            file.SaveAs(realpath);
            c.productData.path = file.FileName;
            _db.products.Add(c.productData);
            _db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
        [HttpDelete]
        public ActionResult DeleteProduct(int id)
        {
            var result = _db.products.Single(product => product.pro_id == id);
            _db.products.Remove(result);
            _db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
        [HttpPut]
        public ActionResult EditProduct(HttpPostedFileBase file, ProductsDTO s, int id)
        {
            string realpath = Server.MapPath("/images") + "//" + file.FileName;
            file.SaveAs(realpath);
            product result = _db.products.Single(product => product.pro_id == id);
            result.pro_name = s.productData.pro_name;
            result.price = s.productData.price;
            result.quantity = s.productData.quantity;
            result.quality = s.productData.quality;
            result.description = s.productData.description;
            result.path = file.FileName;
            _db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
       
    }
}