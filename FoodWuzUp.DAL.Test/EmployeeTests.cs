using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FoodWuzUp.DAL.Test
{
 
    [TestClass]
    public class EmployeeTests : BaseWithCommentsTest<Employee, EmployeeComment>
    {
        [TestMethod]
        public void EmployeeCreateTest()
        {
            base.BaseCreateTest();
        }
        [TestMethod]
        public void EmployeeRatingTest()
        {
            Context db = new Context();
            Employee actual = db.Employees.Include(o => o.Ratings).Single(o => o.Name == "Charlean");
           Assert.AreEqual(1, actual.Rating);
        }
        [TestMethod]
        public void EmployeeRatingStringTest()
        {
            Context db = new Context();
            Employee actual = db.Employees.Include(o => o.Ratings).Single(o => o.Name == "Charlean");
            Assert.AreEqual("1.00 Star(s)", actual.RatingString);
        }
        [TestMethod]
        public void EmployeeMultipleRatingStringTest()
        {
            Context db = new Context();
            Employee actual = db.Employees.Include(o => o.Ratings).Single(o => o.Name == "The Duke");
            Assert.AreEqual("2.50 Star(s)", actual.RatingString);
        }
        [TestMethod]
        public void EmployeeNoRatingStringTest()
        {
            Context db = new Context();
            Employee actual = db.Employees.Include(o => o.Ratings).Single(o => o.Name == "Holly");
            Assert.AreEqual("Not Yet Rated", actual.RatingString);
        }
    }
}
