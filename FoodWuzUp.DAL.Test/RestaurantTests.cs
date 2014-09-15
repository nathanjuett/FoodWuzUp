using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
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
            RestaurantEmployee re = db.Restaurants.Include(o => o.Employees).Where(o => o.Name == "test").Select(o => o.Employees.Where(e => e.Child.Name == "Bob").FirstOrDefault()).Single();

            re.Rating = db.Ratings.Find(1);
            db.SaveChanges();

            Assert.AreEqual(6, db.RestaurantEmployees.Count());
            RestaurantEmployee re1 = db.RestaurantEmployees.Take(1).Single();
            Assert.AreEqual(1, re1.RatingID = 1);

        }
        [TestMethod]
        public void RestaurantClone()
        {
            Restaurant obj = new Restaurant() { ID = 5, Name = "test", Description = "testdesc", Group = new Group() { ID = 1, Name = "Group1" } };
            Restaurant newobj = (Restaurant)obj.Clone();
            Assert.AreNotEqual(obj, newobj);
            Assert.AreNotEqual(obj.ID, newobj.ID);
            Assert.AreNotEqual(obj.UniqueID, newobj.UniqueID);
            Assert.AreNotEqual(obj.Group, newobj.Group);
            Assert.AreEqual(obj.Name, newobj.Name);
            Assert.AreEqual(obj.Description, newobj.Description);
            Assert.AreNotEqual(obj.Employees, newobj.Employees);


        }

        [TestMethod]
        public void RestaurantRatingTest()
        {
            Context db = new Context();
            Restaurant actual = db.Restaurants.Include(o => o.Ratings).Single(o => o.Name == "CharBar");
            Assert.AreEqual(1, actual.Rating);
        }
        [TestMethod]
        public void RestaurantRatingStringTest()
        {
            Context db = new Context();
            Restaurant actual = db.Restaurants.Include(o => o.Ratings).Single(o => o.Name == "CharBar");
            Assert.AreEqual("1.00 Star(s) by 1 Users", actual.RatingString);
        }
        [TestMethod]
        public void RestaurantMultipleRatingStringTest()
        {
            Context db = new Context();
            Restaurant actual = db.Restaurants.Include(o => o.Ratings).Single(o => o.Name == "Shay's");
            Assert.AreEqual("2.50 Star(s) by 2 Users", actual.RatingString);
        }
        [TestMethod]
        public void RestaurantNoRatingStringTest()
        {
            Context db = new Context();
            Restaurant actual = db.Restaurants.Include(o => o.Ratings).Single(o => o.Name == "Sambuca");
            Assert.AreEqual("Not Yet Rated", actual.RatingString);
        }

    }
}
