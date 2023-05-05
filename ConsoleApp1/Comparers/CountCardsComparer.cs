using Cards.Client;

namespace Cards.Comparers
{
    public class CountCardsComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }
            return x.CountCards() - y.CountCards();
        }
    }
}
