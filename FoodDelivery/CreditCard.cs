namespace FoodDelivery
{
    public class CreditCard : IPaymentMethod
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} by credit card.");
        }
    }
}
