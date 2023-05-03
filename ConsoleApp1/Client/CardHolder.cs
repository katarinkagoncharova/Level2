namespace Cards.Client
{
    public class CardHolder
    {
        private string _name;
        private string _surname;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Obj is null or empty");
                }
                else
                {
                    if (value.Length > 50)
                    {
                        throw new ArgumentOutOfRangeException("The number of characters is more than 50");
                    }
                    _name = value;
                }
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("Obj is null or empty");
                }
                else
                {
                    _surname = value;
                }
            }
        }


        public CardHolder(string name, string surname)

        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return Name + " " + Surname;
        }

        public override bool Equals(object? obj)
        {
            if (obj is CardHolder other)
            {
                return Name == other.Name && Surname == other.Surname;
            }
            return false;
        }

    }
}
