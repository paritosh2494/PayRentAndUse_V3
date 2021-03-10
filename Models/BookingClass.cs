using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayRentAndUse_V3.Models
{
    public class BookingClass
    {
        public int Id { get; set; }
        public UserClass UserClass { get; set; }
        public int UserClassId { get; set; }
        public VendorClass VendorClass { get; set; }
        public int VendorClassId { get; set; }
        public VehicleClass VehicleClass { get; set; }
        public int VehicleClassId { get; set; }
        [Required(ErrorMessage = "Please Enter No. of Vehicle Required")]
        [Display(Name = "No. of Vehicle Required : ")]
        public int RequiredVehicle { get; set; }
        [Required(ErrorMessage = "Please Enter Booking From")]
        [Display(Name = "Booking From : ")]
        [DataType(DataType.Date)]
        public DateTime FromBookingDate { get; set; }
        [Required(ErrorMessage = "Please Enter Booking To")]
        [Display(Name = "Booking To : ")]
        [DataType(DataType.Date)]
        public DateTime ToBookingDate { get; set; }
        public int PaymentAmount { get; set; }
        public DateTime BookedDate { get; set; }
        public string PaymentIndicator { get; set; }

    }
}