using JKBB_CVGS.Models;
using JKBB_CVGS.Models.ViewModels;
using JKBB_CVGS.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace JKBB_CVGS.Controllers
{
    public class HomeController : Controller
    {
        private CVGS_Context db = new CVGS_Context();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel uvm)
        {
            UserModel um = new UserModel();
            User user = um.getUser(uvm.User.Email);

            try
            {
                if (string.IsNullOrEmpty(user.Email) ||
                string.IsNullOrEmpty(user.Password) ||
                um.login(user.Email, user.Password) == null)
                {
                    ViewBag.Error = "User is invalid.";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "User is invalid.";
                return View();
            }
            
            SessionPersister.Email = user.Email;
            SessionPersister.Role = user.Role;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SignUp(UserViewModel uvm)
        {
            UserModel um = new UserModel();
            try
            {
                um.addUser(uvm.User);
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                ViewBag.Error = "Sign up failed.";
                return View();
            }
        }

        [CustomAuthorize(Roles="Member,Employee")]
        public ActionResult Index(string email)
        {          
            return View();
        }

        [CustomAuthorize(Roles = "Member,Employee")]
        public ActionResult LogOut()
        {
            SessionPersister.Email = string.Empty;
            return RedirectToAction("Login", "Home");
        }

    }
}