using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodWuzUp.Core;

namespace FoodWuzUp.DAL
{
    public class Contest : Base<Contest>
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string MenuItem { get; set; }
    }

    public class ContestDetail : Base<ContestDetail>
    {
        [ForeignKey("Contest")]
        public int ContestID { get; set; }
        [ForeignKey("Resturant")]
        public int RestaurantID { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuItemID { get; set; }

        public virtual Contest Contest { get; set; }
        public virtual Restaurant Resturant { get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }

    public class ContestDetailRating : Base<ContestDetailRating>, IBaseWithComments<ContestDetailRating, ContestDetailRatingComment>
    {
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("ContestDetail")]
        public int ContestDetailID { get; set; }
        [ForeignKey("Rating")]
        public int RatingID { get; set; }
        
        public DateTime? DateRated { get; set; }

        public virtual User User { get; set; }
        public virtual ContestDetail ContestDetail { get; set; }
        public virtual Rating Rating { get; set; }

        public virtual ICollection<ContestDetailRatingComment> Comments { get; set; }
        
    }

}
