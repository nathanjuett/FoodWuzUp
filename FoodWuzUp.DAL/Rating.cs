using System.Linq;

namespace FoodWuzUp.DAL
{
    public class Rating : Base<Rating>
    {
        public override void Init(Context db)
        {
            base.Init(db);
             for (int i = 1; i < 6; i++)
                if (i == 1)
                    db.Ratings.Add(new Rating() { Name = i.ToString() + "Star", Description = i.ToString() + " Star" });
                else
                    db.Ratings.Add(new Rating() { Name = i.ToString() + "Stars", Description = i.ToString() + " Stars" });

        }
    }
}