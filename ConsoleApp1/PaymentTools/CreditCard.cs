using Cards.Client;

namespace Cards.PaymentTools
{
    public class CreditCard : PaymentCard
    {
        public float CreditProcent { get; set; }
        public float CreditLimit { get; set; }
 
        public CreditCard(int number, ValidDate validDate, CardHolder cardHolder, int cvv, float creditProcent, float creditLimit)
            : base(number, validDate, cardHolder, cvv)
        {
            CreditProcent = creditProcent;
            CreditLimit = creditLimit;
        }

        public override string ToString()
        {
            return "Credit Card\n" + base.ToString() + "\nCredit limit: " + CreditLimit + "\nCredit procent: " + CreditProcent + "\n";
        }

        public override bool Equals(object? obj)
        {
            if (obj is CreditCard other)
            {
                return CardHolder == other.CardHolder &&
                       CreditLimit == other.CreditLimit;
            }
            return false;
        }

        public override bool MakePayment(float sum)
        {
            if (sum <= CreditLimit)
            {
                CreditLimit -= sum * CreditProcent + sum;
                return true;
            }
            return false;
        }

        public override bool TopUp(float sum)
        {
            CreditLimit += sum;
            return true;
        }

        public override float Amount()
        {
            return CreditLimit;
        }
    }
}
