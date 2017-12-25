using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRDbFirst.Models;

namespace HRDbFirst.Controllers
{
    public class LeaveController : Controller
    {
        private HREntities _context;

        public LeaveController()
        {
                _context=new HREntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Leave
        public ActionResult Index()
        {


            //var leaveList = _context.Database.SqlQuery<spAppliedLeavesByDept_Result>("EXEC HR.dbo.spAppliedLeavesByDept @DeptCode,@LeaveStatus,@EmpCode,@type ",
            //        new SqlParameter("@DeptCode", "%%"),
            //        new SqlParameter("@LeaveStatus", "P"),
            //        new SqlParameter("@EmpCode", "91D3B841-2252-4F41-A715-B64EA919704C"),
            //        new SqlParameter("@type", 1)

            //        ).
            //    ToList<spAppliedLeavesByDept_Result>();
            return View();
          
        }
        [HttpPost]
        public ActionResult Index(IEnumerable<spAppliedLeavesByDept_Result> a)
        {
            var leaveList = _context.Database.SqlQuery<spAppliedLeavesByDept_Result>("EXEC HR.dbo.spAppliedLeavesByDept @DeptCode,@LeaveStatus,@EmpCode,@type ",
                    new SqlParameter("@DeptCode", "%%"),
                    new SqlParameter("@LeaveStatus", "P"),
                    new SqlParameter("@EmpCode", "91D3B841-2252-4F41-A715-B64EA919704C"),
                    new SqlParameter("@type", 1)

                ).
                ToList<spAppliedLeavesByDept_Result>();
            return View(leaveList);

        }
    }
}