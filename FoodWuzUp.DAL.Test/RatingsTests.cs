using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL.Test
{
    [TestClass]
    public class RatingsTests : BaseTest<Rating>
    {
        [TestMethod]
        public void RatingCreateTest()
        {
            base.BaseCreateTest();
        }
        public override Rating Create(Rating efObject, Context db)
        {
            return efObject;
        }
        public override void AddedAsserts(Context db, Rating efobject, string unique)
        {
            Assert.AreEqual("1Star", efobject.Name);
            int count = db.Ratings.Count();
            Assert.AreEqual(6, count);
            Assert.AreEqual(unique, db.Ratings.Find(count).Name);
        }
    }
}
