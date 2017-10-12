using JKBB_CVGS.Models;
using JKBB_CVGS.Models.ViewModels;
using System;
using System.Collections.Generic;
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
        public ActionResult Login(Login user)
        {
            if (ModelState.IsValid)
            {               
                if (user.IsValid(user.Email, user.Password))
                {
                    return RedirectToAction("Index", "Home");
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
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SignUp([Bind(Include = "UserID,UserName,Email,Password,FirstName,LastName")]User user,SignUp signup)
        {
            if (signup.ConfirmPassword != signup.Password)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords don't match");
            }

            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Index()
        {
            return View();
        }
        
    }
}