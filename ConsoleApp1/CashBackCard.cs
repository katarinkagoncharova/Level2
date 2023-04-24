
namespace Cards
{
    public class CashBackCard: PaymentCard
    {
        public float CashBackProcent { get; set; }
        public float CashBackCardAmount { get; set;}

        public CashBackCard(int number, ValidDate validDate, CardHolder cardHolder, int cvv, float cashBackProcent, float cashBackCardAmount)
            : base(number, validDate, cardHolder, cvv) 
        {
            CashBackProcent = cashBackProcent;
            CashBackCardAmount = cashBackCardAmount;
        }

        public override bool MakePayment(float sum)
        {
            if (CashBackCardAmount >= sum)
            {
                CashBackCardAmount -= sum;
                CashBackCardAmount += (sum * CashBackCardAmount); 
                return true;
            }
            return false;
        }

        public override bool TopUp(float sum)
        {
            CashBackCardAmount += sum;
            CashBackCardAmount += (sum * CashBackCardAmount);
            return true;
        }

        public override string ToString()
        {
            return ("Cashback Card\n" + base.ToString() + "\nCard amount : " + CashBackCardAmount + "\nCashback procent: " + CashBackProcent + "\n");
        }

        public override bool Equals(object? obj)
        {
            if (obj is CashBackCard other) 
            {
                return (base.CardHolder == other.CardHolder &&
                       CashBackCardAmount == other.CashBackCardAmount);
            }
            return false;
        }

        public override float Amount()
        {
            return CashBackCardAmount;
        }
    }
}
