//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRDbFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Dept_VU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Dept_VU()
        {
            this.tbl_Employees = new HashSet<tbl_Employees>();
            this.tbl_Leave_Applications = new HashSet<tbl_Leave_Applications>();
        }
    
        public string DeptCode { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string Enabled { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public int ModifyCount { get; set; }
        public System.DateTime LastUpdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Employees> tbl_Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Leave_Applications> tbl_Leave_Applications { get; set; }
    }
}