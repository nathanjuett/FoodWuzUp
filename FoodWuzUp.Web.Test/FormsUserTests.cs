//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using FoodWuzUp.Web.Controllers;
//using System.Web.Mvc;
//using System.Threading.Tasks;
//using FoodWuzUp.Web.Models;
//using FoodWuzUp.DAL;

//namespace FoodWuzUp.Web.Test
//{
//    [TestClass]
//    public class FormsUserTests
//    {
//        [TestInitialize]
//        public void Init()
//        {
//            Context db = new Context();
//            ApplicationDbContext dbs = new ApplicationDbContext();
//            db.Database.Delete();
//            dbs.Database.Delete();
//        }
//        [TestCleanup]
//        public void Clean()
//        {
//            Context db = new Context();
//            ApplicationDbContext dbs = new ApplicationDbContext();
//            db.Database.Delete();
//            dbs.Database.Delete();
//        }
//        [TestMethod]
//        [HostType("ASP.NET")]
//        [OverrideAuthentication()]
//        [UrlToTest(@"https://localhost/FoodWuzUp.Web")]
//        //[AspNetDevelopmentServer(@"L:\Code\Git\FoodWuzUp\FoodWuzUp.Web\", @"/")]
//        public void TestMethod1()
//        {
//            ApplicationDbContext db = new ApplicationDbContext();
//            ApplicationUserManager aum = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

//            AccountController ac = new AccountController(aum);
//            ActionResult ar = ac.Register();
//            MvcApplication mvc = new MvcApplication();
//            Models.RegisterViewModel model = new Models.RegisterViewModel() { UserName = "Bob", Email = "Bob@Aol.com", Password = "passWord1!", ConfirmPassword = "passWord1!" };
//            Task<ActionResult> arr = ac.Register(model);
//            arr.Wait();
//            ActionResult result = arr.Result;

//            Assert.IsTrue(false);


//        }
//    }
//}
