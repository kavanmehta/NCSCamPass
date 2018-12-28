using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReceptionProcam.Areas.Area.Controllers
{
    public class AssetMasterController : Controller
    {
        // GET: Area/AssetMaster
        [HttpGet]
        public ActionResult AddAsset()
        {
            return View();
        }

        // GET: Area/AssetMaster
        [HttpGet]
        public ActionResult Assetlist()
        {
            return View();
        }
    }
}