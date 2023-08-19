using System.Security.Cryptography.X509Certificates;

namespace FoodDelivery
{
    public class FoodDeliverySystem
    {
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public FoodDeliverySystem(IUserRepository userRepository, IRestaurantRepository restaurantRepository)
        {
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
        }

        internal void Open()
        {
            Console.WriteLine("Welcome Food Delivery System...... ");
            var activeUser = Login();

            ShowWelcomeMessage(activeUser);

            if (activeUser.GetPermission() == Permission.RestaurantOwner)
            {
                ShowRestaurantOwnerMenu();
            }
            else
            {
                var customer = _userRepository.GetUserWithPermission(activeUser);
                ShowCustomerMenu(customer);
            }
        }

        private void ShowCustomerMenu(Customer activeUser)
        {
            var restaurantList = _restaurantRepository.GetRestaurants();
            var cont = true;
            Address address = null;
            do
            {
                foreach (var add in activeUser.GetAddresses())
                {
                    Console.WriteLine($"{add.Id} - {add.Street} {add.City} {add.District} {add.Building}");
                }
                Console.WriteLine("Choose an address to deliver to");
                var addressId = Console.ReadLine();
                address = activeUser.GetAddressById(addressId);
                if (address == null)
                {
                    Console.WriteLine("Address not found");
                    cont = false;
                }
            } while (!cont);


            Restaurant selectedRestaurant;
            do
            {
                foreach (var restaurant in restaurantList)
                {
                    Console.WriteLine($"{restaurant.Id} - {restaurant.Name}");
                    Console.WriteLine("Choose a restaurant to see the menu");
                }
                var restaurantId = Console.ReadLine();
                selectedRestaurant = _restaurantRepository.GetRestaurantById(restaurantId);
                if (selectedRestaurant == null)
                {
                    Console.WriteLine("Restaurant not found");
                    cont = false;
                }
            } while (!cont);

            foreach (var menuItem in selectedRestaurant.GetMenu())
            {
                menuItem.Print();
            }

            var order = new Order(activeUser, selectedRestaurant);
            order.AddAddress(address);

            cont = false;
            do
            {
                Console.WriteLine("Choose a menu item to order (to complete Enter (!C)");
                var menuItemId = Console.ReadLine();
                if (menuItemId == "!C")
                {
                    break;
                }

                var selectedMenuItem = selectedRestaurant.GetMenuItemWithId(menuItemId);
                if (selectedMenuItem == null)
                {
                    Console.WriteLine("Menu item not found");
                    cont = false;
                }

                Console.WriteLine("Enter amount");
                if (!int.TryParse(Console.ReadLine(), out int amount))
                {
                    Console.WriteLine("Invalid amount");
                    cont = false;
                }

                order.AddItem(selectedMenuItem, amount);

            } while (!cont);


            order.CalculateTotalPrice();
            foreach (var item in order.GetOrderItems())
            {
                Console.WriteLine($"{item.MenuItem.Name} - {item.Amount} - {item.MenuItem.Price}");
            }

            Console.WriteLine($"Total price is {order.GetTotalPrice()}");
            Console.WriteLine("Enter 1 to confirm order, 2 to cancel");
            if (Console.ReadLine() == "1")
            {
                Console.WriteLine("Order confirmed");
                Console.WriteLine("Enter 1 to pay with cash, 2 to pay with credit card");
                switch(Console.ReadLine())
                {
                    case "1":
                        order.CompleteOrder(new Cash());
                        break;
                    case "2":
                        order.CompleteOrder(new CreditCard());
                        break;
                    default:
                        Console.WriteLine("Invalid payment method");
                        break;
                }

            }
            else
            {
                Console.WriteLine("Order cancelled");
            }
        }

        private void ShowRestaurantOwnerMenu()
        {
            Console.WriteLine("N/A");
        }

        private void ShowWelcomeMessage(User activeUser)
        {
            Console.WriteLine($"Welcome {activeUser.Name}");
        }

        private User Login()
        {
            Console.WriteLine("For customer login enter 1, for restaurant owner login enter 2");
            if (!int.TryParse(Console.ReadLine(), out var loginType))
            {
                Console.WriteLine("Please enter a valid login type");
                return Login();
            }

            switch (loginType)
            {
                case 1:
                    return LoginCustomer();
                case 2:
                    return LoginRestaurantOwner();
                default:
                    Console.WriteLine("Please enter a valid login type");
                    return Login();
            }
        }

        private User LoginRestaurantOwner()
        {
            return UserLogin<RestaurantOwner>();
        }

        private User LoginCustomer()
        {
            return UserLogin<CustomerUser>();
        }

        private T UserLogin<T>() where T : User
        {
            Console.WriteLine("UserName : ");
            var userName = Console.ReadLine();

            var user = _userRepository.GetUserByUserName(userName);
            if (user != null)
            {
                return (T)user;
            }

            Console.WriteLine("User not found. Please register.");
            return Register() as T;
        }

        private User Register()
        {
            Console.WriteLine("This menu only creates CustomerUser. Please enter the following information to register.");
            Console.WriteLine("UserName : ");
            var userName = Console.ReadLine();
            Console.WriteLine("Email :");
            var email = Console.ReadLine();
            Console.WriteLine("Phone :");
            var phone = Console.ReadLine();

            var address = new Address("1790", "ankara", "cankaya", "06800", "gazi mah.", "89", "0", "fooo apartment");

            _userRepository.AddUser(new CustomerUser(userName, email, phone), new List<Address> { address});

            return _userRepository.GetUserByUserName(userName);
        }
    }
}
