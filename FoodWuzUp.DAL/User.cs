using FoodWuzUp.Core;
using System.Collections.Generic;
namespace FoodWuzUp.DAL
{
    public class User : Base<User>
    {
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<UserMenuItemRating> UserMenuItemRatings { get; set; }


        public User()
        {
            Groups = new List<Group>();
            UserMenuItemRatings = new List<UserMenuItemRating>();
        }
    }
     
  
   

}