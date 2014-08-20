using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWuzUp.DAL
{
    public class RestaurantType : Base<RestaurantType>
    {

        public override void Init(Context db)
        {
            base.Init(db);
            db.RestaurantTypes.Add(new RestaurantType() { Name = "Italian" });
            db.RestaurantTypes.Add(new RestaurantType() { Name = "Thai" });
            db.RestaurantTypes.Add(new RestaurantType() { Name = "American" });
            db.RestaurantTypes.Add(new RestaurantType() { Name = "Mexican" });
            db.RestaurantTypes.Add(new RestaurantType() { Name = "Vietnamese" });
            db.RestaurantTypes.Add(new RestaurantType() { Name = "BBQ" });
            db.RestaurantTypes.Add(new RestaurantType() { Name = "Chinese" });
            db.RestaurantTypes.Add(new RestaurantType() { Name = "Steak House" });
            db.RestaurantTypes.Add(new RestaurantType() { Name = "Bar" });
        }
    }
}
