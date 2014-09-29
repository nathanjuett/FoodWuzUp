using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodWuzUp.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodWuzUp.DAL
{
   public class RestaurantEmployee : BaseXref<RestaurantEmployee,Restaurant,Employee>
    {
        public int EmployeeTypeID { get; set; }
        public int? RatingID { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public virtual Rating Rating { get; set; }

        [NotMapped]
        public string Employee { get; set; }
        [NotMapped]
        public string NewEmployeeType { get; set; }
    }
}
