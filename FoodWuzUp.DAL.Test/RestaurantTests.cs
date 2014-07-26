using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL.Test
{

    [TestClass]
    public class RestaurantTests : BaseWithCommentsTest<Restaurant, RestaurantComment>
    {

        [TestMethod]
        public void RestaurantCreateTest()
        {
            base.BaseCreateTest();
        }
        public override Restaurant Create(Restaurant efobject, Context db)
        {
            db.Groups.Add(new Group() { Name = "TestGroup" });
            efobject.Group = db.Groups.Find(1);
            return base.Create(efobject, db);
        }
        public override void AddedAsserts(Context db, Restaurant efobject, string unique)
        {
            base.AddedAsserts(db, efobject, unique);
            Assert.AreEqual(1, efobject.GroupID);
        }

        [TestMethod]
        public void RestaurantAddEmployeeTest()
        {
            Context db = new Context();
            Group grp = db.Groups.Add(new Group() { Name = "testGroup" });
            Restaurant r = db.Restaurants.Add(new Restaurant() { Name = "test", Group = grp });
            db.SaveChanges();
            r.Employees.Add(new RestaurantEmployee() { Child = new Employee() { Name = "Bob" }, EmployeeTypeID = 1 });
            db.SaveChanges();
            db = new Context();
            RestaurantEmployee re = db.Restaurants.Include("Employees").Where(o => o.Name == "test").Select(o => o.Employees.Where(e => e.Child.Name == "Bob").FirstOrDefault()).Single();

            re.Rating = db.Ratings.Find(1);
            db.SaveChanges();

            Assert.AreEqual(1, db.RestaurantEmployees.Count());
            RestaurantEmployee re1 = db.RestaurantEmployees.Take(1).Single();
            Assert.AreEqual(1, re1.RatingID = 1);

        }
    }
}
