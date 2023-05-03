namespace Cards.Client
{
    public class Address
    {
        private string _city;
        private string _street;
        private int _houseNumber;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Obj is null or empty");
                }
                _city = value;
            }
        }
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Obj is null or empty");
                }
                _street = value;
            }
        }
        public int HouseNumber
        {
            get
            {
                return _houseNumber;
            }
            set
            {
                if (value > 500 || value <= 0)
                {
                    throw new ArgumentException("Invalid house number");
                }
                _houseNumber = value;
            }
        }
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
            return "Address: " + City + ", " + Street + " " + HouseNumber + "/" + ApartmentNumber;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Address address)
            {
                return City == address.City &&
                       Street == address.Street &&
                       HouseNumber == address.HouseNumber &&
                       ApartmentNumber == address.ApartmentNumber;
            }
            return false;
        }

    }
}
