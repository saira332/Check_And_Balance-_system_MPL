using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MplProject.Models
{
    public class AttendenceDTO
    {
        public attendence attendenceData
        {
            get;
            set;
        }
        public List<attendence> attendenceList
        {
            get;
            set;
        }

    }
}