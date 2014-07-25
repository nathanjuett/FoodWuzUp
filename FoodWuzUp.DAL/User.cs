using System.Collections.Generic;
namespace FoodWuzUp.DAL
{
    public class User : Base<User>
    {
        public virtual ICollection<Group> Groups {get;set;}

    }
}