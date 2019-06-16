using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MplProject.Models
{
    public class EmployeeDTO
    {
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
    }
}