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

        [HttpGet]
        public ActionResult AuditAsset()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AuditAssetData()
        {
            try
            {
                //Creating instance of DatabaseContext class  

                using (DBNCSVisitorEntities dc = new DBNCSVisitorEntities())
                {
                    var data = dc.uspGetAllAuditDetails().OrderBy(a => a.AssetModelName).ToList();
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
            var result = objAdminEnti.tblAssetIssueDetails.SingleOrDefault(b => b.ID == id);
            var assetTbl = objAdminEnti.tblAssetDetails.SingleOrDefault(b => b.ID == result.AssetId);

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
                if (objclsAssetIssueDetails.HWAssetId != null)
                {
                        foreach (var i in objclsAssetIssueDetails.HWAssetId)
                        {
                            var j = objAdminEnti.spInsertAssetIssueDetails(objclsAssetIssueDetails.EmpId, i, "admin");
                        }
                }
                if (objclsAssetIssueDetails.SWAssetId !=null)
                {
                    foreach (var i in objclsAssetIssueDetails.SWAssetId)
                    {
                        var j = objAdminEnti.spInsertAssetIssueDetails(objclsAssetIssueDetails.EmpId, i, "admin");
                    }
                }
                if (objclsAssetIssueDetails.NWAssetId != null)
                {
                    foreach (var i in objclsAssetIssueDetails.NWAssetId)
                    {
                        var j = objAdminEnti.spInsertAssetIssueDetails(objclsAssetIssueDetails.EmpId, i, "admin");
                    }
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
            ViewBag.AllHWAssets = new SelectList(objAdminEnti.uspGetAllActiveHardwareAssets(), "ID", "AssetModelName", 0);
            ViewBag.AllSWAssets = new SelectList(objAdminEnti.uspGetAllActiveSoftwareAssets(), "ID", "AssetModelName", 0);
            ViewBag.AllNWAssets = new SelectList(objAdminEnti.uspGetAllActiveNetworkAssets(), "ID", "AssetModelName", 0);

        }
        [HttpGet]
        public void getAllEmployeeList()
        {
            //ViewBag.EmployeeList = new SelectList(objAdminEnti.tblEmployeeDetails.Where(m => m.IsActive == true).ToList(), "ID", "EmpName", 0);
            ViewBag.EmployeeList = new SelectList(objAdminEnti.uspGetActiveEmployeeList(), "ID", "EmpId", 0);

        }


        [HttpPost]
        public Boolean AuditAsset(int id , string remarks)
        {
            var result = objAdminEnti.tblAssetIssueDetails.SingleOrDefault(b => b.AssetId == id);
            var assetTbl = objAdminEnti.tblAssetDetails.SingleOrDefault(b => b.ID == id);
            //var assetAudi = objAdminEnti.tblAssetAudits.SingleOrDefault(b => b.AssetIssueID == result.ID);
            if (result != null)
            {
                tblAssetAudit objtblAudit = new tblAssetAudit();
                tblAssetDetail objtblAssetMaster = new tblAssetDetail();
                if (assetTbl != null)
                {
                    assetTbl.IsAudited = true;
                    //objAdminEnti.SaveChanges();

                    AssetAudits assetAudi = new AssetAudits();
                    objtblAudit.AssetIssueID = result.ID;
                    objtblAudit.AuditDate = DateTime.Now;
                    var date = DateTime.Now.ToString("yyyy");
                    objtblAudit.AuditYear = int.Parse(date);
                    //objtblAudit.Remarks = "Asset is audited by Audit team for" + date;
                    objtblAudit.Remarks = remarks;
                    objAdminEnti.tblAssetAudits.Add(objtblAudit);
                    //objAdminEnti.tblAssetDetails.(objtblAssetMaster);
                    objAdminEnti.SaveChanges();

                }
                TempData["SuccessSubmit"] = "Asset Audited successfully";
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}