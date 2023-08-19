using FoodDelivery;

internal class Program
{
    private static void Main(string[] args)
    {
        var foodDeliverySystem = new FoodDeliverySystem(new UserRepository(), new RestaurantRepository());

        foodDeliverySystem.Open();
        Console.ReadLine();
    }
}