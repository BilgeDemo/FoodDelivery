namespace FoodDelivery
{
    public class OrderItem : IPrintable
    {
        public MenuItem MenuItem { get; set; }
        public int Amount { get;set; }

        public OrderItem(MenuItem menuItem, int amount)
        {
            MenuItem = menuItem;
            Amount = amount;
        }

        public void Print()
        {
            Console.WriteLine($"Product Info: {MenuItem.Name} {MenuItem.Description} {MenuItem.Price} {Amount}");
        }
    }
}