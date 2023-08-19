using System.Collections.Specialized;

namespace FoodDelivery
{
    public class Order : IOrderedDisplayable
    {
        private Dictionary<string, OrderItem> _menuOrder;
        private Address _deliveryAddress;
        private DateTime _orderTime;
        private Customer _customer;
        private Restaurant _restaurant;

        private double _totalPrice;

        public Order(Customer customer, Restaurant restaurant)
        {
            _customer = customer;
            _restaurant = restaurant;
            _orderTime = DateTime.Now;
            _menuOrder = new Dictionary<string, OrderItem>();
        }

        public void AddItem(MenuItem menuItem, int amount)
        {
            if(_menuOrder.TryAdd(menuItem.Id, new OrderItem(menuItem, amount)))
            {
                Console.WriteLine("Item added to order");
            }
            else
            {
                _menuOrder[menuItem.Id].Amount += amount;
            }
        }

        public void CalculateTotalPrice()
        {
            _totalPrice = 0.0;
            foreach(var item in _menuOrder.Values)
            {
                _totalPrice += item.MenuItem.Price * item.Amount;
            }
        }

        public List<OrderItem> GetOrderItems()
        {
            return _menuOrder.Values.ToList();
        }

        public double GetTotalPrice()
        {
            return _totalPrice;
        }

        public void AddAddress(Address? address)
        {
            _deliveryAddress = address;
        }

        public void CompleteOrder(IPaymentMethod paymentMethod)
        {
            paymentMethod.Pay(_totalPrice);
        }
    }
}
