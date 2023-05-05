using Cards.Client;
using Cards.PaymentTools;
using Cards;
using Cards.Comparers;


namespace BankTests
{
    [TestClass]
    public class ComparersUnitTests
    {
        [TestMethod]
        public void CheckClientAddressComparer()
        {
            
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), new BitCoin(500f) });

            BankClient client2 = new BankClient(new CardHolder("Anna", "Morskaya"),
                new Address("Gomel", "Mira", 5, 5),
                "+375252544114",
                new List<IPayment> { new Cash(1000f), new BitCoin(5000f) });

            BankClient client3 = new BankClient(new CardHolder("Helena", "Buzova"),
                new Address("Omsk", "Mira", 5, 5),
                "+375252544114",
                new List<IPayment> { new Cash(1000f), new BitCoin(5000f) });

            List<BankClient> BankClients = new List<BankClient> { client1, client2, client3 };
            BankClients.Sort(new AddressComparer());


            Assert.AreEqual(BankClients[0].Address.City, "Gomel");
            Assert.AreEqual(BankClients[1].Address.City, "Minsk");
            Assert.AreEqual(BankClients[2].Address.City, "Omsk");
        }

        [TestMethod]
        public void CheckClientCountCardComparer()
        {
            PaymentCard card1 = new DebetCard(12345678,
                               new ValidDate(02, 2025),
                               new CardHolder("  ", "  "),
                               155, 0.01f, 3000);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("  ", "  "),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("  ", "  "),
                               123, 0.02f, 1500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1,new BitCoin(500f) });

            BankClient client2 = new BankClient(new CardHolder("Anna", "Morskaya"),
                new Address("Gomel", "Mira", 5, 5),
                "+375252544114",
                new List<IPayment> { new Cash(1000f), card2, card3, new BitCoin(5000f) });

            BankClient client3 = new BankClient(new CardHolder("Helena", "Buzova"),
                new Address("Omsk", "Mira", 5, 5),
                "+375252544114",
                new List<IPayment> { new Cash(1000f), new BitCoin(5000f) });

            List<BankClient> BankClients = new List<BankClient> { client1, client2, client3 };
            BankClients.Sort(new CountCardsComparer());


            Assert.AreEqual(BankClients[0].CountCards(), 0);
            Assert.AreEqual(BankClients[1].CountCards(), 1);
            Assert.AreEqual(BankClients[2].CountCards(), 2);
        }

        [TestMethod]
        public void CheckClientMaxAmountMeanComparer()
        {
            PaymentCard card1 = new DebetCard(12345678,
                               new ValidDate(02, 2025),
                               new CardHolder("  ", "  "),
                               155, 0.01f, 3000);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("  ", "  "),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("  ", "  "),
                               123, 0.02f, 1500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, new BitCoin(500f) });

            BankClient client2 = new BankClient(new CardHolder("Anna", "Morskaya"),
                new Address("Gomel", "Mira", 5, 5),
                "+375252544114",
                new List<IPayment> { new Cash(1000f), card2, card3, new BitCoin(5000f) });

            BankClient client3 = new BankClient(new CardHolder("Helena", "Buzova"),
                new Address("Omsk", "Mira", 5, 5),
                "+375252544114",
                new List<IPayment> { new Cash(1000f), new BitCoin(5500f) });

            List<BankClient> BankClients = new List<BankClient> { client1, client2, client3 };
            BankClients.Sort(new MaxAmountMeanComparer());

            Assert.AreEqual(BankClients[0].MaxAmount(), 3000);
            Assert.AreEqual(BankClients[1].MaxAmount(), 10000);
            Assert.AreEqual(BankClients[2].MaxAmount(), 11000);
        }

        [TestMethod]
        public void CheckClientTotalAmountMeanComparer()
        {
            PaymentCard card1 = new DebetCard(12345678,
                               new ValidDate(02, 2025),
                               new CardHolder("  ", "  "),
                               155, 0.01f, 3000);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("  ", "  "),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("  ", "  "),
                               123, 0.02f, 1500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, new BitCoin(500f) });

            BankClient client2 = new BankClient(new CardHolder("Anna", "Morskaya"),
                new Address("Gomel", "Mira", 5, 5),
                "+375252544114",
                new List<IPayment> { new Cash(1000f), card2, card3, new BitCoin(5000f) });

            BankClient client3 = new BankClient(new CardHolder("Helena", "Buzova"),
                new Address("Omsk", "Mira", 5, 5),
                "+375252544114",
                new List<IPayment> { new Cash(1000f), new BitCoin(5500f) });

            List<BankClient> BankClients = new List<BankClient> { client1, client2, client3 };
            BankClients.Sort(new TotalAmountComparer());

            Assert.AreEqual(BankClients[0].TotalAmount(), 5000);
            Assert.AreEqual(BankClients[1].TotalAmount(), 12000);
            Assert.AreEqual(BankClients[2].TotalAmount(), 19500);
        }


    }
}
