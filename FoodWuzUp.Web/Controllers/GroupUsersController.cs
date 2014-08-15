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
    public class GroupUsersController : BaseController
    {
        private Context db = new Context();
        public ActionResult UserLookup(string query)
        {
           SelectList ret = new SelectList(db.Users.Where(o => o.Name.StartsWith(query)),"ID","Name");
           return Json(ret, JsonRequestBehavior.AllowGet);
        }
        // GET: GroupUsers
        public ActionResult Index()
        {
            var groupUsers = db.GroupUsers.Include(g=> g.UserType).Include(g => g.Child).Include(g => g.Parent);
            return View(groupUsers.ToList());
        }

        // GET: GroupUsers/Details/5
        public ActionResult Details(int? parentid, int? childid)
        {
            if (parentid == null || childid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupUser groupUsers = db.GroupUsers.Include(g => g.UserType).Include(g => g.Child).Include(g => g.Parent)
                .Single(o=> o.ParentID == parentid & o.ChildID == childid);
            if (groupUsers == null)
            {
                return HttpNotFound();
            }
            return View(groupUsers);
        }

        // GET: GroupUsers/Create
        public ActionResult Create()
        {
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "ID", "Name");
            ViewBag.ChildID = new SelectList(db.Users, "ID", "Name");
            ViewBag.ParentID = new SelectList(db.Groups, "ID", "Name");
            return View();
        }

        // POST: GroupUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParentID,ChildID,UserTypeID")] GroupUser groupUsers)
        {
            if (ModelState.IsValid)
            {
                db.GroupUsers.Add(groupUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserTypeID = new SelectList(db.UserTypes, "ID", "Name");
            ViewBag.ChildID = new SelectList(db.Users, "ID", "Name", groupUsers.ChildID);
            ViewBag.ParentID = new SelectList(db.Groups, "ID", "Name", groupUsers.ParentID);
            return View(groupUsers);
        }

        // GET: GroupUsers/Edit/5
        public ActionResult Edit(int? parentid, int? childid)
        {
            if (parentid == null || childid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupUser groupUsers = db.GroupUsers.Include(g => g.UserType).Include(g => g.Child).Include(g => g.Parent)
                .Single(o => o.ParentID == parentid & o.ChildID == childid);
            if (groupUsers == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "ID", "Name");
            ViewBag.ChildID = new SelectList(db.Users, "ID", "Name", groupUsers.ChildID);
            ViewBag.ParentID = new SelectList(db.Groups, "ID", "Name", groupUsers.ParentID);
            return View(groupUsers);
        }

        // POST: GroupUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParentID,ChildID,UserTypeID")] GroupUser groupUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserTypeID = new SelectList(db.UserTypes, "ID", "Name");
            ViewBag.ChildID = new SelectList(db.Users, "ID", "Name", groupUsers.ChildID);
            ViewBag.ParentID = new SelectList(db.Groups, "ID", "Name", groupUsers.ParentID);
            return View(groupUsers);
        }

        // GET: GroupUsers/Delete/5
        public ActionResult Delete(int? parentid, int? childid)
        {
            if (parentid == null || childid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupUser groupUsers = db.GroupUsers.Include(g => g.UserType).Include(g => g.Child).Include(g => g.Parent)
                .Single(o => o.ParentID == parentid & o.ChildID == childid);
            if (groupUsers == null)
            {
                return HttpNotFound();
            }
            return View(groupUsers);
        }

        // POST: GroupUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? parentid, int? childid)
        {
            GroupUser groupUsers = db.GroupUsers.Find(parentid, childid);
            db.GroupUsers.Remove(groupUsers);
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
