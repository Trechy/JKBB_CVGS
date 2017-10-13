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
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {               
                if (login.IsValid(login.Email, login.Password))
                {
                    return RedirectToAction("Index", "Home",new { login.Email});
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
            return RedirectToAction("SignUp", "Home");
        }

    }
}