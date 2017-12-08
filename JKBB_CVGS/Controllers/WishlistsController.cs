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

        // GET: Wishlists/Details/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wishlist wishlist = db.Wishlists.Find(id);
            if (wishlist == null)
            {
                return HttpNotFound();
            }
            return View(wishlist);
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

        // POST: Wishlists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Create([Bind(Include = "WishlistID,Email,GameID,AddDate")] Wishlist wishlist)
        {

            if (ModelState.IsValid)
            {
                db.Wishlists.Add(wishlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", wishlist.GameID);
            ViewBag.Email = new SelectList(db.Users, "Email", "Password", wishlist.Email);
            return View(wishlist);
        }

        // GET: Wishlists/Edit/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wishlist wishlist = db.Wishlists.Find(id);
            if (wishlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", wishlist.GameID);
            ViewBag.Email = new SelectList(db.Users, "Email", "Password", wishlist.Email);
            return View(wishlist);
        }

        // POST: Wishlists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Edit([Bind(Include = "WishlistID,Email,GameID,AddDate")] Wishlist wishlist)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(wishlist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", wishlist.GameID);
            ViewBag.Email = new SelectList(db.Users, "Email", "Password", wishlist.Email);
            return View(wishlist);
        }

        // GET: Wishlists/Delete/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wishlist wishlist = db.Wishlists.Find(id);
            if (wishlist == null)
            {
                return HttpNotFound();
            }
            return View(wishlist);
        }

        // POST: Wishlists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Member")]
        public ActionResult DeleteConfirmed(int id)
        {
            Wishlist wishlist = db.Wishlists.Find(id);
            db.Wishlists.Remove(wishlist);
            db.SaveChanges();
            return RedirectToAction("Index");
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
