using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
