using ReceptionProcam.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReceptionProcam.Areas.Area.Controllers
{
    public class AssetManagementController : Controller
    {
        DBNCSVisitorEntities objVisEnti = new DBNCSVisitorEntities();
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
            var result = objVisEnti.tblAssetIssueDetails.SingleOrDefault(b => b.AssetId == id);
            if (result != null)
            {
                result.IsSubmited = true;
                result.AssetSubmitDateTime = DateTime.Now;

                objVisEnti.SaveChanges();
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
            return View();
        }
    }
}