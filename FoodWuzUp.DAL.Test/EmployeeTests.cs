using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
    }
}
