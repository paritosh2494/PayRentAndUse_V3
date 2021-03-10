using PayRentAndUse_V3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PayRentAndUse_V3.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginClass lc)
        {
            var user = _context.Admins.SingleOrDefault(c => c.Email == lc.Email && c.AdminPassword == lc.Password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name.ToString() + ",Admin", false);
                Session["Name"] = user.Name.ToString();
                Session["Id"] = user.Id.ToString();
                Session["SessionType"] = "Admin";
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["Message"] = "Admin Login Failed!!!";
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index","Home");
        }
        public ActionResult welcome()
        {
            return View();
        }
    }
}