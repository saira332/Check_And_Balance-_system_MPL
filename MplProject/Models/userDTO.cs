using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MplProject.Models
{
    public class userDTO
    {
        public signup userData
        {
            get;
            set;
        }
        public List<signup> userList
        {
            get;
            set;
        }
    }
}