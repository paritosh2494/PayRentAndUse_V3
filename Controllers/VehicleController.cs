using PayRentAndUse_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRentAndUse_V3.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private ApplicationDbContext _context;

        public VehicleController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Vehicle
        [Authorize(Roles = "vendor,admin")]
        public ActionResult Registration()
        {
            return View();
        }
        [Authorize(Roles = "vendor,admin")]
        [HttpPost]
        public ActionResult Registration(VehicleClass vc)
        {
            if (vc.Id == 0)
            {
                _context.Vehicles.Add(vc);
                ViewData["Message"] = "Vehicle Record " + vc.Name + " Inserted Sucessfully";
            }
            else
            {
                var vehicleInDb = _context.Vehicles.SingleOrDefault(c => c.Id == vc.Id);
                vehicleInDb.Name = vc.Name;
                vehicleInDb.YearManufactured = vc.YearManufactured;
            }
            _context.SaveChanges();
            return RedirectToAction("VehicleDetail", "vehicle");

        }
        public ActionResult VehicleDetail()
        {
            var vehicle = _context.Vehicles.ToList();
            if (User.IsInRole("admin"))
            {
                return View("VehicleDetail", vehicle);
            }
            else if(User.IsInRole("vendor"))
            {
                return View("VehicleDetail", vehicle);
            }
            else if(User.IsInRole("user"))
            {
                return View("ReadOnlyVehicleDetailView", vehicle);
            }
            else
            {
                return View("VehicleDetail", vehicle);
            }                   
        }
        [Authorize(Roles = "vendor,admin")]
        public ActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(c => c.Id == id);

            if (vehicle == null)
                return HttpNotFound();

            return View("Registration", vehicle);
        }
        [Authorize(Roles = "vendor,admin")]
        public ActionResult Delete(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            return RedirectToAction("VehicleDetail");
        }
    }
}