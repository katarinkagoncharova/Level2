namespace Cards
{
    internal class AddressComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            return x.Address.City.CompareTo(y.Address.City);
        }
    }
}
