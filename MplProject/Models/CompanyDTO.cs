using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MplProject.Models
{
    public class CompanyDTO
    {
        public company_details companyData
        {
            get;
            set;
        }
        public List<company_details> companyList
        {
            get;
            set;
        }
    }
}