using PayRentAndUse_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRentAndUse_V3.ViewModel
{
    public class NewVendorViewModel
    {
        public IEnumerable<VehicleClass> VehicleClasses { get; set; }
        public VendorClass VendorClass { get; set; }
    }
}