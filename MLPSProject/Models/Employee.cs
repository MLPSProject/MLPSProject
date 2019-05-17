using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MLPSProject.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string vName { get; set; }

        [Required]
        public string vDesignation { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string vPassword { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string vMobile { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string vEmailID { get; set; }


    }
}