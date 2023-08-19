namespace FoodDelivery
{
    public class Restaurant : IMenuDisplayable
    {
        public string Name { get; init; }
        private User _owner;
        public string Id { get; set; }

        private Address _address;

        private List<MenuItem> _menu;

        public Restaurant(string name, User owner)
        {
            Name = name;
            Id = Guid.NewGuid().ToString();
            _owner = owner;
            _menu = new List<MenuItem>();

            if(_owner.GetPermission() != Permission.RestaurantOwner)
            {
                throw new Exception("Only restaurant owners can create restaurants.");
            }
        }

        public List<MenuItem> GetMenu()
        {
            return _menu;
        }

        public void AddAddress(Address address)
        {
            _address = address;
        }

        internal void AddMenuItem(MenuItem menuItem)
        {
            _menu.Add(menuItem);
        }

        public MenuItem GetMenuItemWithId(string id)
        {
            var menuItem = _menu.Find(m => m.Id == id);

            if(menuItem == null)
            {
                Console.WriteLine("Menu item not found.");
            }   
            return menuItem;
        }
    }
}
