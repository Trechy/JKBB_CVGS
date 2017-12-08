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
    public class ProfileController : Controller
    {
        private CVGS_Context db = new CVGS_Context();

        // GET: Profile/Details/5
        [CustomAuthorize(Roles = "Member,Employee")]
        public ActionResult Index(string email)
        {
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(email);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Profile/Edit/5
        [CustomAuthorize(Roles = "Member,Employee")]
        public ActionResult Edit(string email)
        {
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(email);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [CustomAuthorize(Roles = "Member,Employee")]
        public ActionResult Edit([Bind(Include = "Email,Password,Role,FirstName,LastName,Gender,DateOfBirth,Address,City,Province,PostalCode,PhoneNumber")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
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
