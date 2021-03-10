using PayRentAndUse_V3.Models;
using PayRentAndUse_V3.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace PayRentAndUse_V3.Controllers
{
    [Authorize]
    public class VendorController : Controller
    {
        private ApplicationDbContext _context;

        public VendorController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Vendor
        [Authorize(Roles = "Admin")]
        public ActionResult Registration()
        {
            var vehicle = _context.Vehicles.ToList();
            var viewModel = new NewVendorViewModel
            {
                VendorClass = new VendorClass(),
                VehicleClasses = vehicle
            };
            return View("Registration", viewModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Registration(VendorClass vendorClass)
        {
            if(!ModelState.IsValid)
            {
                var vehicle = _context.Vehicles.ToList();
                var viewModel = new NewVendorViewModel
                {
                    VendorClass = vendorClass,
                    VehicleClasses = vehicle
                };
                return View("Registration", viewModel);
            }
            else
            {
                if (vendorClass.Id == 0)
                {
                    vendorClass.DateAdded = System.DateTime.Now;
                    vendorClass.BookedVehicle = 0;
                    vendorClass.AvailableVehicle = vendorClass.VehicleCount;
                    _context.Vendors.Add(vendorClass);
                    _context.SaveChanges();
                    var vendorId = vendorClass.Id;
                    var userType = "vendor";
                    var userRole = "vendor";
                    var UserRoleClass = new UserRoleClass
                    {
                        UserId = vendorId,
                        UserType = userType,
                        UserRole = userRole,
                        DateAdded = System.DateTime.Now
                    };
                    _context.UserRoles.Add(UserRoleClass);
                    _context.SaveChanges();
                }
                else
                {
                    var VendorInDb = _context.Vendors.SingleOrDefault(c => c.Id == vendorClass.Id);
                    VendorInDb.Name = vendorClass.Name;
                    VendorInDb.VehicleClassId = vendorClass.VehicleClassId;
                    VendorInDb.Email = vendorClass.Email;
                    VendorInDb.VendorPassword = vendorClass.VendorPassword;
                    VendorInDb.VendorRePassword = vendorClass.VendorRePassword;
                    if (vendorClass.VehicleCount > VendorInDb.VehicleCount)
                    {
                        VendorInDb.AvailableVehicle += vendorClass.VehicleCount - VendorInDb.VehicleCount;
                    }
                    else if (vendorClass.VehicleCount < VendorInDb.VehicleCount && vendorClass.VehicleCount > VendorInDb.BookedVehicle)
                    {
                        VendorInDb.AvailableVehicle -= VendorInDb.VehicleCount - vendorClass.VehicleCount;
                    }
                    else
                    {
                        VendorInDb.AvailableVehicle = vendorClass.VehicleCount;
                    }
                    VendorInDb.VehicleCount = vendorClass.VehicleCount;

                }
                _context.SaveChanges();
                ViewData["Message"] = "Vendor Record " + vendorClass.Name + " Saved Sucessfully";
                return RedirectToAction("VendorDetail", "Vendor");
            }
        }
        
        public ActionResult VendorDetail()
        {
            var vendor = _context.Vendors.Include(c => c.VehicleClass).ToList();
            if (User.IsInRole("admin"))
            {                
                return View("VendorDetail", vendor);
            }
            else if (User.IsInRole("vendor"))
            {
                return View("ReadOnlyVendorDetail", vendor);
            }
            else if (User.IsInRole("user"))
            {
                return View("BookingOnlyView", vendor);
            }
            else
            {
                return View("VendorDetail", vendor);
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var vendor = _context.Vendors.SingleOrDefault(c => c.Id == id);
            ViewData["BookedVehicle"] = vendor.BookedVehicle;

            if (vendor == null)
                return HttpNotFound();

            var viewModel = new NewVendorViewModel
            {
                VendorClass = vendor,
                VehicleClasses= _context.Vehicles.ToList()
            };
            return View("Registration", viewModel);
        }
        public ActionResult Details(int id)
        {
            var vendor = _context.Vendors.Include(c => c.VehicleClass).SingleOrDefault(v => v.Id == id);
            if (vendor == null)
            {
                return HttpNotFound();
            }

            return View(vendor);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var vendor = _context.Vendors.Include(c => c.VehicleClass).SingleOrDefault(v => v.Id == id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            _context.Vendors.Remove(vendor);
            _context.SaveChanges();
            return RedirectToAction("VendorDetail");

        }
    }
}