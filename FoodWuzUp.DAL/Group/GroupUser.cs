using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class GroupUser : BaseXref<GroupUser, Group, User>
    {
        public int UserTypeID { get; set; }
        public UserType UserType { get; set; }
    }
}
