using Cards.Client;

namespace Cards.PaymentTools
{
    public abstract class PaymentCard : IPayment
    {
        private int _number;
        private int _cvv;
        public int Number
        {
            get
            {
                return _number;
            }
            init
            {
                if (value < 0 || value > 99999999)
                {
                    throw new ArgumentOutOfRangeException("invalid value");
                }
                _number = value;
            }
        }
        public ValidDate ValidDate { get; set; }
        public CardHolder CardHolder { get; set; }
        public int Cvv
        {
            get
            {
                return _cvv;
            }
            init
            {
                if (value < 0 || value > 999)
                {
                    throw new ArgumentOutOfRangeException("invalid value");
                }
                _cvv = value;
            }
        }

        public PaymentCard(int number, ValidDate validDate, CardHolder cardHolder, int cvv)
        {
            Number = number;
            ValidDate = validDate;
            CardHolder = cardHolder;
            Cvv = cvv;
        }

        public string GetCardInfo()
        {
            return $"Number: {Number}  DateValidity: {ValidDate.Month + "." + ValidDate.Year}  " +
                $"CardHolder: {CardHolder}  CVV: {Cvv}";
        }

        public override string ToString()
        {
            return "Number: " + Number + "\nValid date: " + ValidDate + "\nCard Holder: " + CardHolder + "\nCVV: " + Cvv;
        }

        public abstract bool MakePayment(float sum);

        public abstract bool TopUp(float sum);
        public abstract float Amount();
    }
}
