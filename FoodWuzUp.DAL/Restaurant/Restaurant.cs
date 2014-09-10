using FoodWuzUp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FoodWuzUp.DAL
{
    public class Restaurant : Base<Restaurant>, IBaseWithComments<Restaurant, RestaurantComment>
    {
        [Required(ErrorMessage = "The Group field is required")]
        public int GroupID { get; set; }
        public Guid UniqueID { get; set; }
        public virtual Group Group { get; set; }
        [MaxLength(32)]
        public string Phone { get; set; }
        [MaxLength(512)]
        public string Url { get; set; }
        [MaxLength(512)]
        public string Address { get; set; }
        [ForeignKey("RestaurantType")]
        public int? RestaurantTypeID { get; set; }
        [Display(Name = "Resturant Type")]
        public RestaurantType RestaurantType { get; set; }
        public virtual ICollection<RestaurantMenuItem> MenuItems { get; set; }
        public virtual ICollection<RestaurantComment> Comments { get; set; }
        public virtual ICollection<RestaurantEmployee> Employees { get; set; }
        public virtual ICollection<UserRestaurantRating> Ratings { get; set; }
        public Restaurant()
        {
            Ratings = new List<UserRestaurantRating>();
            Comments = new List<RestaurantComment>();
            Employees = new List<RestaurantEmployee>();
            MenuItems = new List<RestaurantMenuItem>();
            UniqueID = Guid.NewGuid();
        }

        [NotMapped]
        public string AddressUrl
        {
            get
            {
                if (!String.IsNullOrEmpty(Address))
                    return Address.Replace('\n', ' ').Replace('\r', ' ');
                else
                    return Address;
            }
        }
        [NotMapped]
        public float Rating
        {
            get
            {
                int cnt = Ratings.Where(o => o.RatingID > 0).Count();
                if (cnt == 0)
                    return cnt;
                int sum = 0;
                foreach (var item in Ratings.Where(o => o.RatingID > 0))
                {
                    sum += item.RatingID - 1;
                }
                    return (float)sum / (float)cnt;
            }
        }
        [NotMapped]
        public string RatingString
        {
            get
            {
                if (Rating == 0)
                    return "Not Yet Rated";
                return Rating.ToString("f") + " Star(s)";
            }
        }
    }
}