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
    
    public partial class tbl_Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Employees()
        {
            this.tbl_LeaveStatistics_Employee = new HashSet<tbl_LeaveStatistics_Employee>();
            this.tbl_Leave_Applications = new HashSet<tbl_Leave_Applications>();
            this.tbl_Salary_info = new HashSet<tbl_Salary_info>();
        }
    
        public string EmployeeCode { get; set; }
        public int EmployeeID { get; set; }
        public string UserCode { get; set; }
        public string AttendanceID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeEmail { get; set; }
        public string Photo { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Designation { get; set; }
        public string ContactDetails { get; set; }
        public string EmergencyContactDetails { get; set; }
        public string BloodGroup { get; set; }
        public string NationalID { get; set; }
        public string NationalIDScanned { get; set; }
        public System.DateTime AppointmentDate { get; set; }
        public Nullable<System.DateTime> ResignationDate { get; set; }
        public string DeptCode { get; set; }
        public string SupervisorCode { get; set; }
        public string LeaveMailaddress1 { get; set; }
        public string LeaveMailaddress2 { get; set; }
        public string isManager { get; set; }
        public string Telephone { get; set; }
        public string AppointmentLetter { get; set; }
        public string Expired { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public int ModifyCount { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public string Status { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactMobileNo { get; set; }
        public string EmergencyContactRelation { get; set; }
        public string EmergencyContactNID { get; set; }
        public string NocAndNda { get; set; }
        public string Etin { get; set; }
    
        public virtual tbl_Dept_VU tbl_Dept_VU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_LeaveStatistics_Employee> tbl_LeaveStatistics_Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Leave_Applications> tbl_Leave_Applications { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Salary_info> tbl_Salary_info { get; set; }
    }
}
