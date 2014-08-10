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
    public class RestaurantsController : Controller
    {
        private Context db = new Context();

        // GET: Restaurants
        public ActionResult Index()
        {
            List<int> groupIDs = db.Groups
                .Where(o => o.Creator.Name == User.Identity.Name)
                .Select(o => o.ID).ToList();
            groupIDs.AddRange(
                db.GroupUsers
                .Where(o => o.Child.Name == User.Identity.Name)
                .Select(o => o.ParentID));
            var restaurants = db.Restaurants
                .Include(o => o.Group)
                .Where(o => groupIDs.Contains(o.GroupID))
                .OrderBy(o => o.Name).ToList();
            return View(restaurants);
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants
                .Include(r => r.Group)
                .Where(r => r.ID == id)
                .Single();
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            List<Group> groupIds = GetGroupList();
            ViewBag.GroupID = new SelectList(groupIds, "ID", "Name", "Select Group");
            return View();
        }

        private List<Group> GetGroupList()
        {
            List<Group> groupIds = db.Groups.Where(o => o.Creator.Name == User.Identity.Name).ToList();
            groupIds.Insert(0, null);
            return groupIds;
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GroupID,Name,Description")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<Group> groupIds = GetGroupList();
            ViewBag.GroupID = new SelectList(groupIds, "ID", "Name", restaurant.GroupID);
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Groups, "ID", "Name", restaurant.GroupID);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GroupID,Name,Description")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Groups, "ID", "Name", restaurant.GroupID);
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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
