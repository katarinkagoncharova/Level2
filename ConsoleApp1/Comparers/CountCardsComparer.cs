namespace Cards.Comparers
{
    internal class CountCardsComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            return x.CountCards() - y.CountCards();
        }
    }
}
