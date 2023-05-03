using Cards.Client;

namespace Cards.Comparers
{
    public class MaxAmountMeanComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }
            return x.MaxAmount().CompareTo(y.MaxAmount());
        }
    }
}
