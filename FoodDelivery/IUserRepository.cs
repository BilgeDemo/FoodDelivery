namespace FoodDelivery
{
    public interface IUserRepository
    {
        User GetUserById(string id);
        User GetUserByUserName(string userName);
        void AddUser(User user, List<Address> addresses);
        void RemoveUser(User user);
        Customer GetUserWithPermission(User user);

    }
}
