namespace Cards
{
    public class DebetCard: PaymentCard
    {
        private float _depositAmount;
        private float _depositProcent;
        public float DepositProcent
        {
            get 
            {
                return _depositProcent;
            }
            set 
            {
                if (value < 0) 
                {
                    throw new ArgumentException("Deposit procent cannot be negative");
                }
                _depositAmount = value;
            }
        }
        public float DepositAmount 
        {
            get 
            {
                return _depositAmount;
            }
            set
            { 
                if (value < 0) 
                {
                    throw new ArgumentException("Amount cannot be negative");
                }
                _depositAmount = value;
            }
        }

        public DebetCard(int number, ValidDate validDate, CardHolder cardHolder, int cvv, float depositProcent, float depositAmount)
            : base(number, validDate, cardHolder, cvv) 
        {
            DepositProcent = depositProcent;
            DepositAmount = depositAmount;
        }
        public override string ToString()
        {
            return ("Debet Card\n" + base.ToString() + "\nDeposit amount: " + DepositAmount + "\nDeposit procent: " + DepositProcent + "\n");
        }

        public override bool Equals(object? obj)
        {
            if (obj is DebetCard other)
            {
                return (base.CardHolder == other.CardHolder &&
                       DepositAmount == other.DepositAmount);
            }
            return false;
        }

        public override bool MakePayment(float sum)
        {
            if (sum <= DepositAmount)
            {
                DepositAmount -= sum;
                return true;
            }
            return false;
        }

        public override bool TopUp(float sum)
        {
            DepositAmount += sum;
            return true;
        }

        public override float Amount()
        {
            return DepositAmount;
        }
    }
}
