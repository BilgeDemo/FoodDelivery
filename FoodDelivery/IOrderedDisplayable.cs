namespace FoodDelivery
{
    public interface IOrderedDisplayable
    {
        public double GetTotalPrice();
        public void CalculateTotalPrice();

        public List<OrderItem> GetOrderItems();
    }
}