using JKBB_CVGS.Models;
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
        // GET: Report
        public ActionResult Index()
        {
            //Query for member list report
            using (var context = new CVGS_Context())
            {
                var L2EQuery = from m in context.Members 
                               select new {
                                   UserName =  m.FirstName + m.LastName,
                                   UserEmail = m.Email,
                                   ItemPurchased = "0"
                               };
                var userNameList = L2EQuery.ToDictionary(m => "UserName", m => m.UserName);
                var userEmailList = L2EQuery.ToDictionary(m => "UserEmail", m => m.UserEmail);
                var itemPurchased = L2EQuery.ToDictionary(m => "ItemPurchased", m => m.ItemPurchased);

                ViewBag.UserNameList = userNameList;
                ViewBag.UserEmailList = userEmailList;
                ViewBag.ItemPurchasedList = itemPurchased;
            }

            //Query for game list report 
            using (var context = new CVGS_Context())
            {


                var L2EQuery = from g in context.Games
                               select new
                               {
                                   Title = g.Title,
                                   Developer = g.Developer,
                                   ReleasedDate = g.ReleasedDate,
                                   UserRating = "0",
                                   BasePrice = g.BasePrice,
                                   Discount = g.Discount
                               };
                var gameTitleList = L2EQuery.ToDictionary(m => "Title", m => m.Title);
                var developerList = L2EQuery.ToDictionary(m => "Developer", m => m.Developer);
                var releaseDateList = L2EQuery.ToDictionary(m => "ReleasedDate", m => m.ReleasedDate);
                var userRatingList = L2EQuery.ToDictionary(m => "UserRating", m => m.UserRating);
                var basePriceList = L2EQuery.ToDictionary(m => "BasePrice", m => m.BasePrice);
                var discountList = L2EQuery.ToDictionary(m => "Discount", m => m.Discount);

                ViewBag.GameTitleList = gameTitleList;
                ViewBag.DeveloperList = developerList;
                ViewBag.ReleasedDateList = releaseDateList;
                ViewBag.UserRatingList = userRatingList;
                ViewBag.BasePriceList = basePriceList;
                ViewBag.DiscountList = discountList;
            }

            return View();
        }
    }
}