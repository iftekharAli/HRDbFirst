using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRDbFirst.Models
{
    public class AppCode
    {
        public string ApplicationCode { get; set; }
    }
    public class ListOfChechBox
    {
        public List<spAppliedLeavesByDept_Result> ListCheckAppCodes { get; set; }
    }
}