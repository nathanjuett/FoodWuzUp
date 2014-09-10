using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodWuzUp.DAL;
using System.Linq;
using System.Data.Entity;

namespace FoodWuzUp.DAL.Test
{

    [TestClass]
    public class GroupTests : BaseWithCommentsTest<Group, GroupComment>
    {
        [TestMethod]
        public void GroupCreateTest()
        {
            base.BaseCreateTest();
        }
        [TestMethod]
        public void CreatorTest()
        {
            Context db = new Context();
            Group actual = db.Groups.Include(o=> o.Creator).Single(o => o.Name == "Downtown");
            Assert.AreEqual("Nathan", actual.CreatorName);

        }
    }
}
