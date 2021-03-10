using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PayRentAndUse_V3.Models;

namespace PayRentAndUse_V3.Controllers
{
    public class UserLoginController : Controller
    {
        private ApplicationDbContext _context;

        public UserLoginController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: UserLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginClass lc)
        {
            var user = _context.AppUsers.SingleOrDefault(c => c.Email == lc.Email && c.UserPassword == lc.Password);
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name.ToString() + ",User", false);
                Session["Name"] = user.Name.ToString();
                Session["Id"] = user.Id.ToString();
                Session["SessionType"] = "User";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Message"] = "User Login Failed!!!";
            }
            return View();
        }
        public ActionResult welcome()
        {
            return View();
        }
    }
}