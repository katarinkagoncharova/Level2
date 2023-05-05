using Cards;
using Cards.Client;
using Cards.PaymentTools;

namespace BankTests
{
    [TestClass]
    public class BankClientUnitTests
    {
        [TestMethod]
        public void MakePaymentByCash()
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
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, card2, card3, new BitCoin(1500f) });


            Assert.IsTrue(client1.MakePayment(900));
            Assert.AreEqual(client1.TotalAmount(), 13900);
        }

        [TestMethod]
        public void MakePaymentByCashBackCard()
        {
            PaymentCard card1 = new DebetCard(12345678,
                                new ValidDate(02, 2025),
                                new CardHolder("Irina", "Petrova"),
                                155, 0.01f, 2500);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("Irina", "Petrova"),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("Irina", "Petrova"),
                               123, 0.02f, 2500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, card2, card3, new BitCoin(1500f) });


            Assert.IsTrue(client1.MakePayment(2200));
            Assert.AreEqual(client1.TotalAmount(), 13844);
        }

        [TestMethod]
        public void MakePaymentByDebetCard()
        {
            PaymentCard card1 = new DebetCard(12345678,
                                new ValidDate(02, 2025),
                                new CardHolder("Irina", "Petrova"),
                                155, 0.01f, 3000);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("Irina", "Petrova"),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("Irina", "Petrova"),
                               123, 0.02f, 1500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, card2, card3, new BitCoin(1500f) });


            Assert.IsTrue(client1.MakePayment(2000));
            Assert.AreEqual(client1.TotalAmount(), 13500);
        }
        [TestMethod]
        public void MakePaymentByCreditCard()
        {
            PaymentCard card1 = new DebetCard(12345678,
                                new ValidDate(02, 2025),
                                new CardHolder("Irina", "Petrova"),
                                155, 0.01f, 3000);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("Irina", "Petrova"),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("Irina", "Petrova"),
                               123, 0.02f, 1500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, card2, card3, new BitCoin(1500f) });


            Assert.IsTrue(client1.MakePayment(4000));
            Assert.AreEqual(client1.TotalAmount(), 11460);
        }

        [TestMethod]
        public void MakePaymentByBitCoin()
        {
            PaymentCard card1 = new DebetCard(12345678,
                                new ValidDate(02, 2025),
                                new CardHolder("Irina", "Petrova"),
                                155, 0.01f, 3000);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("Irina", "Petrova"),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("Irina", "Petrova"),
                               123, 0.02f, 1500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, card2, card3, new BitCoin(5000f) });


            Assert.IsTrue(client1.MakePayment(9000));
            Assert.AreEqual(client1.TotalAmount(), 13500);
        }

        [TestMethod]
        public void MakePaymentNegative()
        {
            PaymentCard card1 = new DebetCard(12345678,
                                new ValidDate(02, 2025),
                                new CardHolder("Irina", "Petrova"),
                                155, 0.01f, 3000);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("Irina", "Petrova"),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("Irina", "Petrova"),
                               123, 0.02f, 1500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, card2, card3, new BitCoin(5000f) });


            Assert.IsFalse(client1.MakePayment(11000));
            Assert.AreEqual(client1.TotalAmount(), 22500);
        }
        [TestMethod]
        public void CheckCountCards()
        {
            PaymentCard card1 = new DebetCard(12345678,
                                new ValidDate(02, 2025),
                                new CardHolder("Irina", "Petrova"),
                                155, 0.01f, 3000);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("Irina", "Petrova"),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("Irina", "Petrova"),
                               123, 0.02f, 1500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, card2, card3, new BitCoin(5000f) });

            Assert.AreEqual(client1.CountCards(), 3);
        }

        [TestMethod]
        public void CheckClientMaxAmount()
        {
            PaymentCard card1 = new DebetCard(12345678,
                                new ValidDate(02, 2025),
                                new CardHolder("Irina", "Petrova"),
                                155, 0.01f, 3000);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("Irina", "Petrova"),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("Irina", "Petrova"),
                               123, 0.02f, 1500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, card2, card3, new BitCoin(500f) });

            Assert.AreEqual(client1.MaxAmount(), 7000);
        }

        [TestMethod]
        public void CheckClientCompareTo()
        {
            PaymentCard card1 = new DebetCard(12345678,
                                new ValidDate(02, 2025),
                                new CardHolder("Irina", "Petrova"),
                                155, 0.01f, 3000);

            PaymentCard card2 = new CreditCard(20351247,
                                new ValidDate(03, 2026),
                                new CardHolder("Irina", "Petrova"),
                                325, 0.01f, 7000);

            PaymentCard card3 = new CashBackCard(52364178,
                               new ValidDate(07, 2024),
                               new CardHolder("Irina", "Petrova"),
                               123, 0.02f, 1500);
            BankClient client1 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Ternistaya", 5, 5),
                "+3752536987",
                new List<IPayment> { new Cash(1000f), card1, card2, new BitCoin(500f) });

            BankClient client2 = new BankClient(new CardHolder("Irina", "Petrova"),
                new Address("Minsk", "Mira", 5, 5),
                "+375252544114",
                new List<IPayment> { new Cash(1000f), card3, new BitCoin(5000f) });

            Assert.AreEqual(client1.CompareTo(client2), 0);
        }


    }
}
