namespace FoodWuzUp.DAL
{
    public class MenuItem : Base<MenuItem>
    {
        public int RatingID { get; set; }

        public virtual Rating Rating { get; set; }

    }
}