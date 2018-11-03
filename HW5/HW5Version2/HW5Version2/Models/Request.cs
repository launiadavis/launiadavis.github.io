using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5Version2.Models
{
    public class Request
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(18)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Apartment Name")]
        [StringLength(20)]
        public string ApartmentName { get; set; }

        [Required]                                  
        [Display(Name = "Unit Number")]
        public int UnitNum { get; set; }

        [Required]
        [Display(Name = "Request Info")]
        public string InfoReq { get; set; }

        [Required]
        [Display(Name = "Submit Time")]
        public DateTime SubmitTime { get; set; }
    }
}