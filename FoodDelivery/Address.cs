namespace FoodDelivery
{
    public class Address
    {
        public string Id { get; set; }
        public string Street { get; init; }
        public string City {get; init;}
        public string State {get; init;}
        public string Zip {get; init;}
        public string District {get; init;}
        public string Building {get; init;}
        public string Floor {get; init;}
        public string Apartment {get; init;}
        
        public Address(string street, string city, string state, string zip, string district, string building, string floor, string apartment)
        {
            Street = street;
            City = city;
            State = state;
            Zip = zip;
            District = district;
            Building = building;
            Floor = floor;
            Apartment = apartment;
            Id = Guid.NewGuid().ToString();
        }
    }
}