using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class ViewProductsController : Controller
    {
        // GET: ViewProducts
        CheckAndBalanceEntities _db;
        public ViewProductsController()
        {
            _db = new CheckAndBalanceEntities();
        }
        public ActionResult Index()
        {
            var ProData = new ProductsDTO()
            {
                productList = _db.products.ToList()
            };
            return View(ProData);
        }
    }
}