using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JKBB_CVGS.Models;
using JKBB_CVGS.Security;

namespace JKBB_CVGS.Controllers
{
    public class WishlistsController : Controller
    {
        private CVGS_Context db = new CVGS_Context();

        // GET: Wishlists
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Index(string email)
        {
            var wishlists = db.Wishlists.Include(w => w.Game).Include(w => w.User).Where(w => w.Email.Contains(email));
            return View(wishlists.ToList());
        }

        // GET: Wishlists/Create
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Create(string email, int GameID, DateTime AddDate)
        {
            ViewBag.GameID = GameID;
            ViewBag.Email = email;
            ViewBag.AddDate = AddDate;

            Wishlist wishlist = new Wishlist();
            wishlist.AddDate = AddDate;
            wishlist.Email = email;
            wishlist.GameID = GameID;

            db.Wishlists.Add(wishlist);
            db.SaveChanges();

            return RedirectToAction("Index",new { email=email});
        }

        // POST: Wishlists/Delete/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Delete(int? id)
        {
            Wishlist wishlist = db.Wishlists.Find(id);
            db.Wishlists.Remove(wishlist);
            db.SaveChanges();
            return RedirectToAction("Index", new { email = SessionPersister.Email });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
