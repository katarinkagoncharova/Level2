namespace Cards.Comparers
{
    internal class MaxAmountMeanComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            return x.MaxAmount().CompareTo(y.MaxAmount());
        }
    }
}
