using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL.Test
{
    [TestClass]
   public  class UserTests: BaseTest<User>
    {
        [TestMethod]
        public void UserCreateTest()
        {
            base.BaseCreateTest();
        }
        public override User Create(User efObject, Context db)
       {
           return efObject;
       }
       public override void AddedAsserts(Context db, User efobject, string unique)
       {
           base.AddedAsserts(db, efobject, unique);
       }
    }
}
