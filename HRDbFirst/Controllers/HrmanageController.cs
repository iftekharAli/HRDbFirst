using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using System.Net.Http;

namespace HRDbFirst.Controllers
{
    public class HrmanageController : Controller
    {
        private HREntities _context;

        public HrmanageController()
        {
            _context = new HREntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Hrmanage
        public ActionResult Index()
        {
            string code = "4110DC27-5FB5-4669-A741-C47FF2DBC755";
            DateTime todate = Convert.ToDateTime(DateTime.Now);
            var listOfLeave = _context.tbl_Leave_Applications.OrderByDescending(x => x.LastUpdate)
                .Where(x => x.EmployeeCode == code && x.TimeStamp <= todate).ToList().Take(5);
          //  _context.spLeaveReport_Result = _context.spLeaveReport(code).ToList();
            var courseList = _context.Database.SqlQuery<spLeaveReport_Result>("exec spLeaveReport @EmployeeCode ", 
                new SqlParameter("@EmployeeCode", "4110DC27-5FB5-4669-A741-C47FF2DBC755")).
                ToList<spLeaveReport_Result>();
            return View(listOfLeave);

        }


        public ActionResult EmployeeList()
        {
            var emplist = _context.Database.SqlQuery<spViewEmployees_Result>(
                "exec spViewEmployees @EmployeeCode,@EmployeeName,@DeptCode,@IsManager",
                new SqlParameter("@EmployeeCode", ""),
                new SqlParameter("@EmployeeName", ""),
                new SqlParameter("@DeptCode", "'D9DB884C-A2A1-4255-AFC7-B0F51FFBCB68'"),
                new SqlParameter("@IsManager", "")).ToList<spViewEmployees_Result>();
            return View(emplist);
        }

        [HttpPost]
        public ActionResult Index(string ToDate,string FromDate)
        {
            string code = "4110DC27-5FB5-4669-A741-C47FF2DBC755";
            DateTime todate = Convert.ToDateTime(ToDate);
            DateTime fromdate = Convert.ToDateTime(FromDate);
            var listOfLeave = _context.tbl_Leave_Applications.OrderByDescending(x => x.LastUpdate)
                .Where(x => x.EmployeeCode == code && x.LeaveFrom >= fromdate && x.LeaveTill <= todate).ToList().Take(5);
            ///var aaa = _context.spLeaveReport("5841AB7B-8ED8-4927-8972-782600C0E3B3").ToList();

            return View(listOfLeave);

        }
        public ActionResult Create()
        {
            int[] leavInts = { 6, 8, 10 };
            ViewData["LeaveApplication"] = _context.tbl_LeaveDefinition.Where(x=>leavInts.Contains(x.LeaveId)).Select(x => new { Name = x.LeaveName, Id = x.LeaveCode }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Leave_Applications aa, HttpPostedFileBase file)
        {
            var allowedExtensions = new[] { ".pdf", ".zip", ".rar" };
            int[] leavInts = { 6, 8, 10 };
            var extension = Path.GetExtension(file.FileName);
            extension = extension.Substring(1, (extension.Length - 1));
            ViewData["LeaveApplication"] = _context.tbl_LeaveDefinition.Where(x => leavInts.Contains(x.LeaveId)).Select(x => new { Name = x.LeaveName, Id = x.LeaveCode }).ToList();

            if (extension.ToUpper() != "ZIP")
            {
                ModelState.AddModelError("", "Must Upload Zip file");
                return View();
            }
            // aa.ApplicationCode = "BFE5C06C-150D-4418-A887-39BD7B232307";
            //var psk = _context.tbl_Leave_Applications.Find(aa.ApplicationCode);
            //_context.Entry(psk).CurrentValues.SetValues(aa);
            var insertIntoLeaveApplication = new tbl_Leave_Applications()
            {


                 EmployeeCode = "4110DC27-5FB5-4669-A741-C47FF2DBC755",
                 LeaveCode = aa.LeaveCode,
                 DeptCode = "D9DB884C-A2A1-4255-AFC7-B0F51FFBCB68",
                 LeaveFrom = Convert.ToDateTime(aa.LeaveFrom),
                 LeaveTill = Convert.ToDateTime(aa.LeaveTill),
                 ApplicantComment = aa.ApplicantComment,
                 SupportingDocZip = file.FileName,
                 InsuranceCalimPDF = "",
                 ResponsiblePersons = aa.ResponsiblePersons,
                 SupervisorApproval = "N",
                 DirectorApproval = "N",
                 isHalf = false,
                 LastUpdate = DateTime.Now,
                 TimeStamp = DateTime.Now



            };
            _context.tbl_Leave_Applications.Add(insertIntoLeaveApplication);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var AppCodeToDelete = _context.tbl_Leave_Applications.Find(id);
            _context.tbl_Leave_Applications.Remove(AppCodeToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}