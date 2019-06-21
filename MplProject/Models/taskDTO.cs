using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MplProject.Models
{
    public class taskDTO
    {
        public task taskData
        {
            get;
            set;
        }
        public List<task> taskList
        {
            get;
            set;
        }
    }
}