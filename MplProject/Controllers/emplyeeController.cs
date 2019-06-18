using MplProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MplProject.Controllers
{
    public class emplyeeController : Controller
    {
        Models.CheckAndBalanceEntities _db;
        public emplyeeController()
        {
            _db = new CheckAndBalanceEntities();
        }

    }
}