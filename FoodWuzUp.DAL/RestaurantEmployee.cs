using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodWuzUp.Core;

namespace FoodWuzUp.DAL
{
   public class RestaurantEmployee : BaseXref<RestaurantEmployee,Restaurant,Employee>
    {
        public int EmployeeTypeID { get; set; }

        public virtual EmployeeType EmployeeType { get; set; }


    }
}
