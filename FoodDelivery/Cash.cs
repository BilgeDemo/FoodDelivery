using FoodDelivery;

public class Cash : IPaymentMethod
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount} by cash.");
    }
}