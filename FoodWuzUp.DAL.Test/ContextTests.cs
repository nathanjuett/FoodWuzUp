using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace FoodWuzUp.DAL.Test
{
    [TestClass]
    public class ContextTests
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
        public void TestCustomInitializer()
        {
            Context db = new Context();
            List<RecordType> RecordTypes = db.RecordTypes.ToList();
            RecordType actual = RecordTypes.Find(o => o.ID == 1);
            Assert.AreEqual("RecordType", actual.Name);
        }
    }
}
