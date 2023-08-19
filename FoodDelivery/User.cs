using System.Runtime.CompilerServices;

namespace FoodDelivery
{
    public abstract class User
    {
        public string Id { get; set; }
        public string Email { get; init; }
        public string Name { get; init; }
        public string Phone { get; init; }

        protected Permission userType;

        protected User(string Name, string Email, string Phone)
        {
            this.Email = Email;
            this.Name = Name;
            this.Phone = Phone;
            Id = Guid.NewGuid().ToString();
        }

         public abstract Permission GetPermission();
    }
}