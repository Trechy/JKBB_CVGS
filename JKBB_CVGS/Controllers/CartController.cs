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
    public class CartController : Controller
    {
        private CVGS_Context db = new CVGS_Context();

        // GET: Cart
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Index(string email)
        {
            var carts = db.Carts.Include(c => c.Game).Include(c => c.User).Where(w => w.Email.Contains(email));
            List<int> cartItems = new List<int>();
            foreach(Cart cart in carts)
            {
                cartItems.Add(cart.CartID);
            }
            ViewBag.cartItems = cartItems;
            return View(carts.ToList());
        }

        // GET: Cart/Details/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Cart/Create
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Create(string email, int GameID)
        {
            ViewBag.GameID = GameID;
            ViewBag.Email = email;

            Cart cart = new Cart();
            cart.Email = email;
            cart.GameID = GameID;
            cart.Quantity = 1;

            db.Carts.Add(cart);
            db.SaveChanges();
            return RedirectToAction("Index", new { email = email });
        }

        // GET: Game/Edit/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Edit([Bind(Include = "CartID,Email,GameID,Quantity")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { email = SessionPersister.Email });
            }
            return View(cart);
        }

        // POST: Cart/Delete/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Delete(int? id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
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
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Checkout(List<int> GameIDs)
        {
            ViewBag.CheckoutGameIDs = GameIDs;
            return View("Checkout");
        }
    }
}
