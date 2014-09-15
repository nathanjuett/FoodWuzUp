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
    public class GroupsController : BaseController<Group>
    {
        // GET: Groups
        public ActionResult Index()
        {
            var myGroups = db.Groups
                .Where(o => o.Creator.AuthID == AuthID)
                .OrderBy(o => o.Name);
            List<int> groupIDs = db.GroupUsers.Where(o => o.Child.AuthID == AuthID).Select(o => o.ParentID).ToList();
            ViewBag.MyMemberships = db.Groups
                .Include(o => o.Creator)
                .Where(o => groupIDs.Contains(o.ID))
                .OrderBy(o => o.Name).ToList();
            return View(myGroups.ToList());
        }
        public PartialViewResult PartialIndex(int? ID, String Parent)
        {
            IEnumerable<Group> myGroups;
            if (ID == null)
            {
                ViewBag.Title = "My Groups";
                myGroups = db.Groups
               .Include(o => o.Creator)
               .Where(o => o.Creator.AuthID == AuthID)
               .OrderBy(o => o.Name);
            }
            else
            {
                ViewBag.Title = "My Memberships";
                myGroups = db.Groups
              .Include(o => o.Creator)
              .Where(o => o.Members.Select(m => m.ChildID).Contains(ID.Value))
              .OrderBy(o => o.Name);
            }
            //List<int> groupIDs = db.GroupUsers.Where(o => o.Child.AuthID == AuthID).Select(o => o.ParentID).ToList();
            //ViewBag.MyMemberships = db.Groups
            //    .Where(o => groupIDs.Contains(ID.Value))
            //    .OrderBy(o => o.Name).ToList();
            return PartialView(myGroups.ToList());
        }


        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups
                .Include(g => g.Members.Select(e => e.Child))
                .Include(g => g.Restaurants)
                .Include(g => g.Creator)
                .Single(o => o.ID == id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            return View();
        }

        public PartialViewResult CreateModal()
        {
            return PartialView();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CreatorID,Name,Description")] Group group)
        {
            if (ModelState.IsValid)
            {
                group.CreatorID = db.Users.Single(o => o.AuthID == AuthID).ID;
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateModal([Bind(Include = "ID,CreateorID,Name,Description")] Group group)
        {
            if (ModelState.IsValid)
            {
                group.CreatorID = db.Users.Single(o => o.AuthID == AuthID).ID;
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("AuthenticatedIndex", "Home");
            }
            return View(group);
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Include(g => g.Creator).Single(o => o.ID == id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CreatorID,Name,Description")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Include(g => g.Creator).Single(o => o.ID == id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Include(g => g.Creator).Single(o => o.ID == id);
            db.Groups.Remove(group);
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
