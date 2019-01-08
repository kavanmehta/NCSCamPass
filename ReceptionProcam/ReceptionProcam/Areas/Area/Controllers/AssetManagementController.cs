using ReceptionProcam.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReceptionProcam.Areas.Area.Models;

namespace ReceptionProcam.Areas.Area.Controllers
{
    public class AssetManagementController : Controller
    {
        DBNCSVisitorEntities objAdminEnti = new DBNCSVisitorEntities();
        // GET: Area/AssetManagement
        [HttpGet]
        public ActionResult AssetDetails()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadData()
        {
            try
            {
                //Creating instance of DatabaseContext class  

                using (DBNCSVisitorEntities dc = new DBNCSVisitorEntities())
                {
                    var data = dc.uspGetAssetDetails().OrderBy(a => a.AssetModelName).ToList();
                    return Json(new { data = data }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        public Boolean SubmitAsset(int id)
        {
            var result = objAdminEnti.tblAssetIssueDetails.SingleOrDefault(b => b.AssetId == id);
            var assetTbl = objAdminEnti.tblAssetDetails.SingleOrDefault(b => b.ID == id);
           
            if (result != null)
            {
                result.IsSubmited = true;
                result.AssetSubmitDateTime = DateTime.Now;
                if (assetTbl != null)
                {
                    assetTbl.IsIssued = false;
                }
                objAdminEnti.SaveChanges();
                TempData["SuccessSubmit"] = "Asset Submitted successfully";
                return true;
            }
            else
            {
                return false;
            }
        }
     
        [HttpGet]
        public ActionResult AssetIssue()
        {
            getAllAssets();
            getAllEmployeeList();
            return View();
        }

        [HttpPost]
        public ActionResult AssetIssue(clsAssetIssueDetails objclsAssetIssueDetails)
        {
            try
            {
                foreach (var i in objclsAssetIssueDetails.AssetId)
                {
                    var j = objAdminEnti.spInsertAssetIssueDetails(objclsAssetIssueDetails.EmpId, i, "admin");
                }
                TempData["Success"] = "Assets assigned to employee succesfully";
            }
            catch
            {
                TempData["Success"] = "Assets assigned to employee is failed";
            }
            return RedirectToAction("AssetIssue");
        }
        [HttpGet]
        public void getAllAssets()
        {
            try
            {
                ViewBag.AllAssets = new SelectList(objAdminEnti.uspGetAllActiveAssets(), "ID", "AssetModelName", 0);
            }
            catch
            {

            }
        }

        [HttpGet]
        public void getAllEmployeeList()
        {
            ViewBag.EmployeeList = new SelectList(objAdminEnti.tblEmployeeDetails.Where(m => m.IsActive == true).ToList(), "ID", "EmpName", 0);
        }
    }
}