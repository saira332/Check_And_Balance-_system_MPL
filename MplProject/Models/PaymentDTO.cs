using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MplProject.Models
{
    public class PaymentDTO
    {
        public payment paymentData
        {
            get;
            set;
        }
        public List<payment> paymentList
        {
            get;
            set;
        }
    }
}