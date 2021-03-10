using PayRentAndUse_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PayRentAndUse_V3.Controllers
{
    public class VendorLoginController : Controller
    {
        private ApplicationDbContext _context;
        public VendorLoginController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: VendorLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginClass lc)
        {
            var user = _context.Vendors.SingleOrDefault(c => c.Email == lc.Email && c.VendorPassword == lc.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name.ToString()+",Vendor", false);
                Session["Name"] = user.Name.ToString();
                Session["Id"] = user.Id.ToString();
                Session["SessionType"] = "Vendor";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Message"] = "Vendor Login Failed!!!";
            }
            return View();
        }
        
        public ActionResult welcome()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "VendorLogin");
        }
    }
}