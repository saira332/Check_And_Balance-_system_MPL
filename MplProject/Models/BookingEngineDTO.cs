using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MplProject.Models
{
    public class BookingEngineDTO
    {
        public booking_engine booking_engineData
        {
            get;
            set;
        }
        public List<booking_engine> booking_engineList
        {
            get;
            set;
        }
    }
}