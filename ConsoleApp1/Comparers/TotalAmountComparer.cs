using Cards.Client;

namespace Cards.Comparers
{
    internal class TotalAmountComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            if (x == null || y == null)
            {
                throw new ArgumentNullException();
            }
            return x.TotalAmount().CompareTo(y.TotalAmount());
        }
    }
}
