using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class GroupUser : BaseXref<GroupUser, Group, User>
    {
        [Required]
        public int UserTypeID { get; set; }
        public UserType UserType { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
