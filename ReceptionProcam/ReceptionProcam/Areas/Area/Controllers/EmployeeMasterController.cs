using ReceptionProcam.Areas.Area.Models;
using ReceptionProcam.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReceptionProcam.Areas.Area.Controllers
{
    public class EmployeeMasterController : Controller
    {
        DBNCSVisitorEntities objAdminEnti = new DBNCSVisitorEntities();

        [HttpGet]
        public ActionResult EmployeeMaster()
        {
            //EmployeeMasters master = new EmployeeMasters();
            GetDesignationList();
            return View();
        }
        [HttpGet]
        public void GetDesignationList()
        {
            ViewBag.DesignationList =  (from c in objAdminEnti.tblEmpDesignationMasters select new SelectListItem { Text = c.EmpDesignationName, Value = c.ID.ToString() }).ToList();
        }

        [HttpPost]
        public ActionResult EmployeeMaster(EmployeeMasters objMaster)
        {
            if (ModelState.IsValid)
            {
                tblEmployeeDetail master = new tblEmployeeDetail();
                master.EmpName = objMaster.EmpName;
                master.EmpCode = objMaster.EmpCode;
                master.EmpDesignationID = objMaster.EmpDesignationID;
                master.EmpDept = objMaster.EmpDept;
                master.CreatedDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd-MM-yyyy hh:mm"));
                master.ModifiedDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd-MM-yyyy hh:mm"));
                objAdminEnti.tblEmployeeDetails.Add(master);
                objAdminEnti.SaveChanges();
                TempData["Success"] = "Employee added successfully.";
                return RedirectToAction("EmployeeMaster");
            }
            return View();
        }

        //[HttpGet]
        //public ActionResult PurposeList()
        //{
        //    var purposeList = objAdminEnti.tblPurposeMasters.OrderByDescending(x => x.Id).ThenBy(x => x.CreatedDate).ToList();
        //    ViewBag.AllPurposeDetails = purposeList;
        //    return View();
        //}


        //[HttpGet]
        //public ActionResult EditPurpose(int Id)
        //{
        //    var VisData = objAdminEnti.tblPurposeMasters.Where(s => s.Id == Id).FirstOrDefault();
        //    PurposeMasters VisDtls = new PurposeMasters { Id = VisData.Id, PurposeName = VisData.PurposeName, PurposeCode = VisData.PurposeCode };
        //    return View(VisDtls);
        //}

        //[HttpPost]
        //public ActionResult EditPurpose(int Id, PurposeMasters objMaster)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dbPurpose = objAdminEnti.tblPurposeMasters.SingleOrDefault(b => b.Id == Id);
        //        if (dbPurpose != null)
        //        {
        //            dbPurpose.PurposeName = objMaster.PurposeName;
        //            dbPurpose.PurposeCode = objMaster.PurposeCode;
        //            dbPurpose.ModifiedDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd-MM-yyyy hh:mm"));
        //            objAdminEnti.tblPurposeMasters.Add(dbPurpose);
        //            objAdminEnti.tblPurposeMasters.Attach(dbPurpose);
        //            objAdminEnti.Entry(dbPurpose).State = EntityState.Modified;
        //            objAdminEnti.SaveChanges();
        //            TempData["Success"] = "Purpose Updated successfully.";
        //            return RedirectToAction("PurposeList");
        //        }

        //    }
        //    return RedirectToAction("PurposeList");
        //}
    }
}