using FoodWuzUp.Core;
using FoodWuzUp.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FoodWuzUp.Web.Controllers
{

    [RequireHttps]
    [Authorize]
    public class HomeController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("AuthenticatedIndex", GetAuthenticatedUser());
            }
            return View();
        }

        public ActionResult AuthenticatedIndex()
        {
            return View(GetAuthenticatedUser());
        }

        private DAL.User GetAuthenticatedUser()
        {
            Context context = new Context();
            var user = context.Users
                .Include(o => o.Groups)
                .Include(o => o.Memberships.Select(e => e.Parent))
                .Include(o => o.Memberships.Select(e => e.Child))
                .Include(o => o.Memberships.Select(e => e.Parent).Select(c => c.Creator))
                .Single(o => o.AuthID == AuthID);
            List<int> groupIDs = context.Groups
                .Where(o => o.CreatorID == user.ID)
                .Select(o => o.ID).ToList();
            groupIDs.AddRange(
                context.GroupUsers
                .Where(o => o.ChildID == user.ID)
                .Select(o => o.ParentID));
            ViewBag.Restaurants = context.Restaurants
                .Include(o=> o.Ratings)
                .Where(o => groupIDs.Contains(o.GroupID)).ToList();
            return user;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}