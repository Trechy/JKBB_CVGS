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
using JKBB_CVGS.Security;

namespace JKBB_CVGS.Controllers
{
    public class EventController : Controller
    {
        private CVGS_Context db = new CVGS_Context();
        public bool CanEdit = false;

        // GET: Event
        [CustomAuthorize(Roles = "Member,Employee")]
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }
        [CustomAuthorize(Roles = "Member")]
        public ActionResult Register(string userEmail, int eventID)
        {
            //ViewBag.Registered = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CVGS_Context"].ToString()))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Register (Email, EventID) VALUES(@sqlUserEmail, @sqlEventID); ", connection);
                command.Parameters.AddWithValue("@sqlUserEmail", userEmail);
                command.Parameters.AddWithValue("@sqlEventID", eventID);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Event/Details/5
        [CustomAuthorize(Roles = "Member,Employee")]
        public ActionResult Details(int? id, string userEmail)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Register"].ToString()))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Register WHERE Email = @sqlUserEmail AND EventID = @sqlEventID; ", connection);
                command.Parameters.AddWithValue("@sqlUserEmail", userEmail);
                command.Parameters.AddWithValue("@sqlEventID", id);
                command.Connection.Open();
                object returnsNull = command.ExecuteScalar();
                if (returnsNull != null)
                {
                    ViewBag.Registered = true;
                }
                else
                {
                    ViewBag.Registered = false;
                }
            }
            return View(@event);
        }

        // GET: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Create([Bind(Include = "EventID,EventName,EventDate,Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Event/Edit/5
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Edit([Bind(Include = "EventID,EventName,EventDate,Description")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Event/Delete/5
        [CustomAuthorize(Roles = "Employee")]
        public ActionResult Delete(int? id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
