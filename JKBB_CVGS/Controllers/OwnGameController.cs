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
    public class OwnGameController : Controller
    {
        private CVGS_Context db = new CVGS_Context();

        // GET: OwnGame
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Index(string userEmail)
        {
            var ownGames = db.OwnGames.Include(o => o.Game).Include(o => o.User).Where(o => o.Email.Contains(userEmail));
            return View(ownGames.ToList());
        }

        // GET: OwnGame/Details/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnGame ownGame = db.OwnGames.Find(id);
            if (ownGame == null)
            {
                return HttpNotFound();
            }
            return View(ownGame);
        }

        // GET: OwnGame/Create
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Create(string userEmail, int GameID)
        {
            ViewBag.GameID = GameID;
            ViewBag.Email = userEmail;

            OwnGame ownedGames = new OwnGame();
            ownedGames.Email = userEmail;
            ownedGames.GameID = GameID;

            db.OwnGames.Add(ownedGames);
            db.SaveChanges();

            return RedirectToAction("Index", new { email = userEmail });
        }

        // POST: OwnGame/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Create([Bind(Include = "OwnGameID,Email,GameID")] OwnGame ownGame)
        {
            if (ModelState.IsValid)
            {
                db.OwnGames.Add(ownGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", ownGame.GameID);
            ViewBag.Email = new SelectList(db.Users, "Email", "Password", ownGame.Email);
            return View(ownGame);
        }

        // GET: OwnGame/Edit/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnGame ownGame = db.OwnGames.Find(id);
            if (ownGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", ownGame.GameID);
            ViewBag.Email = new SelectList(db.Users, "Email", "Password", ownGame.Email);
            return View(ownGame);
        }

        // POST: OwnGame/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Edit([Bind(Include = "OwnGameID,Email,GameID")] OwnGame ownGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ownGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "Title", ownGame.GameID);
            ViewBag.Email = new SelectList(db.Users, "Email", "Password", ownGame.Email);
            return View(ownGame);
        }

        // GET: OwnGame/Delete/5
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnGame ownGame = db.OwnGames.Find(id);
            if (ownGame == null)
            {
                return HttpNotFound();
            }
            return View(ownGame);
        }

        // POST: OwnGame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Member")]
        public ActionResult DeleteConfirmed(int id)
        {
            OwnGame ownGame = db.OwnGames.Find(id);
            db.OwnGames.Remove(ownGame);
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