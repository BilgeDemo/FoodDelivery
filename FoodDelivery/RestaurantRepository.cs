using FoodDelivery;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly Dictionary<string, Restaurant> _restaurants;
    public RestaurantRepository()
    {
        _restaurants = new Dictionary<string, Restaurant>();
        Restaurant restaurant = new Restaurant("foofoo kebapcisi", new RestaurantOwner("john.doe", "john.doe@foofoo.com", "+905553332211"));
        restaurant.AddAddress(new Address("1790", "ankara", "cankaya", "06800", "gazi mah.", "89", "0", "fooo apartment"));

        restaurant.AddMenuItem(new MenuItem
        {
            Name = "adana kebap menu",
            Description = "adana kebap with ayran",
            Price = 20.0
        });

        restaurant.AddMenuItem(new MenuItem
        {
            Name = "urfa kebap menu",
            Description = "urfa kebap with ayran",
            Price = 18.0
        });

        restaurant.AddMenuItem(new MenuItem
        {
            Name = "pide menu",
            Description = "pide kebap with ayran",
            Price = 15.0
        });

        AddRestaurant(restaurant);
    }

    public void AddRestaurant(Restaurant restaurant)
    {
        if(_restaurants.TryAdd(restaurant.Id, restaurant))
        {
            Console.WriteLine($"Restaurant {restaurant.Name} added successfully");
        }
        else
        {
            Console.WriteLine($"Restaurant {restaurant.Name} could not be added");
        }
    }

    public Restaurant GetRestaurantById(string id)
    {
        if(_restaurants.TryGetValue(id, out var restaurant))
        {
            return restaurant;
        }
        return null;
    }

    public Restaurant GetRestaurantByName(string name)
    {
        if(_restaurants.Values.Any(r => r.Name == name))
        {
            return _restaurants.Values.First(r => r.Name == name);
        }
        return null;
    }

    public List<Restaurant> GetRestaurants()
    {
        return _restaurants.Values.ToList();
    }

    public void RemoveRestaurant(Restaurant restaurant)
    {
        
    }
}