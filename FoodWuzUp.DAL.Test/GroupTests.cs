using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodWuzUp.DAL;
using System.Linq;

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
        
    }
}
