namespace Cards
{
    public class CardHolder
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        

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
