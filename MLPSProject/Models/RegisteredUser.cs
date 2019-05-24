using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        //[DataType(DataType.PhoneNumber)]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Index("Ix_vMobile", IsClustered =false, Order = 1, IsUnique = true)]
        public string vMobile { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        //[Index("Ix_vEmailID", Order = 2, IsUnique = true)]
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
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string vPassword { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("vPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string vConfirmPassword { get; set; }

    }
}