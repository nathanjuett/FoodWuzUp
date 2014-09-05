﻿using System;
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
    public class RestaurantMenuItemsController : Controller
    {
        private Context db = new Context();

        // GET: RestaurantMenuItems
        public ActionResult Index()
        {
            var restaurantMenuItems = db.RestaurantMenuItems.Include(r => r.Child).Include(r => r.Parent).Include(r => r.Rating);
            return View(restaurantMenuItems.ToList());
        }

        // GET: RestaurantMenuItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantMenuItem restaurantMenuItem = db.RestaurantMenuItems.Find(id);
            if (restaurantMenuItem == null)
            {
                return HttpNotFound();
            }
            return View(restaurantMenuItem);
        }

        // GET: RestaurantMenuItems/Create
        public ActionResult Create()
        {
            ViewBag.ChildID = new SelectList(db.MenuItems, "ID", "Name");
            ViewBag.ParentID = new SelectList(db.Restaurants, "ID", "Name");
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name");
            return View();
        }

        // POST: RestaurantMenuItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParentID,ChildID,RatingID")] RestaurantMenuItem restaurantMenuItem)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantMenuItems.Add(restaurantMenuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChildID = new SelectList(db.MenuItems, "ID", "Name", restaurantMenuItem.ChildID);
            ViewBag.ParentID = new SelectList(db.Restaurants, "ID", "Name", restaurantMenuItem.ParentID);
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name", restaurantMenuItem.RatingID);
            return View(restaurantMenuItem);
        }

        // GET: RestaurantMenuItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantMenuItem restaurantMenuItem = db.RestaurantMenuItems.Find(id);
            if (restaurantMenuItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChildID = new SelectList(db.MenuItems, "ID", "Name", restaurantMenuItem.ChildID);
            ViewBag.ParentID = new SelectList(db.Restaurants, "ID", "Name", restaurantMenuItem.ParentID);
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name", restaurantMenuItem.RatingID);
            return View(restaurantMenuItem);
        }

        // POST: RestaurantMenuItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParentID,ChildID,RatingID")] RestaurantMenuItem restaurantMenuItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantMenuItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChildID = new SelectList(db.MenuItems, "ID", "Name", restaurantMenuItem.ChildID);
            ViewBag.ParentID = new SelectList(db.Restaurants, "ID", "Name", restaurantMenuItem.ParentID);
            ViewBag.RatingID = new SelectList(db.Ratings, "ID", "Name", restaurantMenuItem.RatingID);
            return View(restaurantMenuItem);
        }

        // GET: RestaurantMenuItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantMenuItem restaurantMenuItem = db.RestaurantMenuItems.Find(id);
            if (restaurantMenuItem == null)
            {
                return HttpNotFound();
            }
            return View(restaurantMenuItem);
        }

        // POST: RestaurantMenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantMenuItem restaurantMenuItem = db.RestaurantMenuItems.Find(id);
            db.RestaurantMenuItems.Remove(restaurantMenuItem);
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