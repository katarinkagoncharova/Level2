namespace Cards
{
    public class Cash:IPayment
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

        public Cash(float sum) 
        {
            Amount = sum;
        }

        public bool MakePayment(float sum)
        {
            if (Amount >= sum) 
            {
                Amount -= sum;
                return true;
            }
            return false;
        }

        public bool TopUp(float sum)
        {
            Amount += sum;
            return true;
        }


        public override string ToString()
        {
            return "Cash amount: " + Amount + "\n";
        }

        float IPayment.Amount()
        {
            return Amount;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Cash other) 
            {
                return Amount == other.Amount;
            } 
            return false;
        }
    }
}
