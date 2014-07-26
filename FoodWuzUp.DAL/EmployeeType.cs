using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodWuzUp.DAL
{
    public class EmployeeType : Base<EmployeeType>
    {

        public override void Init(Context db)
        {
            base.Init(db);
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Owner", Description = "Owner" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "GM", Description = "General Manager" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "AGM", Description = "Assistant General Manager" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Manager", Description = "Manager" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Bar Manager", Description = "Bar Manager" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Hostess", Description = "Greeter at the Front Desk" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Waiter", Description = "Waiter" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Waitress", Description = "Waitress" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Chef", Description = "Chef" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Sous Chef", Description = "Sous Chef" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Bartender", Description = "Bartender" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Bar Back", Description = "Bar Back" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Cocktail Waitress", Description = "Cocktail Waitress" });
            db.EmployeeTypes.Add(new EmployeeType() { Name = "Cashier", Description = "Cashier" });
           

        }
    }
}
