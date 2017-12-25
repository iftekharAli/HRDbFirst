using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HRDbFirst.Models;

namespace HRDbFirst.Controllers
{
    public class LeaveManageController : ApiController
    {
        private HREntities _context;

        public LeaveManageController()
        {
            _context = new HREntities();
        }
        [HttpGet]
        public object List()
        {
            var linqleaveList = _context.tbl_Leave_Applications
                .Join(_context.tbl_Employees, la => la.EmployeeCode, emp => emp.EmployeeCode, (la, emp) => new
                {
                    la,
                    emp
                }).Join(_context.tbl_LeaveDefinition, ld => ld.la.LeaveCode, def => def.LeaveCode, (ld, def) => new
                {


                    ld.la,
                    ld.emp,
                    def

                })
                .Join(_context.tbl_LeaveStatistics_Employee, emp => new {emp.emp.EmployeeCode, emp.def.LeaveCode},
                    stat => new {stat.EmployeeCode, stat.LeaveCode}, (emp, stat) => new
                    {

                        emp.la,
                        emp.def,
                        emp.emp,
                        stat
                    })
                .Join(_context.tbl_Dept_VU, la => new {ldcode = la.la.DeptCode, edcode = la.emp.DeptCode},
                    dept => new {ldcode = dept.DeptCode, edcode = dept.DeptCode}, (la, dept) => new
                    {
                        la.la,
                        la.def,
                        la.emp,
                        la.stat,
                        dept
                    

                    }).Select(m => new
                {
                    m.la.EmployeeCode,
                    m.la.DirectorApproval,
                    m.la.DeptCode
                   
                }).Where(x => x.DirectorApproval.Contains("N") && x.DeptCode.Contains("")).ToList();
                    


            var leaveList = _context.Database.SqlQuery<spAppliedLeavesByDept_Result>("EXEC HR.dbo.spAppliedLeavesByDept @DeptCode,@LeaveStatus,@EmpCode,@type ",
                    new SqlParameter("@DeptCode", "%%"),
                    new SqlParameter("@LeaveStatus", "P"),
                    new SqlParameter("@EmpCode", "91D3B841-2252-4F41-A715-B64EA919704C"),
                    new SqlParameter("@type", 1)

                ).
                ToList<spAppliedLeavesByDept_Result>();
            return leaveList;
        }
        [HttpPost]
        public void Rr(List<Base.spAppliedLeavesByDept_ResultAA> aa)
        {
            foreach (var VARIABLE in aa)
            {
                string a = VARIABLE.ApplicationCode;
            }
        }
    }
}
