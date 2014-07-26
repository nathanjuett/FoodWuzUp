using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL.Test
{
    [TestClass]
   public  class UserTests: BaseTest<User>
    {
        [TestMethod]
        public void UserCreateTest()
        {
            base.BaseCreateTest();
        }
        public override User Create(User efObject, Context db)
       {
           return efObject;
       }
       public override void AddedAsserts(Context db, User efobject, string unique)
       {
           base.AddedAsserts(db, efobject, unique);
       }
        [TestMethod]
        public void UserTestAddMenuItemRating()
       {
           Context db = new Context();
           User u = new User() { Name = "test" };
           MenuItem mi = new MenuItem() { Name = "Extra Long Chili Cheese Coney", Description = "ELCCC" };
           db.Users.Add(u);
           db.MenuItems.Add(mi);
            db.SaveChanges();
            u.UserMenuItemRatings.Add(new UserMenuItemRating() { Child = mi, RatingID = 1 });
            db.SaveChanges();

            db = new Context();
            User actual = db.Users.Include("UserMenuItemRatings.Rating").Where(o => o.Name == "test").Single();

            Assert.AreEqual("1Star", actual.UserMenuItemRatings.Take(1).Single().Rating.Name);

       }
    }
}
