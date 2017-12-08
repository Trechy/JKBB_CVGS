using JKBB_CVGS.Models;
using JKBB_CVGS.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JKBB_CVGS.Controllers
{
    public class ReportController : Controller
    {
        private CVGS_Context db = new CVGS_Context();
        // GET: Report
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Index()
        {
            //Query for user list report
            List<User> users = db.Users.ToList();
            ViewBag.users = users;

            //Query for game list report 
            List<Game> games = db.Games.ToList();
            ViewBag.games = games;

            //Query for wishlist report 
            List<Wishlist> wishlists = db.Wishlists.ToList();
            ViewBag.wishlists = wishlists;

            return View();
        }
    }
}