using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class Event : Base<Event>
    {
        public int UserID { get; set; }
        public int RequestingUserID { get; set; }
        public int EventTypeID { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Message { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual User User { get; set; }

    }
}
