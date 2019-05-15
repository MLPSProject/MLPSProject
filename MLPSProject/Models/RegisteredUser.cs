using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MLPSProject.Models
{
    public class RegisteredUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date Of Registration")]
        [DataType(DataType.Date)]
        public string dtDateOfRegistration { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string vFirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string vLastName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public string dtDOB { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string vGender { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string vMobile { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string vEmailID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Occupation")]
        public string vOccupation { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "City")]
        public string vCity { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string vAddress { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string vPassword { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Confirm Password")]
        public string vConfirmPassword { get; set; }

    }
}