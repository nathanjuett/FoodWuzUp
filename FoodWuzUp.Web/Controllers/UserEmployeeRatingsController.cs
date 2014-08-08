using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodWuzUp.DAL;

namespace FoodWuzUp.Web.Controllers
{
    [Authorize]
    public class UserEmployeeRatingsController : Controller
    {
        private Context db = new Context();

        // GET: UserEmployeeRatings
        public ActionResult Index()
        {
            var userEmployeeRatings = db.UserEmployeeRatings.Include(u => u.Child).Include(u => u.Parent).Include(u => u.Rating);
            return View(userEmployeeRatings.ToList());
        }

        // GET: UserEmployeeRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEmployeeRating userEmployeeRating = db.UserEmployeeRatings.Find(id);
            if (userEmployeeRating == null)
            {
                return HttpNotFound();
            }
            return View(userEmployeeRating);
        }

        // GET: UserEmployeeRatings/Create
        public ActionResult Create()
        {
            ViewBag.ChildID = new SelectList(db.Employees, "ID", "Name");
            ViewBag.ParentID = new SelectList(db.Users, "ID", "Name");
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name");
            return View();
        }

        // POST: UserEmployeeRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParentID,ChildID,RatingID")] UserEmployeeRating userEmployeeRating)
        {
            if (ModelState.IsValid)
            {
                db.UserEmployeeRatings.Add(userEmployeeRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChildID = new SelectList(db.Employees, "ID", "Name", userEmployeeRating.ChildID);
            ViewBag.ParentID = new SelectList(db.Users, "ID", "UserID", userEmployeeRating.ParentID);
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name", userEmployeeRating.RatingID);
            return View(userEmployeeRating);
        }

        // GET: UserEmployeeRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEmployeeRating userEmployeeRating = db.UserEmployeeRatings.Find(id);
            if (userEmployeeRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChildID = new SelectList(db.Employees, "ID", "Name", userEmployeeRating.ChildID);
            ViewBag.ParentID = new SelectList(db.Users, "ID", "UserID", userEmployeeRating.ParentID);
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name", userEmployeeRating.RatingID);
            return View(userEmployeeRating);
        }

        // POST: UserEmployeeRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParentID,ChildID,RatingID")] UserEmployeeRating userEmployeeRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userEmployeeRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChildID = new SelectList(db.Employees, "ID", "Name", userEmployeeRating.ChildID);
            ViewBag.ParentID = new SelectList(db.Users, "ID", "UserID", userEmployeeRating.ParentID);
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name", userEmployeeRating.RatingID);
            return View(userEmployeeRating);
        }

        // GET: UserEmployeeRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserEmployeeRating userEmployeeRating = db.UserEmployeeRatings.Find(id);
            if (userEmployeeRating == null)
            {
                return HttpNotFound();
            }
            return View(userEmployeeRating);
        }

        // POST: UserEmployeeRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserEmployeeRating userEmployeeRating = db.UserEmployeeRatings.Find(id);
            db.UserEmployeeRatings.Remove(userEmployeeRating);
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
