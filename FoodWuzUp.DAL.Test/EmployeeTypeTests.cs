using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL.Test
{
    [TestClass]
    public class EmployeeTypeTests : BaseTest<EmployeeType>
    {
        [TestMethod]
        public void EmployeeTypeCreateTest()
        {
            base.BaseCreateTest();
        }
        public override EmployeeType Create(EmployeeType efObject, Context db)
        {
            return efObject;
        }
        public override void AddedAsserts(Context db, EmployeeType efobject, string unique)
        {
            Assert.AreEqual("Owner", efobject.Name);
            int count = db.EmployeeTypes.Count();
            Assert.AreEqual(15, count);
            Assert.AreEqual(unique, db.EmployeeTypes.Find(count).Name);
        }
    }
}
