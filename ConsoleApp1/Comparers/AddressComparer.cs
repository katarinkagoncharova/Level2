using Cards.Client;

namespace Cards
{
    public class AddressComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            if (x == null || y == null) 
            {
                throw new ArgumentNullException();
            }
            return x.Address.City.CompareTo(y.Address.City);
        }
    }
}
