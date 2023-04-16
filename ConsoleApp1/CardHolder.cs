using System.IO;

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

    }
}
