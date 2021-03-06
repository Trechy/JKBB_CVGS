﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JKBB_CVGS.Models;
using System.Configuration;
using System.Data.SqlClient;
using JKBB_CVGS.Security;

namespace JKBB_CVGS.Controllers
{
    public class GameController : Controller
    {
        private CVGS_Context db = new CVGS_Context();

        // GET: Game
        //public ActionResult Index()
        //{
        //    return View(db.Games.ToList());
        //}

        //https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/search

        [CustomAuthorize(Roles = "Member,Employee")]
        public ActionResult Index(string searchString = "")
        {
            var gameResult = from Game in db.Games select Game;
            if (!String.IsNullOrEmpty(searchString))
            {
                gameResult = gameResult.Where(g => g.Title.Contains(searchString));
            }
            return View(gameResult.ToList());
        }

        // GET: Game/Details/5
        [CustomAuthorize(Roles = "Member,Employee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Game/Create
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Create([Bind(Include = "GameID,Title,Developer,Publisher,ReleasedDate,BasePrice,Discount")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Game/Edit/5
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Edit([Bind(Include = "GameID,Title,Developer,Publisher,ReleasedDate,BasePrice,Discount")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Entry(game).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Game/Delete/5
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Delete(int? id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
