using FoodWuzUp.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FoodWuzUp.DAL
{
    public class User : Base<User>
    {
        [Display(Name="User")]
        public new string Name { get { return base.Name; } set { base.Name = value; } }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<UserMenuItemRating> UserMenuItemRatings { get; set; }
        public virtual ICollection<UserRestaurantRating> UserRestaurantRatings { get; set; }
        public virtual ICollection<UserEmployeeRating> UserEmployeeRatings { get; set; }

        [Required]
        [MaxLength(128)]
        public string UserID { get; set; }

        public User()
        {
            Groups = new List<Group>();
            UserMenuItemRatings = new List<UserMenuItemRating>();
            UserRestaurantRatings = new List<UserRestaurantRating>();
            UserEmployeeRatings = new List<UserEmployeeRating>();
        }
    }
     
  
   

}