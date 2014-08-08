using FoodWuzUp.Core;
using FoodWuzUp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWuzUp.Web.Controllers
{

    [RequireHttps]
    [Authorize]
    public class HomeController : Controller
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
            var user = context.Users.Include("Groups").Include("Memberships.Parent").Include("Memberships.Child").Single(o => o.Name == User.Identity.Name);
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