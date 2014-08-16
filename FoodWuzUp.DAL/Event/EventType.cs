using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class EventType : Base<EventType>
    {

        public override void Init(Context db)
        {
            base.Init(db);
            db.EventTypes.Add(new EventType() { Name = "Group", Description = "Wants to be added to {0}" });
            db.EventTypes.Add(new EventType() { Name = "RatingRequest", Description = "Could you Rate this {0} " });
        }
    }
}
