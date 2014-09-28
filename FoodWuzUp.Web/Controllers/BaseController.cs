using FoodWuzUp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodWuzUp.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string AuthID { get { return GetAuthID(); } }
        protected string GetAuthID()
        {
            var realUser = (System.Security.Claims.ClaimsPrincipal)User;
            return realUser.Claims.Single(o => o.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
        }
    }
    public class BaseController<T> : BaseController
        where T : Base<T>, new()
    {
        protected Context db = new Context();

        public ActionResult Lookup(string term)
        {
            var ret = db.Set<T>()
                .Where(o => o.Name.StartsWith(term))
                .Select(o => new { label = o.Name + (String.IsNullOrEmpty(o.Description) ? o.Description : " - " + o.Description), value = o.Name, id = o.ID })
                .Take(10)
                .ToArray();

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        public virtual PartialViewResult CreateModal()
        {
            return PartialView();
        }
    }
}