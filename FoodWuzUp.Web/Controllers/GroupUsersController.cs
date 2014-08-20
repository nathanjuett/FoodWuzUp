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
            //SelectList ret = new SelectList(db.Users.Where(o => o.Name.StartsWith(query)),"ID","Name");
            var ret = db.Users.Where(o => o.Name.StartsWith(query)).Select(o => new { label = o.Name, value = o.ID });
            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        // GET: GroupUsers
        public ActionResult Index()
        {
            var groupUsers = db.GroupUsers.Include(g => g.UserType).Include(g => g.Child).Include(g => g.Parent);
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
                .Single(o => o.ParentID == parentid & o.ChildID == childid);
            if (groupUsers == null)
            {
                return HttpNotFound();
            }
            return View(groupUsers);
        }

        // GET: GroupUsers/Create
        public ActionResult Create()
        {
            GenerateViewBagItems();
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

            GenerateViewBagItems(groupUsers);
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
            GenerateViewBagItems(groupUsers);
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
            GenerateViewBagItems(groupUsers);
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

        private void GenerateViewBagItems(GroupUser groupUsers = null)
        {
            if (groupUsers == null)
                groupUsers = new GroupUser();
            var userTypes = db.UserTypes.ToList();
            userTypes.Insert(0, null);
            ViewBag.UserTypeID = new SelectList(userTypes, "ID", "Name", groupUsers.UserTypeID);
            var users = db.Users.ToList();
            users.Insert(0, null);
            ViewBag.ChildID = new SelectList(users, "ID", "Name", groupUsers.ChildID);
            var groups = db.Groups.ToList();
            groups.Insert(0, null);
            ViewBag.ParentID = new SelectList(groups, "ID", "Name", groupUsers.ParentID);
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
