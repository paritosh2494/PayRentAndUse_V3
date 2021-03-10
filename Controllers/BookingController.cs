using PayRentAndUse_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRentAndUse_V3.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext _context;

        public BookingController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Booking
        public ActionResult Book(int id)
        {
            if (Session["Id"] != null)
            {
                var userId = Int16.Parse(Session["Id"].ToString());
                var user = _context.AppUsers.SingleOrDefault(c => c.Id == userId);
                var vendorClass = _context.Vendors.SingleOrDefault(c => c.Id == id);
                var vehicleClass = _context.Vehicles.SingleOrDefault(c => c.Id == vendorClass.VehicleClassId);
                ViewData["UId"] = user.Id;
                ViewData["VId"] = vendorClass.Id;
                ViewData["VHId"] = vehicleClass.Id;
                ViewData["AvailableVehicle"] = vendorClass.AvailableVehicle;
                ViewData["UserName"] = user.Name.ToString();
                ViewData["VendorName"] = vendorClass.Name.ToString();
                ViewData["VehicleName"] = vehicleClass.Name.ToString();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Book( BookingClass bc)
        {
            bc.BookedDate = System.DateTime.Now;
            bc.PaymentIndicator = "N";
            _context.Bookings.Add(bc);
            _context.SaveChanges();
            var vendorId = bc.VendorClassId;
            var reqVehicle = bc.RequiredVehicle;
            var vendorInDb = _context.Vendors.SingleOrDefault(c=>c.Id == vendorId);
            vendorInDb.AvailableVehicle -= reqVehicle;
            vendorInDb.BookedVehicle += reqVehicle;
            _context.SaveChanges();
            TempData["BookingData"] = bc;
            //return RedirectToAction("UserBookingDetail", "User");
            return RedirectToAction("ConfirmPayment", "Booking");
        }
        public ActionResult ConfirmPayment()
        {
            BookingClass bc = (BookingClass)TempData["BookingData"];
            int days = (int)(bc.ToBookingDate - bc.FromBookingDate).TotalDays;
            var PaymentAmount = days * 100 * bc.RequiredVehicle;
            bc.PaymentAmount = PaymentAmount;
            var bookingInDB = _context.Bookings.SingleOrDefault(c => c.Id == bc.Id);
            bookingInDB.PaymentAmount = PaymentAmount;
            bookingInDB.PaymentIndicator = "Y";
            _context.SaveChanges();
            var user = _context.AppUsers.SingleOrDefault(c => c.Id == bc.UserClassId);
            var vendorClass = _context.Vendors.SingleOrDefault(c => c.Id == bc.VendorClassId);
            ViewData["UserName"] = user.Name.ToString();
            ViewData["VendorName"] = vendorClass.Name.ToString();
            ViewData["Days"] = days;
            return View(bc);
        }

    }
}