namespace FoodWuzUp.Core
{
    public interface IBaseXref
    {
        int ParentID { get; set; }
        int ChildID { get; set; }
    }
}