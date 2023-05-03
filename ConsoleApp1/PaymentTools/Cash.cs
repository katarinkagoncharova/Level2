namespace Cards.PaymentTools
{
    public class Cash : IPayment
    {
        private float _amount;
        
        public Cash(float sum)
        {
            if (sum > 0)
            {
                _amount = sum;
            }
            else
            {
                throw new ArgumentException("Sum cannot be negative");
            }
        }

        public bool MakePayment(float sum)
        {
            if (_amount >= sum)
            {
                _amount -= sum;
                return true;
            }
            return false;
        }

        public bool TopUp(float sum)
        {
            if (sum > 0)
            {
                _amount += sum;
                return true;
            }
            throw new ArgumentException("Sum cannot be negative");
        }


        public override string ToString()
        {
            return "Cash amount: " + Amount() + "\n";
        }

        public float Amount()
        {
            return _amount;
        }


        public override bool Equals(object? obj)
        {
            if (obj is Cash other)
            {
                return _amount == other.Amount();
            }
            return false;
        }
    }
}
