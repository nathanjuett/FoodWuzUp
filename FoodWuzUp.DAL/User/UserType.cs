using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class UserType : Base<UserType>
    {

        public override void Init(Context db)
        {
            base.Init(db);
            db.UserTypes.Add(new UserType() { Name = "Guest", Description = "Guest Users can view and add rattings." });
            db.UserTypes.Add(new UserType() { Name = "Contributor", Description = "Contributors have the access that guests have and can add Restaurants, Employees, and Menu Items " });
            db.UserTypes.Add(new UserType() { Name = "Administrator", Description = "Administrators have all the rights of Contributors and can add users to the Group" });
        }
    }
}
