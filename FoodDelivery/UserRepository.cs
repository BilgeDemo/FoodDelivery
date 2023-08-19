namespace FoodDelivery
{
    public class UserRepository : IUserRepository
    {
        private Dictionary<string, User> _users { get; set; }
        private Dictionary<string, Customer> _customers { get; set; }

        public UserRepository()
        {
            _users = new Dictionary<string, User>();
            _customers = new Dictionary<string, Customer>();

            var customerUser = new CustomerUser("jane.doe", "jane.doe@mail.com", "+905554443322");
            var address = new Address("1980", "ankara", "cankaya", "06800", "gazi mah.", "34", "3", "falanca apartment");

            AddUser(customerUser, new List<Address> { address });
        }

        public void AddUser(User user, List<Address> addresses)
        {
            if(_users.TryAdd(user.Id, user))
            {
                Console.WriteLine("User added successfully");
                _customers.Add(user.Id, new Customer(user));
                _customers[user.Id].AddAddresses(addresses);
            }
        }

        public User GetUserById(string id)
        {
            if(_users.TryGetValue(id, out var user))
            {
                return user;
            }
            return null;
        }

        public User GetUserByUserName(string userName)
        {
            if(_users.Any(u => u.Value.Name == userName))
            {
                return _users.First(u => u.Value.Name == userName).Value;
            }
            return null;
        }

        public Customer GetUserWithPermission(User user)
        {
            return _customers[user.Id];
        }

        public void RemoveUser(User user)
        {

        }
    }
}
