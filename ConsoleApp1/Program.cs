
using Cards.Client;
using Cards.Comparers;
using Cards.PaymentTools;

namespace Cards
{
    internal class Program
    {
        static void Main(string[] args)

        {
            var card1 = new DebetCard(12345678, new(02, 2025), new("Irina", "Petrova"), 155, 0.01f, 2000);
           
            var card2 = new CreditCard(20351247, new(03, 2026), new("Irina", "Petrova"), 325, 0.01f, 7000);

            var card3 = new CashBackCard(52364178, new(07, 2024), new("Irina", "Petrova"), 123, 0.02f, 1800);

            var card4 = new DebetCard(12224568, new(12, 2023), new("Oleg", "Kot"), 213, 0.02f, 1200);

            var card5 = new CreditCard(98562314, new(10, 2026), new("Oleg", "Kot"), 254, 0.05f, 7500);

            var card6 = new CreditCard(47851236, new(02, 2024), new("Maxim", "Ivanov"), 541, 0.05f, 3200);

            //1000   2000 7000  1800  3000   total 14800
            var client1 = new BankClient(new("Irina", "Petrova"), new("Minsk", "Ternistaya", 5, 5), "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, card2, card3, new BitCoin(1500f) });

            // 2000   1200   7500  400    total 11100
            var client2 = new BankClient(new("Oleg", "Kot"), new("Brest", "Gomelskaya", 10, 3), "+375445896532",
                new List<IPayment> { new Cash(2000f), card4, card5, new BitCoin(200f) });

            // 9000  3200  4400 total 16600
            var client3 = new BankClient(new("Maxim", "Ivanov"), new("Gomel", "Truda", 47, 38), "+3753322211444",
                new List<IPayment> { new Cash(9000f), card6, new BitCoin(2200f)});

            var client4 = new BankClient(new("Maxim", "Ivanov"), new("Gomel", "Pushkina", 10, 501), "+3753322211444",
                new List<IPayment> { new Cash(9000f), card6, new BitCoin(2200f) });

            //client1.MakePayment(1200f);
            //client1.MakePayment(2000f);
            //client1.MakePayment(7000);
            //client1.MakePayment(3000f);

            //client1.PrintPaymentMeans();

            var BankClients = new List<BankClient> {client1, client2, client3};

            BankClients.Sort();
            BankClients.Sort(new AddressComparer()); 
            BankClients.Sort(new CountCardsComparer());
            BankClients.Sort(new TotalAmountComparer());
            BankClients.Sort(new MaxAmountMeanComparer());

            var res1 = BankClients.OrderBy(x => x.CardHolder.Name);
            var res2 = BankClients.OrderBy(x => x.Address.City);
            var res3 = BankClients.OrderBy(x => x.CountCards());
            var res4 = BankClients.OrderBy(x => x.TotalAmount());
            var res5 = BankClients.OrderBy(x => x.MaxAmount());
            var res6 = client1.PaymentMeans.Select(x => x as DebetCard).Where(x => x != null); 
            var res7 = client2.PaymentMeans.Select(x => x.Amount()).Sum();
            var res8 = BankClients
                .Where(x => x.PaymentMeans.OfType<BitCoin>().Any())
                .OrderByDescending(x => x.TotalAmount());

        }
    }
}