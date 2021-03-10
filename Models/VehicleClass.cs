using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRentAndUse_V3.Models
{
    public class VehicleClass
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Vehicle Name")]
        [Display(Name = "Vehicle Name :")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Vehicle Name must be Max 50 and Min 2")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Vehicle Manufactured Year")]
        [Display(Name = "Manufactured Year :")]
        public int YearManufactured { get; set; }
    }
}