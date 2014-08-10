using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class DemoContextInitializer : ContextInitializer
    {
        protected override void Seed(Context db)
        {
            base.Seed(db);
            //User Creator = db.Users.Add(new User() { AuthID = Guid.NewGuid().ToString(), Name = "Nathan", Description = "NateDogg" });
            //db.Users.Add(new User() { AuthID = Guid.NewGuid().ToString(), Name = "Joe", Description = "JoeFacedKilla" });
            //db.Users.Add(new User() { AuthID = Guid.NewGuid().ToString(), Name = "Pam", Description = "NittaPleaze" });

            //Group group = db.Groups.Add(new Group() { Name = "Downtown", Creator = Creator, Description = "Breakfast club got nothing on us." });

            //Restaurant restaurant = db.Restaurants.Add(new Restaurant() { Group = group, Name = "CharBar", UniqueID = Guid.NewGuid() });

            //Employee employee = db.Employees.Add(new Employee() { UniqueID = Guid.NewGuid(), Name = "Char", Description = "GirlWonder" });
            //restaurant.Employees.Add(new RestaurantEmployee() { Parent = restaurant, Child = employee, EmployeeTypeID = 1, RatingID = 1 });




        }
    }
}
