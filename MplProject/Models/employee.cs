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
    
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            this.attendences = new HashSet<attendence>();
            this.tasks = new HashSet<task>();
        }
    
        public int emp_id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }
        public string gender { get; set; }
        public int contact_no { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string task { get; set; }
        public string insurance { get; set; }
        public Nullable<int> overtime { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> terminated_date { get; set; }
        public string CNIC { get; set; }
        public Nullable<int> bonous { get; set; }
        public string path { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<attendence> attendences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> tasks { get; set; }
    }
}
