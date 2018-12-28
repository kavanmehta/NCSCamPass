using ReceptionProcam.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReceptionProcam.Areas.Area.Models
{
    public class EmployeeMasters
    {
        public int ID { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public Nullable<int> EmpDesignationID { get; set; }
        public string EmpDept { get; set; }
        public string PhoneNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual tblEmpDesignationMaster tblEmpDesignationMaster { get; set; }


    }
}