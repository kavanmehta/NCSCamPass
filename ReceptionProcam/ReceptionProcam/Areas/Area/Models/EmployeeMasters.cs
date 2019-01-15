using ReceptionProcam.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReceptionProcam.Areas.Area.Models
{
    public class EmployeeMasters
    {
        public int ID { get; set; }

        [DisplayName("Employee Code")]
        [Required(ErrorMessage = "Please enter employee code")]
        public string EmpCode { get; set; }

        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Please enter employee name")]
        public string EmpName { get; set; }

        [DisplayName("Employee Designation")]
        //[Required(ErrorMessage = "Please select employee designation")]
        public int? EmpDesignationID { get; set; }

        [DisplayName("Employee Department")]
        //[Required(ErrorMessage = "Please select employee department")]
        public string EmpDept { get; set; }

        [DisplayName("Mobile No")]
        [Required(ErrorMessage = "* Please enter contact No")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "* Please enter max 10 Digit mobile No")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "* Please enter Valid Digit mobile No")]
        public string PhoneNo { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [DisplayName("Is Employee Active")]
        [Required(ErrorMessage = "Is employee active or not!!")]
        public bool IsActive { get; set; }
        public virtual tblEmpDesignationMaster tblEmpDesignationMaster { get; set; }


    }
}