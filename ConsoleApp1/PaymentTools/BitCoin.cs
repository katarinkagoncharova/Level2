using Cards.PaymentTools;

namespace Cards
{
    public class BitCoin: IPayment
    {
        private float _amount;
        public float Rate = 2f;

        public BitCoin(float sum) 
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
            if (sum > 0)
            {
                if ((_amount * Rate) >= sum)
                {
                    _amount -= sum / Rate;
                    return true;
                }
                return false;
            }
            throw new ArgumentException("Sum cannot be negative");
        }

        public bool TopUp(float sum)
        {
            if (sum > 0)
            {
                _amount += sum / Rate;
                return true;
            }
            throw new ArgumentException("Sum cannot be negative");         
        }

        public override string ToString()
        {
            return "BitCoin amount: " + _amount + "\n";
        }

        public override bool Equals(object? obj)
        {
            if (obj is BitCoin other)
            {
                return _amount == other.Amount() / Rate;
            }
            return false;
        }

        public  float Amount()
        {
            return _amount * Rate;
        }
    }

}
