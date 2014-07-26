using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodWuzUp.Core;

namespace FoodWuzUp.DAL
{
    public class Group : Base<Group>, IBaseWithComments<Group, GroupComment>
    {

        public int? CreatorID { get; set; }


        public virtual User Creator { get; set; }
       public virtual ICollection<User> Members { get; set; }
       public virtual ICollection<Restaurant> Restaurants { get; set; }
       public virtual ICollection<GroupComment> Comments { get; set; }
       public virtual ICollection<Employee> Employees { get; set; }


        public Group()
       {
           Comments = new List<GroupComment>();
       }

    }
}
