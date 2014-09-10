using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodWuzUp.Core;

namespace FoodWuzUp.Core.Test
{
    [TestClass]
    public class ParametersTests
    {
        [TestMethod]
        public void TestPropertyConstructors()
        {
            Parameters p = new Parameters();
            Assert.AreNotEqual(null, p.filters);
            Assert.AreNotEqual(null, p.orderby);
        }
    }
}
