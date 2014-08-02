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
    public class RestaurantEmployeesController : Controller
    {
        private Context db = new Context();

        // GET: RestaurantEmployees
        public ActionResult Index()
        {
            var restaurantEmployees = db.RestaurantEmployees.Include(r => r.Child).Include(r => r.EmployeeType).Include(r => r.Parent).Include(r => r.Rating);
            return View(restaurantEmployees.ToList());
        }

        // GET: RestaurantEmployees/Details/5
        public ActionResult Details(int? id, int? childID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantEmployee restaurantEmployee = db.RestaurantEmployees.Include(r => r.Child).Include(r => r.EmployeeType).Include(r => r.Parent).Include(r => r.Rating)
                .Single( o=> o.ParentID == id && o.ChildID == childID);
            if (restaurantEmployee == null)
            {
                return HttpNotFound();
            }
            return View(restaurantEmployee);
        }

        // GET: RestaurantEmployees/Create
        public ActionResult Create()
        {
            ViewBag.ChildID = new SelectList(db.Employees, "ID", "Name");
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name");
            ViewBag.ParentID = new SelectList(db.Restaurants, "ID", "Name");
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name");
            return View();
        }

        // POST: RestaurantEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParentID,ChildID,EmployeeTypeID,RatingID")] RestaurantEmployee restaurantEmployee)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantEmployees.Add(restaurantEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChildID = new SelectList(db.Employees, "ID", "Name", restaurantEmployee.ChildID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name", restaurantEmployee.EmployeeTypeID);
            ViewBag.ParentID = new SelectList(db.Restaurants, "ID", "Name", restaurantEmployee.ParentID);
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name", restaurantEmployee.RatingID);
            return View(restaurantEmployee);
        }

        // GET: RestaurantEmployees/Edit/5
        public ActionResult Edit(int? id, int? childID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantEmployee restaurantEmployee = db.RestaurantEmployees.Include(r => r.Child).Include(r => r.EmployeeType).Include(r => r.Parent).Include(r => r.Rating)
                .Single(o => o.ParentID == id && o.ChildID == childID);
            if (restaurantEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChildID = new SelectList(db.Employees, "ID", "Name", restaurantEmployee.ChildID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name", restaurantEmployee.EmployeeTypeID);
            ViewBag.ParentID = new SelectList(db.Restaurants, "ID", "Name", restaurantEmployee.ParentID);
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name", restaurantEmployee.RatingID);
            return View(restaurantEmployee);
        }

        // POST: RestaurantEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParentID,ChildID,EmployeeTypeID,RatingID")] RestaurantEmployee restaurantEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChildID = new SelectList(db.Employees, "ID", "Name", restaurantEmployee.ChildID);
            ViewBag.EmployeeTypeID = new SelectList(db.EmployeeTypes, "ID", "Name", restaurantEmployee.EmployeeTypeID);
            ViewBag.ParentID = new SelectList(db.Restaurants, "ID", "Name", restaurantEmployee.ParentID);
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name", restaurantEmployee.RatingID);
            return View(restaurantEmployee);
        }

        // GET: RestaurantEmployees/Delete/5
        public ActionResult Delete(int? id, int? childID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantEmployee restaurantEmployee = db.RestaurantEmployees.Include(r => r.Child).Include(r => r.EmployeeType).Include(r => r.Parent).Include(r => r.Rating)
                .Single(o => o.ParentID == id && o.ChildID == childID);
            if (restaurantEmployee == null)
            {
                return HttpNotFound();
            }
            return View(restaurantEmployee);
        }

        // POST: RestaurantEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id, int? childID)
        {
            RestaurantEmployee restaurantEmployee = db.RestaurantEmployees.Include(r => r.Child).Include(r => r.EmployeeType).Include(r => r.Parent).Include(r => r.Rating)
                .Single(o => o.ParentID == id && o.ChildID == childID);
            db.RestaurantEmployees.Remove(restaurantEmployee);
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
