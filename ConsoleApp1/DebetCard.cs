namespace Cards
{
    public class DebetCard: PaymentCard
    {
        public float DepositProcent { get; set; }
        public float DepositAmount { get; set; }

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
    }
}
