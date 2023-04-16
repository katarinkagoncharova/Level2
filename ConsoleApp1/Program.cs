namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)

        {
            PaymentCard card1 = new DebetCard(12345678, 
                                new ValidDate(02, 2025), 
                                new CardHolder("Petrova", "Irina"),
                                155, 0.01f, 2000);
           
            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("Petrova", "Irina"),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("Petrova", "Irina"),
                               123, 0.02f, 1800);

            PaymentCard card4 = new DebetCard(12224568,
                               new ValidDate(12, 2023),
                               new CardHolder("Kot", "Oleg"),
                               213, 0.02f, 1200);

            PaymentCard card5 = new CreditCard(98562314,
                               new ValidDate(10, 2026),
                               new CardHolder("Kot", "Oleg"),
                               254, 0.05f, 7500);


            PaymentCard card6 = new CreditCard(47851236,
                               new ValidDate(02, 2024),
                               new CardHolder("Kot", "Oleg"),
                               541, 0.05f, 3200);


            BankClient client1 = new BankClient(new CardHolder("Petrova", "Irina"),
                 new Address("Minsk", "Ternistaya", 5, 5),
                 "+3752536987",
                 new List<IPayment> { new Cash(1500f), card1, card2, card3, new BitCoin(1500f) });

            client1.MakePayment(1200f);
            client1.MakePayment(2000f);
            client1.MakePayment(7000);
            client1.MakePayment(3000f);

            client1.PrintPaymentMeans();
            
                       

            Console.WriteLine("Hello!");

                      
        }
    }
}