using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReceptionProcam.Areas.Area.Models
{
    public class PurposeMasters
    {
        public int Id { get; set; }

        [DisplayName("Purpose Name")]
        [Required(ErrorMessage = "Please enter purpose name")]
        public string PurposeName { get; set; }

        [DisplayName("Purpose Code")]
        [Required(ErrorMessage = "Please enter purpose code")]
        public string PurposeCode { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}