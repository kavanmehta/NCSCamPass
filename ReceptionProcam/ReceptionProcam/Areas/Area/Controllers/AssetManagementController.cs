﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReceptionProcam.Areas.Area.Controllers
{
    public class AssetManagementController : Controller
    {
        // GET: Area/AssetManagement
        [HttpGet]
        public ActionResult AssetDetails()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AssetIssue()
        {
            return View();
        }
    }
}