//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MplProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class cart
    {
        public int id { get; set; }
        public int cus_id { get; set; }
        public int pro_id { get; set; }
        public int price { get; set; }
        public int total { get; set; }
    
        public virtual product product { get; set; }
    }
}
