using FoodWuzUp.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class Employee : Base<Employee>, IBaseWithComments<Employee, EmployeeComment>
    {
        public Guid UniqueID { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public virtual ICollection<EmployeeComment> Comments { get; set; }
        public virtual ICollection<UserEmployeeRating> Ratings { get; set; }

        public Employee()
        {
            Ratings = new List<UserEmployeeRating>();
            Restaurants = new List<Restaurant>();
            Comments = new List<EmployeeComment>();
            UniqueID = Guid.NewGuid();
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
