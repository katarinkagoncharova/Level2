namespace Cards
{
    public class BankClient: IComparable<BankClient>
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

        public int CompareTo(BankClient? other)
        {
            return this.CardHolder.Name.CompareTo(other.CardHolder.Name);
        }

        public int CountCards()
        {
           int count = 0;
            foreach (var n in PaymentMeans)
            {
                if (n is PaymentCard)
                {
                    count++;
                }
            }  
            return count;
        }

        public float TotalAmount()
        {
            float totalAmount = 0;
            foreach (var n in PaymentMeans)
            {
                totalAmount += n.Amount();
            }
            return totalAmount;
        }

        public float MaxAmount()
        {
            float maxAmount = 0;
            foreach (var n in PaymentMeans)
            {
                if (n.Amount() > maxAmount) 
                {
                    maxAmount = n.Amount();
                }
            }
            return maxAmount;
        }

    }
     



}
