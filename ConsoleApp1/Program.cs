
using Cards.Comparers;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)

        {
            PaymentCard card1 = new DebetCard(12345678, 
                                new ValidDate(02, 2025), 
                                new CardHolder("Irina", "Petrova"),
                                155, 0.01f, 2000);
           
            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("Irina", "Petrova"),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("Irina", "Petrova"),
                               123, 0.02f, 1800);

            PaymentCard card4 = new DebetCard(12224568,
                               new ValidDate(12, 2023),
                               new CardHolder("Oleg", "Kot"),
                               213, 0.02f, 1200);

            PaymentCard card5 = new CreditCard(98562314,
                               new ValidDate(10, 2026),
                               new CardHolder("Oleg", "Kot"),
                               254, 0.05f, 7500);


            PaymentCard card6 = new CreditCard(47851236,
                               new ValidDate(02, 2024),
                               new CardHolder("Maxim", "Ivanov"),
                               541, 0.05f, 3200);

            //1000   2000 7000  1800  3000   total 14800
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                 new Address("Minsk", "Ternistaya", 5, 5),
                 "+3752536987",
                 new List<IPayment> { new Cash(1000f), card1, card2, card3, new BitCoin(1500f) });

            // 2000   1200   7500  400    total 11100
            BankClient client2 = new BankClient(new CardHolder("Oleg", "Kot"),
                 new Address("Brest", "Gomelskaya", 10, 3),
                 "+375445896532",
                 new List<IPayment> { new Cash(2000f), card4, card5, new BitCoin(200f) });

            // 9000  3200  4400 total 16600
            BankClient client3 = new BankClient(new CardHolder("Maxim", "Ivanov"),
                             new Address("Gomel", "Truda", 47, 38),
                             "+3753322211444",
                             new List<IPayment> { new Cash(9000f), card6, new BitCoin(2200f)});

            BankClient client4 = new BankClient(new CardHolder("Maxim", "Ivanov"),
                            new Address("Gomel", "Pushkina", 10, 501),
                            "+3753322211444",
                            new List<IPayment> { new Cash(9000f), card6, new BitCoin(2200f) });

            bool a = client3.Equals(client4);

            //client1.MakePayment(1200f);
            //client1.MakePayment(2000f);
            //client1.MakePayment(7000);
            //client1.MakePayment(3000f);

            //client1.PrintPaymentMeans();

            Console.WriteLine(client1);

            List<BankClient> BankClients = new List<BankClient> {client1, client2, client3};

            BankClients.Sort();
            BankClients.Sort(new AddressComparer());
            BankClients.Sort(new CountCardsComparer());
            BankClients.Sort(new TotalAmountComparer());
            BankClients.Sort(new MaxAmountMeanComparer());

            var res1 = BankClients.OrderBy(x => x.CardHolder.Name).ToList();
            var res2 = BankClients.OrderBy(x => x.Address.City).ToList();
            var res3 = BankClients.OrderBy(x => x.CountCards()).ToList();
            var res4 = BankClients.OrderBy(x => x.TotalAmount()).ToList();
            var res5 = BankClients.OrderBy(x => x.MaxAmount()).ToList();
            var res6 = client1.PaymentMeans.Select(x => x as DebetCard).Where(x => x != null).ToList(); 
            var res7 = client2.PaymentMeans.Select(x => x.Amount()).Sum();
            var res8 = BankClients.Where(x => x.PaymentMeans.OfType<BitCoin>().Any()).ToList().OrderByDescending(x => x.TotalAmount()).ToList();

        }
    }
}