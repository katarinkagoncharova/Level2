namespace Cards
{
    public abstract class PaymentCard: IPayment
    {
        public int Number;
        public ValidDate ValidDate;
        public CardHolder CardHolder;
        public int Cvv;

        public PaymentCard(int number, ValidDate validDate, CardHolder cardHolder, int cvv)
        {
            Number = number;
            ValidDate = validDate;
            CardHolder = cardHolder;
            Cvv= cvv;
        }

        public string GetCardInfo()
        {
            return $"Number: {Number}  DateValidity: {ValidDate.Month +"."+ ValidDate.Year}  " +
                $"CardHolder: {CardHolder}  CVV: {Cvv}";
        }

        public override string ToString()
        {
            return ("Number: " + Number + "\nValid date: " + ValidDate + "\nCard Holder: " + CardHolder + "\nCVV: " + Cvv);
        }

        public abstract bool MakePayment(float sum);

        public abstract bool TopUp(float sum);

    }
}
