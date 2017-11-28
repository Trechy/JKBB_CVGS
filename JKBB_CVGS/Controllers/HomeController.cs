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
            
            if (string.IsNullOrEmpty(user.Email) || 
                string.IsNullOrEmpty(user.Password) ||
                um.login(user.Email, user.Password) == null)
            {
                ViewBag.Error = "User is invalid.";
                return View();
            }
            SessionPersister.Email = user.Email;
            return RedirectToAction("Index", "Home");
        }

        /*[HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if (login.IsValid(login.Email, login.Password))
                {
                    SessionPersister.Email = login.Email;
                    return RedirectToAction("Index", "Home", new { login.Email });
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                    return View();
                }
            }
            else
            {
                return View();
            }  
        }*/


        public ActionResult SignUp()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SignUp([Bind(Include = "UserID,UserName,Email,Password,FirstName,LastName,Role")]User user, SignUp signup)
        {

            if (signup.ConfirmPassword != signup.Password)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords don't match");
            }       
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        [CustomAuthorize(Roles="Member, Employee")]
        public ActionResult Index(string email)
        {          
            return View();
        }

        public ActionResult LogOut()
        {
            SessionPersister.Email = string.Empty;
            return RedirectToAction("SignUp", "Home");
        }

    }
}