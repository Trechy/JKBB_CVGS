using JKBB_CVGS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JKBB_CVGS.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            //Querying with LINQ to Entities 
            using (var context = new CVGS_Context())
            {


                var L2EQuery = from m in context.Members 
                               join u in context.Users on m.MemberID equals u.UserID
                               select new {
                                   UserName =  u.FirstName + u.LastName,
                                   UserEmail = u.Email,
                                   ItemPurchased = "0"
                               };
                var userNameList = L2EQuery.ToDictionary(m => "UserName", m => m.UserName);
                var userEmailList = L2EQuery.ToDictionary(m => "UserEmail", m => m.UserEmail);
                var itemPurchased = L2EQuery.ToDictionary(m => "ItemPurchased", m => m.ItemPurchased);

                ViewBag.UserNameList = userNameList;
                ViewBag.UserEmailList = userEmailList;
                ViewBag.ItemPurchasedList = itemPurchased;
            }
            return View();
        }
    }
}