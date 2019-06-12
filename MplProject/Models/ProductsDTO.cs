using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MplProject.Models
{
    public class ProductsDTO
    {
        public product productData
        {
            get;
            set;
        }
        public List<product> productList
        {
            get;
            set;
        }
    }
}