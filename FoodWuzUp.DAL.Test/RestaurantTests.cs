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
    }
}
