using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReceptionProcam.Areas.Area.Models
{
    public class IdentityMasters
    {
        public int Id { get; set; }

        [DisplayName("Govt Identity Name")]
        [Required(ErrorMessage="Please enter identity name")]
        public string ProofName { get; set; }

        [DisplayName("Govt Identity Code")]
        [Required(ErrorMessage = "Please enter identity code")]
        public string ProofCode { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}