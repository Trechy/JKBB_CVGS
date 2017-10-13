using System;
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

namespace JKBB_CVGS.Controllers
{
    public class GameController : Controller
    {
        private CVGS_Context db = new CVGS_Context();

        // GET: Game
        public ActionResult Index(string email)
        {
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
            return View(db.Games.ToList());
        }

        // GET: Game/Details/5
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
