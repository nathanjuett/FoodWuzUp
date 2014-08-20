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
    public class RestaurantsController : BaseController
    {
        private Context db = new Context();

        // GET: Restaurants
        public ActionResult Index()
        {
            List<int> groupIDs = db.Groups
                .Where(o => o.Creator.AuthID == AuthID)
                .Select(o => o.ID).ToList();
            groupIDs.AddRange(
                db.GroupUsers
                .Where(o => o.Child.AuthID == AuthID)
                .Select(o => o.ParentID));
            var restaurants = db.Restaurants
                .Include(o => o.Group)
                .Include(o => o.RestaurantType)
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
                .Include(r => r.RestaurantType)
                .Where(r => r.ID == id)
                .Single();
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        public ActionResult DetailsToolTip(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants
                .Include(r => r.Group)
                .Include(r => r.RestaurantType)
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
            ViewBag.GroupID = new SelectList(GetGroupList(), "ID", "Name");
            setRestaurantTypeIDViewBag();
            return View();
        }

        public ActionResult CreateModal()
        {
            setRestaurantTypeIDViewBag();
            ViewBag.GroupID = new SelectList(GetGroupList(), "ID", "Name");
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GroupID,Name,Description,Phone,Url,Address,RestaurantTypeID")] Restaurant restaurant)
        {
            if (!String.IsNullOrEmpty(restaurant.Url))
                restaurant.Url = GetUrl(restaurant.Url);
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            setRestaurantTypeIDViewBag(restaurant);
            ViewBag.GroupID = new SelectList(GetGroupList(), "ID", "Name", restaurant.GroupID);
            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateModal([Bind(Include = "ID,GroupID,Name,Description,Phone,Url,Address,RestaurantTypeID")] Restaurant restaurant)
        {
            if (!String.IsNullOrEmpty(restaurant.Url))
                restaurant.Url = GetUrl(restaurant.Url);
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("AuthenticatedIndex", "Home");
            }
            setRestaurantTypeIDViewBag(restaurant);
            ViewBag.GroupID = new SelectList(GetGroupList(), "ID", "Name", restaurant.GroupID);
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
            setRestaurantTypeIDViewBag(restaurant);
            ViewBag.GroupID = new SelectList(db.Groups, "ID", "Name", restaurant.GroupID);
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GroupID,Name,Description,Phone,Url,Address,RestaurantTypeID")] Restaurant restaurant)
        {
            if (!String.IsNullOrEmpty(restaurant.Url))
                restaurant.Url = GetUrl(restaurant.Url);
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            setRestaurantTypeIDViewBag(restaurant);
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
            Restaurant restaurant = db.Restaurants
                .Include(o => o.Group)
                .Include(o => o.RestaurantType)
                .Single(o => o.ID == id);
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

        private List<Group> GetGroupList()
        {
            List<Group> groupIds = db.Groups.Where(o => o.Creator.AuthID == AuthID).ToList();
            groupIds.Insert(0, null);
            return groupIds;
        }

        private void setRestaurantTypeIDViewBag(Restaurant restaurant = null)
        {
            if (restaurant == null)
                restaurant = new Restaurant();
            var restaurantTypeList = db.RestaurantTypes.ToList();
            restaurantTypeList.Insert(0, null);
            ViewBag.RestaurantTypeID = new SelectList(restaurantTypeList, "ID", "Name", restaurant.RestaurantTypeID);
        }

        private string GetUrl(string url)
        {
            return new UriBuilder(url).Uri.ToString();
        }
    }
}
