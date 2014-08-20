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

            //ApplicationAuthType google = new ApplicationAuthType() { Name = "Google", ThirdPartyKey = "767908454013-n8obtkbr51sjm57jgeh9i3dtbep0c7sb.apps.googleusercontent.com", ThirdPartySecret = "l-11RV3J9E_5QB-vXB7wLS5m" };
            
            ApplicationAuthType google = db.ApplicationAuthTypes.Single(o=> o.Name == "Google");
            google.ThirdPartyKey = "794421591270-204pj3cnd72bf5rp9b44ib7l9vedr8fh.apps.googleusercontent.com";
            google.ThirdPartySecret = "sVOPsL_afGiex4nkf0O76F5p";

            ApplicationAuthType facebook = db.ApplicationAuthTypes.Single(o => o.Name == "Facebook");
            facebook.ThirdPartyKey = "298659913639585";
            facebook.ThirdPartySecret = "24481b3b74c8478a26c8144778237db1";

            db.SaveChanges();
           // ApplicationAuthType facebook = new ApplicationAuthType() { Name = "Facebook", ThirdPartyKey = "675135002567966", ThirdPartySecret = "d926d4f1094111a4cc49a9ddddfb005c" };
 

            User User1 = db.Users.Add(new User() { AuthID = Guid.NewGuid().ToString(), Name = "Nathan", Description = "NateDogg" });
            User User2 = db.Users.Add(new User() { AuthID = Guid.NewGuid().ToString(), Name = "Joe", Description = "JoeFacedKilla" });
            User User3 = db.Users.Add(new User() { AuthID = Guid.NewGuid().ToString(), Name = "Pam", Description = "NittaPleaze" });
            User User4 = db.Users.Add(new User() { AuthID = Guid.NewGuid().ToString(), Name = "Cory", Description = "SayWhat" });
            User User5 = db.Users.Add(new User() { AuthID = Guid.NewGuid().ToString(), Name = "Paula", Description = "The Balla" });
            User User6 = db.Users.Add(new User() { AuthID = Guid.NewGuid().ToString(), Name = "TheHopefull", Description = "Has All Restaurants" });
            db.SaveChanges();

            Group group1 = db.Groups.Add(new Group() { Name = "Downtown", Creator = User1, Description = "Breakfast club got nothing on us." });
            Group group2 = db.Groups.Add(new Group() { Name = "ClearLake", Creator = User3, Description = "Time for Lunch" });
            Group group3 = db.Groups.Add(new Group() { Name = "Work", Creator = User1, Description = "We go early" });
            Group group4 = db.Groups.Add(new Group() { Name = "Private", Creator = User2, Description = "I don't have any users" });
            Group group5 = db.Groups.Add(new Group() { Name = "Public", Creator = User4, Description = "I include everyone." });
            db.SaveChanges();

            GroupUser groupuser1 = db.GroupUsers.Add(new GroupUser() { Parent = group1, Child = User1, UserType = db.UserTypes.Single(o=> o.Name == "Administrator") });
            GroupUser groupuser2 = db.GroupUsers.Add(new GroupUser() { Parent = group2, Child = User1, UserType = db.UserTypes.Single(o => o.Name == "Administrator") });
            GroupUser groupuser3 = db.GroupUsers.Add(new GroupUser() { Parent = group3, Child = User1, UserType = db.UserTypes.Single(o => o.Name == "Contributor") });
            GroupUser groupuser4 = db.GroupUsers.Add(new GroupUser() { Parent = group4, Child = User1, UserType = db.UserTypes.Single(o => o.Name == "Guest") });
            GroupUser groupuser5 = db.GroupUsers.Add(new GroupUser() { Parent = group5, Child = User1, UserType = db.UserTypes.Single(o => o.Name == "Guest") });
            GroupUser groupuser6 = db.GroupUsers.Add(new GroupUser() { Parent = group1, Child = User2, UserType = db.UserTypes.Single(o => o.Name == "Guest") });
            db.SaveChanges();

            Restaurant restaurant0 = db.Restaurants.Add(new Restaurant() { Group = group1, Name = "CharBar", UniqueID = Guid.NewGuid() });
            Restaurant restaurant1 = db.Restaurants.Add(new Restaurant() { Group = group1, Name = "Shay's", UniqueID = Guid.NewGuid() });
            Restaurant restaurant2 = db.Restaurants.Add(new Restaurant() { Group = group1, Name = "Sambuca", UniqueID = Guid.NewGuid() });
            Restaurant restaurant3 = db.Restaurants.Add(new Restaurant() { Group = group1, Name = "Tacate", UniqueID = Guid.NewGuid() });
            Restaurant restaurant4 = db.Restaurants.Add(new Restaurant() { Group = group1, Name = "The Pastry War", UniqueID = Guid.NewGuid() });
            Restaurant restaurant5 = db.Restaurants.Add(new Restaurant() { Group = group1, Name = "Clutch City Squire", UniqueID = Guid.NewGuid() });
            Restaurant restaurant6 = db.Restaurants.Add(new Restaurant() { Group = group1, Name = "The Egg and I", UniqueID = Guid.NewGuid() });
            Restaurant restaurant7 = db.Restaurants.Add(new Restaurant() { Group = group1, Name = "Long Horn Steak House", UniqueID = Guid.NewGuid() });
            Restaurant restaurant8 = db.Restaurants.Add(new Restaurant() { Group = group1, Name = "The Other", UniqueID = Guid.NewGuid() });
            group2.Restaurants.Add(restaurant0);
            group3.Restaurants.Add(restaurant1);
            group5.Restaurants.Add(restaurant2);
            db.SaveChanges();


            Employee employee0 = db.Employees.Add(new Employee() { UniqueID = Guid.NewGuid(), Name = "Charlean", Description = "GirlWonder" });
            Employee employee1 = db.Employees.Add(new Employee() { UniqueID = Guid.NewGuid(), Name = "The Duke", Description = "Do You Have To Ask" });
            Employee employee2 = db.Employees.Add(new Employee() { UniqueID = Guid.NewGuid(), Name = "Holly", Description = "Dont take no SHIT" });
            Employee employee3 = db.Employees.Add(new Employee() { UniqueID = Guid.NewGuid(), Name = "Christopher", Description = "The Poet" });
            Employee employee4 = db.Employees.Add(new Employee() { UniqueID = Guid.NewGuid(), Name = "Joshua", Description = "The Fashonable" });
            Employee employee5 = db.Employees.Add(new Employee() { UniqueID = Guid.NewGuid(), Name = "Jill", Description = "The Unknown" });
            restaurant0.Employees.Add(new RestaurantEmployee() {  Child = employee0, EmployeeTypeID = 11, RatingID = 1 });
            restaurant0.Employees.Add(new RestaurantEmployee() { Child = employee1, EmployeeTypeID = 1, RatingID = 1 });
            restaurant1.Employees.Add(new RestaurantEmployee() { Child = employee2, EmployeeTypeID = 2, RatingID = 1 });
            restaurant2.Employees.Add(new RestaurantEmployee() { Child = employee3, EmployeeTypeID = 7, RatingID = 1 });
            restaurant2.Employees.Add(new RestaurantEmployee() { Child = employee4, EmployeeTypeID = 4, RatingID = 1 });

            db.SaveChanges();


        }
    }
}
