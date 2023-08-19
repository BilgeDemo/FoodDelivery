namespace FoodDelivery
{
    public class RestaurantOwner : User
    {
        public RestaurantOwner(string Name, string Email, string Phone) : base(Name, Email, Phone)
        {
            userType = Permission.RestaurantOwner;

        }

        public override Permission GetPermission()
        {
            return userType;
        }
    }
}
