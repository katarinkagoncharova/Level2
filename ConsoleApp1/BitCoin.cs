namespace Cards
{
    public class BitCoin: IPayment
    {
        private float _amount;
        public float Amount
        {
            get 
            {
                return _amount;
            }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be negative");
                }
                _amount = value;
            }                
        }

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
