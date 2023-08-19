namespace FoodDelivery
{
    public class MenuItem : IPrintable
    {
        public string Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public MenuItem()
        {
            Id = Guid.NewGuid().ToString();
        }

        public void Print()
        {
            Console.WriteLine($"Product Info: {Id} {Name} {Description} {Price}");
        }
    }
}