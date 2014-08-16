using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodWuzUp.DAL;
using System.Linq;

namespace FoodWuzUp.DAL.Test
{
    [TestClass]
    public class EventTests
    {
        [TestMethod]
        public void TestCreate()
        {
            Context db = new Context(new DemoContextInitializer());
            db.Events.Add(new Event() { UserID = 1, RequestingUserID = 1, EventTypeID = 1, Name = "test" });
            db.SaveChanges();
        }
    }
}
