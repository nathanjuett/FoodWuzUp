using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodWuzUp.Core;
using System.ComponentModel.DataAnnotations;

namespace FoodWuzUp.DAL
{
    public class Group : Base<Group>, IBaseWithComments<Group, GroupComment>
    {
        [Display(Name = "Group")]
        public new string Name { get { return base.Name; } set { base.Name = value; } }

        public int? CreatorID { get; set; }


        public virtual User Creator { get; set; }
       public virtual ICollection<GroupUser> Members { get; set; }
       public virtual ICollection<Restaurant> Restaurants { get; set; }
       public virtual ICollection<GroupComment> Comments { get; set; }
       public virtual ICollection<Employee> Employees { get; set; }


        public Group()
       {
           Comments = new List<GroupComment>();
           Members = new List<GroupUser>();
           Restaurants = new List<Restaurant>();
           Employees = new List<Employee>();
       }

    }
}
