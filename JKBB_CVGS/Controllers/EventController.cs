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
            ViewBag.Registered = false;
            using (CVGS_Context context = new CVGS_Context())
            {
                UserModel um = new UserModel();
                User user = um.getUser(userEmail);
                var eventResult = from Event in db.Events
                                  where Event.EventID == eventID
                                  select Event;
                user.Events.Add(eventResult.FirstOrDefault());
                db.SaveChanges();
                if(db.SaveChanges() > 0)
                {
                    ViewBag.Registered = true;
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Event/Details/5
        [CustomAuthorize(Roles = "Member,Employee")]
        public ActionResult Details(int? id)
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
