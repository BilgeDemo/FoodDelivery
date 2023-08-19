namespace FoodDelivery
{
    public interface IRestaurantRepository
    {
        Restaurant GetRestaurantById(string id);
        Restaurant GetRestaurantByName(string name);
        List<Restaurant> GetRestaurants();
        void AddRestaurant(Restaurant restaurant);
        void RemoveRestaurant(Restaurant restaurant);

        public void AddMenuItem(Restaurant restaurant, MenuItem menuItem)
        {
            restaurant.AddMenuItem(menuItem);
        }
    }
}
