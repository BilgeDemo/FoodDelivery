namespace FoodDelivery
{
    public interface IMenuDisplayable
    {
        public List<MenuItem> GetMenu();

        public MenuItem GetMenuItemWithId(string name);

    }
}