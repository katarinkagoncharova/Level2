namespace Cards
{
    public class BankClient
    {
        public CardHolder CardHolder { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; } 
        public List<IPayment> PaymentMeans { get; set; }

        public BankClient(CardHolder cardHolder, Address address, string phoneNumber, List<IPayment> paymentMeans)
        {
            CardHolder = cardHolder;
            Address = address;
            PhoneNumber = phoneNumber;
            PaymentMeans = paymentMeans;
        }

        private bool SpecialPay(List<IPayment> resList, float sum) 
        {
            foreach (IPayment item in resList) 
            {
                if (item.MakePayment(sum) == true) 
                {
                    return true;
                }
            }
            return false;
        }


        public bool MakePayment(float sum) 
        {
            if (SpecialPay(PaymentMeans.Where(x => x is Cash).ToList(), sum)) 
            {
                return true;
            }

            if (SpecialPay(PaymentMeans.Where(x => x is CashBackCard).ToList(), sum))
            {
                return true;
            }

            if (SpecialPay(PaymentMeans.Where(x => x is DebetCard).ToList(), sum))
            {
                return true;
            }

            if (SpecialPay(PaymentMeans.Where(x => x is CreditCard).ToList(), sum))
            {
                return true;
            }

            if (SpecialPay(PaymentMeans.Where(x => x is BitCoin).ToList(), sum))
            {
                return true;
            }

            return false;         
        }

        public void PrintPaymentMeans()
        {
            foreach (IPayment payment in PaymentMeans)
            {
                Console.WriteLine(payment.ToString());
            }
        }
    }




}
