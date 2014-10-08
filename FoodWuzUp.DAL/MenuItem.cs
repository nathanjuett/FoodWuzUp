using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FoodWuzUp.DAL
{
    public class MenuItem : Base<MenuItem>
    {
        public virtual ICollection<RestaurantMenuItem> Ratings { get; set; }
        public MenuItem()
        {
            Ratings = new List<RestaurantMenuItem>();
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
                    sum += item.RatingID.Value - 1;
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