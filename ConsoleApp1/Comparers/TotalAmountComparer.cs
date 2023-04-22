namespace Cards.Comparers
{
    internal class TotalAmountComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            return x.TotalAmount().CompareTo(y.TotalAmount());
        }
    }
}
