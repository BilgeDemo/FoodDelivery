namespace FoodDelivery
{
    public class Customer
    {
        private User _user;

        private List<Address> _address;

        public Customer(User user)
        {
            _user = user;
            _address = new List<Address>();
            if(_user.GetPermission() != Permission.Customer)
            {
                throw new Exception("Only customers can create customers.");
            }
        }

        public void AddAddress(Address address)
        {
            _address.Add(address);
        }

        internal void AddAddresses(List<Address> addresses)
        {
            _address.AddRange(addresses);
        }

        internal Address GetAddressById(string? addressId)
        {
            return _address.Find(a => a.Id == addressId);
        }

        internal List<Address> GetAddresses()
        {
            return _address;
        }
    }
}
