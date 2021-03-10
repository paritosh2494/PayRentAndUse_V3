using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRentAndUse_V3.Models
{
    public class VendorClass
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Enter Name :")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Name must be Max 50 and Min 2")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Email Address")]
        [Display(Name = "Email Id :")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password :")]
        [DataType(DataType.Password)]
        public string VendorPassword { get; set; }
        [Required(ErrorMessage = "Confirm Password cannot be blank")]
        [Display(Name = "Confirm Password :")]
        [DataType(DataType.Password)]
        [Compare("VendorPassword")]
        public string VendorRePassword { get; set; }
        public DateTime DateAdded { get; set; }
        public VehicleClass VehicleClass { get; set; }
        [Display(Name = "Vehicle Name")]
        public int VehicleClassId { get; set; }
        [Required(ErrorMessage = "Please Enter Total Vehicle Count")]
        [Display(Name = "Vehicle Count")]
        public int VehicleCount { get; set; }
        public int BookedVehicle { get; set; }
        public int AvailableVehicle { get; set; }
    }
}