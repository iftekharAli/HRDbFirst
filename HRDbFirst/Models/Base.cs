using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRDbFirst.Models
{
    public class Base
    {
        public partial class spAppliedLeavesByDept_ResultAA
        {
            [Key]
            public string ApplicationCode { get; set; }

            public bool AA { get; set; }
            public string EmployeeCode { get; set; }
            public string FullName { get; set; }
            public string DeptName { get; set; }
            public string LeaveCode { get; set; }
            public string LeaveName { get; set; }
            public System.DateTime TimeStamp { get; set; }
            public System.DateTime LeaveFrom { get; set; }
            public System.DateTime LeaveTill { get; set; }
            public string ApplicantComment { get; set; }
            public string SupportingDocZip { get; set; }
            public string InsuranceCalimPDF { get; set; }
            public string ResponsiblePersons { get; set; }
            public string SupervisorApproval { get; set; }
            public string DirectorApproval { get; set; }
            public string DirectorComment { get; set; }
            public string SupervisorComment { get; set; }
            public string EmployeeEmail { get; set; }
        }
    }
}