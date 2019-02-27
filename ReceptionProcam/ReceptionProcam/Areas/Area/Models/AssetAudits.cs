using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReceptionProcam.Areas.Area.Models
{
    public class AssetAudits
    {
        public int ID {get;set;}
        public int AssetIssueID { get; set; }
        public int AuditYear { get; set; }
        public string Remarks { get; set; }
        public DateTime? AuditDate { get; set; }
    }
}