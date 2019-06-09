using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MplProject.Models
{
    public class CusomerDTO
    {
        public customer customerData
        {
            get;
            set;
        }
        public List<customer> customerList
        {
            get;
            set;
        }
    }
}