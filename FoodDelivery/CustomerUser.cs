namespace FoodDelivery
{
    public class CustomerUser : User
    {
        public CustomerUser(string Name, string Email, string Phone) : base(Name, Email, Phone)
        {
            userType = Permission.Customer;
        }

        public override Permission GetPermission()
        {
            return userType;
        }
    }
}
