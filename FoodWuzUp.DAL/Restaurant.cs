using FoodWuzUp.Core;
using System.Collections.Generic;

namespace FoodWuzUp.DAL
{
    public class Restaurant : Base<Restaurant>, IBaseWithComments<Restaurant, RestaurantComment>
    {

        public int GroupID { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<RestaurantComment> Comments { get; set; }
        public virtual ICollection<RestaurantEmployee> Employees { get; set; }
        public Restaurant()
        {
            Comments = new List<RestaurantComment>();
            Employees = new List<RestaurantEmployee>();
            MenuItems = new List<MenuItem>();
        }
    }
}