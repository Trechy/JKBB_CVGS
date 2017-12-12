﻿using System;
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


        // GET: Cart/Edit/5
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
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", cart.GameID);
            ViewBag.Email = new SelectList(db.Users, "Email", "Password", cart.Email);
            return View(cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [CustomAuthorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartID,Email,GameID,Quantity")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", cart.GameID);
            ViewBag.Email = new SelectList(db.Users, "Email", "Password", cart.Email);
            return View(cart);
        }

        // GET: Cart/Delete/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Delete(int? id)
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

        // POST: Cart/Delete/5
        [CustomAuthorize(Roles = "Member")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
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