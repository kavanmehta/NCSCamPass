using ReceptionProcam.EntityModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReceptionProcam.Areas.Area.Models
{
    public class EmployeeDesignations
    {
        public int EmpDesignationID { get; set; }

        public string EmpDesignationName { get; set; }
    }
}