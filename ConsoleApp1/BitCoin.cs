namespace Cards
{
    public class BitCoin: IPayment
    {
        public float Amount { get; set; }
        public float Rate = 2f;

        public BitCoin(float amount) 
        {
            Amount = amount;
        }

        public bool MakePayment(float sum)
        {
            if ((Amount * Rate) >= sum) 
            {
                Amount -= sum / Rate;
                return true;
            }
            return false;
        }

        public bool TopUp(float sum)
        {
            Amount += sum / Rate;
            return true;
        }
        public override string ToString()
        {
            return "BitCoin amount: " + Amount + "\n";
        }

        public override bool Equals(object? obj)
        {
            if (obj is BitCoin other)
            {
                return Amount == other.Amount;
            }
            return false;
        }

        float IPayment.Amount()
        {
            return Amount * Rate;
        }
    }

}
