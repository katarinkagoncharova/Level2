namespace Cards
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }

        public Address(string city, string street, int houseNumber, int apartmentNumber)
        {
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
        }

        public override string ToString()
        {
            return "Address: "+ City + ", " + Street + " " + HouseNumber + "/" + ApartmentNumber;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Address address) 
            {
                return ((City == address.City) &&
                       (Street == address.Street) &&
                       (HouseNumber == address.HouseNumber) &&
                       (ApartmentNumber == address.ApartmentNumber));
            }
            return false;
        }

    }
}
 