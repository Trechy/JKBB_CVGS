using JKBB_CVGS.Models;
using JKBB_CVGS.Models.ViewModels;
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
<<<<<<< HEAD
        public ActionResult Login(Login login)
=======
        public ActionResult Login(Login user)
>>>>>>> 7f3de2b9669c921f9de42cd83743d903765b3613
        {
            if (ModelState.IsValid)
            {               
                if (login.IsValid(login.Email, login.Password))
                {
<<<<<<< HEAD
                    return RedirectToAction("Index", "Home",new { login.Email});
=======
                    return RedirectToAction("Index", "Home");
>>>>>>> 7f3de2b9669c921f9de42cd83743d903765b3613
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
        public ActionResult SignUp([Bind(Include = "MemberID,UserName,Email,Password,FirstName,LastName")]Member member,SignUp signup)
        {
            if (signup.ConfirmPassword != signup.Password)
            {
                ModelState.AddModelError("ConfirmPassword", "Passwords don't match");
            }

            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Index(string email)
        {
            ViewBag.Email = email;
            string connString = ConfigurationManager.ConnectionStrings["CVGS_Context"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                bool flag = false;
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Employee] WHERE [Email]='" + email + "'", conn);
                flag = Convert.ToBoolean(cmd.ExecuteScalar());
                if (flag == true)
                {
                    ViewBag.IsEmployee = true;
                }
                else
                {
                    ViewBag.IsEmployee = false;
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            return RedirectToAction("");
        }

    }
}