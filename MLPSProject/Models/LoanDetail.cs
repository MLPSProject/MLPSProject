using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MLPSProject.Models
{
    public class LoanDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string vName { get; set; }

        [Required]
        
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string vMobile { get; set; }


        [Required]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string vEmail { get; set; }


        [Required]
        [Display(Name = "City")]
        public string vCity { get; set; }

        [Required]
        [Display(Name = "Age")]
        [Range(5, 50)]
        public int iAge { get; set; }
        [Required]
        [Display(Name = "Occupation")]
        public string vOccupation { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string vAddress { get; set; }
        [Required]
        [Display(Name = "Loan Amount")]
        public double dLoanAmount { get; set; }
        [Required]
        [Display(Name = "Rate Of Interest")]
        public int iRateOfInterest { get; set; }
        [Required]
        [Display(Name = "Loan Applied Date")]
        [DataType(DataType.Date)]
        public string dtLoanAppliedDate { get; set; }

        [DataType(DataType.Date)]
        public string dtLoanApprovedDate { get; set; }
        [Required]
        [Display(Name = "Duration")]
        public int iDuration { get; set; }
        public string vStatus { get; set; }

        //References

        public RegisteredUser RegisteredUser { get; set; }
        public int? RegisteredUserId { get; set; }

        public UnRegisteredUser UnRegisteredUser { get; set; }
        public int? UnRegisteredUserId { get; set; }

        public PropertyDetail PropertyDetail { get; set; }
        public int? PropertyDetailId { get; set; }

    }
}