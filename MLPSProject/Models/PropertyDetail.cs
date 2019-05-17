using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MLPSProject.Models
{
    public class PropertyDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Property Holder")]
        public string vPropertyHolderName { get; set; }
        [Required]
        [Display(Name = "Property Type")]
        public string vPropertyType { get; set; }
        [Required]
        [Display(Name = "Property Address")]
        public string PropertyAddress { get; set; }
        public int iMarketValue { get; set; }
        public string vRemarks { get; set; }
        [Required]
        [Display(Name = "Id Proof")]
        public string IdProof { get; set; }
        [Required]
        [Display(Name = "Address Proof")]
        public string AddressProof { get; set; }
        [Required]
        [Display(Name = "Property Documents")]
        public string PropertyAgreement { get; set; }


        //References

        [ForeignKey("Officer")]
        public int? OfficerId { get; set; }
        public virtual Employee Officer { get; set; }

        [ForeignKey("Inspector")]
        public int? InspectorId { get; set; }
        public virtual Employee Inspector { get; set; }

        [ForeignKey("Authorizer")]
        public int? AuthorizerId { get; set; }
        public virtual Employee Authorizer { get; set; }

    }
}