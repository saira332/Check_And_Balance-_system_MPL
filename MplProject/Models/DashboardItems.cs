using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MplProject.Models
{
    public class DashboardItems
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
        public employee employeeData
        {
            get;
            set;
        }
        public List<employee> employeeList
        {
            get;
            set;
        }
        public order orderData
        {
            get;
            set;
        }
        public List<order> orderList
        {
            get;
            set;
        }
        public signup signupData
        {
            get;
            set;
        }
        public List<signup> signupList
        {
            get;
            set;
        }

    }
}