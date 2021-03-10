using PayRentAndUse_V3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayRentAndUse_V3.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [AllowAnonymous]
        // GET: User
        public ActionResult Registration()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registration(UserClass uc)
        {
            uc.DateAdded = System.DateTime.Now;
            _context.AppUsers.Add(uc);
            _context.SaveChanges();
            ViewData["Message"] = "User Record " + uc.Name + " Inserted Sucessfully";
            var userId = uc.Id;
            var userType = "user";
            var userRole = "user";
            var UserRoleClass = new UserRoleClass
            {
                UserId = userId,
                UserType = userType,
                UserRole = userRole,
                DateAdded = System.DateTime.Now
            };
            _context.UserRoles.Add(UserRoleClass);
            _context.SaveChanges();
            return RedirectToAction("Login", "UserLogin");
        }
        public ActionResult UserDetail()
        {
            var user = _context.AppUsers.ToList();
            return View("UserDetail", user);
        }
        public ActionResult BookingDetail(int id)
        {
            var bookings = _context.Bookings
                                    .Where(c => c.UserClassId == id)
                                    .Include(c => c.UserClass)
                                    .Include(c => c.VehicleClass)
                                    .Include(c => c.VendorClass)
                                    .ToList<BookingClass>();
            var user = _context.AppUsers.SingleOrDefault(c => c.Id == id);
            ViewData["UserName"] = user.Name;
            return View(bookings);
        }
        public ActionResult Cancel (int id)
        {
            var booking = _context.Bookings.SingleOrDefault(v => v.Id == id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            var vendorId = booking.VendorClassId;
            var reqvehicle = booking.RequiredVehicle;
            var vendorDetails = _context.Vendors.SingleOrDefault(v => v.Id == vendorId);
            vendorDetails.AvailableVehicle += reqvehicle;
            vendorDetails.BookedVehicle -= reqvehicle;
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction("VendorDetail","Vendor");
        }
        public ActionResult Completed(int id)
        {
            var booking = _context.Bookings.SingleOrDefault(v => v.Id == id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            var vendorId = booking.VendorClassId;
            var reqvehicle = booking.RequiredVehicle;
            var vendorDetails = _context.Vendors.SingleOrDefault(v => v.Id == vendorId);
            vendorDetails.AvailableVehicle += reqvehicle;
            vendorDetails.BookedVehicle -= reqvehicle;
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            TempData["BookingUserId"] = booking.UserClassId;
            return RedirectToAction("Feedback", "User");
        }
        public ActionResult Feedback()
        {
            string username;
            int userid;
            if (TempData.ContainsKey("BookingUserId"))
            {
                var id = int.Parse(TempData["BookingUserId"].ToString());
                var user = _context.AppUsers.SingleOrDefault(v => v.Id == id );
                username = user.Name;
                userid = user.Id;
                ViewData["UserName"] = username;
                ViewData["Id"] = userid;
            }

            return View();
        }
        [HttpPost]
        public ActionResult Feedback(FeedbackClass fc)
        {
            _context.Feedbacks.Add(fc);
            _context.SaveChanges();
            //var user = _context.Bookings.Include(u => u.UserClass).SingleOrDefault(v => v.Id == id);
            return RedirectToAction("VendorDetail", "Vendor");
        }
        public ActionResult FeedbackDetail(int id)
        {
            var userFeedback = _context.Feedbacks
                                   .Where(c => c.UserClassId == id)
                                   .Include(c => c.UserClass)
                                   .ToList<FeedbackClass>();
            var user = _context.AppUsers.SingleOrDefault(c => c.Id == id);
            ViewData["UserName"] = user.Name;
            return View(userFeedback);
        }
    }
}