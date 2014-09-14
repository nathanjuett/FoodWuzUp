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
    public class RestaurantsController : BaseController<Restaurant>
    {
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
                .Include(o => o.Ratings)
                .Where(o => groupIDs.Contains(o.GroupID))
                .OrderBy(o => o.Name).ToList();
            return View(restaurants);
        }
        public PartialViewResult PartialIndex(int? ID, String Parent)
        {
            List<int> groupIDs;
            if (ID == null)
            {
                groupIDs = db.Groups
                .Where(o => o.Creator.AuthID == AuthID)
                .Select(o => o.ID).ToList();
            }
            else
            {
                groupIDs = db.Groups
                .Where(o => o.Creator.AuthID == AuthID && o.ID == ID)
                .Select(o => o.ID).ToList();
            }
            groupIDs.AddRange(
               db.GroupUsers
               .Where(o => o.Child.AuthID == AuthID)
               .Select(o => o.ParentID));
            var restaurants = db.Restaurants
                .Include(o => o.Group)
                .Include(o => o.RestaurantType)
                .Include(o => o.Ratings)
                .Where(o => groupIDs.Contains(o.GroupID))
                .OrderBy(o => o.Name).ToList();
            return PartialView(restaurants);
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            return DetailsGet(id);
        }

        public ActionResult DetailsToolTip(int? id)
        {
            return DetailsGet(id);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            SetViewBagItems(new Restaurant());
            return View();
        }

        public PartialViewResult CreateModal()
        {
            SetViewBagItems(new Restaurant());
            return PartialView();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GroupID,Name,Description,Phone,Url,Address,RestaurantTypeID")] Restaurant restaurant)
        {
            return InnerCreate(restaurant, false);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateModal([Bind(Include = "ID,GroupID,Name,Description,Phone,Url,Address,RestaurantTypeID")] Restaurant restaurant)
        {
            return InnerCreate(restaurant, true);
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
            SetViewBagItems(restaurant);
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
            SetViewBagItems(restaurant);
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
            List<Group> groupIds = db.Groups
                .Where(o => o.Creator.AuthID == AuthID)
                .OrderBy(o => o.Name)
                .ToList();
            groupIds.Insert(0, null);
            return groupIds;
        }

        private void SetViewBagItems(Restaurant restaurant)
        {
            if (IsRestaurantNew(restaurant))
                ViewBag.GroupID = new SelectList(GetGroupList(), "ID", "Name");
            else
                ViewBag.GroupID = new SelectList(GetGroupList(), "ID", "Name", restaurant.GroupID);
            ViewBag.RestaurantTypeID = new SelectList(GetRestaurantTypeList(), "ID", "Name", restaurant.RestaurantTypeID);
        }

        private static bool IsRestaurantNew(Restaurant restaurant)
        {
            return restaurant.ID == 0;
        }

        private List<RestaurantType> GetRestaurantTypeList()
        {
            var restaurantTypeList = db.RestaurantTypes
                .OrderBy(o => o.Name)
                .ToList();
            restaurantTypeList.Insert(0, null);
            return restaurantTypeList;
        }

        private string GetUrl(string url)
        {
            return new UriBuilder(url).Uri.ToString();
        }

        private ActionResult DetailsGet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants
                .Include(o => o.Employees.Select(e => e.Child.Ratings.Select(r => r.Rating)))
                .Include(o => o.MenuItems.Select(e => e.Child))
                .Include(r => r.Group)
                .Include(r => r.RestaurantType)
                .Include(o => o.Ratings)
                .Where(r => r.ID == id)
                .Single();
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        private ActionResult InnerCreate(Restaurant restaurant, bool isModal)
        {
            if (!String.IsNullOrEmpty(restaurant.Url))
                restaurant.Url = GetUrl(restaurant.Url);
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                if (isModal)
                    return RedirectToAction("AuthenticatedIndex", "Home");
                else
                    return RedirectToAction("Index");
            }
            SetViewBagItems(restaurant);
            return View(restaurant);
        }
    }
}
