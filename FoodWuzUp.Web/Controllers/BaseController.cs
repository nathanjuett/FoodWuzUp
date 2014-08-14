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
}