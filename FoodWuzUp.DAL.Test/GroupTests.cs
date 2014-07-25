using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodWuzUp.DAL;
using System.Linq;

namespace FoodWuzUp.DAL.Test
{

    [TestClass]
    public class GroupTests
    {
        [TestInitialize]
        public void Init()
        {
            Context db = new Context();
            db.Database.Delete();
        }
        [TestCleanup]
        public void Clean()
        {
            Context db = new Context();
            db.Database.Delete();
        }
        [TestMethod]
        public void TestGroupCreate()
        {
            Context db = new Context();
            Group gp = new Group() { Name = "test", Description = "newtest" };
            gp.Comments.Add(new GroupComment() { Comment = "New Comment" });
            db.Groups.Add(gp);
            db.SaveChanges();

            db = new Context();
            Group newgp = db.Groups.Include("Comments").Where(o => o.Name == "test").Single();
            Assert.AreEqual("newtest", newgp.Description);
            Assert.AreEqual(1, newgp.Comments.Count);

        }
    }
}
