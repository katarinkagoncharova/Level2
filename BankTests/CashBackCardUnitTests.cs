using Cards;
using Cards.Client;
using Cards.PaymentTools;

namespace BankTests
{
    [TestClass]
    public class CashBackCardUnitTests
    {
        [TestMethod]
        public void CashBackCardToStringMethod()
        {
            CashBackCard card = new CashBackCard(12345678, new ValidDate(10,2023),
                                new CardHolder("Ivan", "Smirnou"), 355, 0.05f, 2000);
            string expectedResult = "Cashback Card\nNumber: 12345678\nValid date: 10/2023\n" +
                "Card Holder: Ivan Smirnou\nCVV: 355\nCard amount : 2000\nCashback procent: 0,05\n";
            string actualResult = card.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        
        public void CashBackCardEqualsTestNegative()
        {
            CashBackCard card = new CashBackCard(12345678, new ValidDate(10, 2023),
                                new CardHolder("Ivan", "Smirnou"), 355, 0.05f, 2000);
            CashBackCard card1 = new CashBackCard(87654321, new ValidDate(5, 2023),
                                new CardHolder("Ivan", "Smirnou"), 355, 0.03f, 2500);
            Assert.AreNotEqual(card, card1);
        }

        public void CashBackCardEqualsTestPositive()
        {
            CashBackCard card = new CashBackCard(12345678, new ValidDate(10, 2023),
                                new CardHolder("Ivan", "Smirnou"), 355, 0.05f, 2000);
            CashBackCard card1 = new CashBackCard(87654321, new ValidDate(5, 2023),
                                new CardHolder("Ivan", "Smirnou"), 355, 0.03f, 2000);
            Assert.AreEqual(card, card1);
        }

        [TestMethod]
        public void CashBackCardMakePaymentNegative()
        {
            CashBackCard card = new CashBackCard(12345678, new ValidDate(10, 2023),
                               new CardHolder("Ivan", "Smirnou"), 355, 0.05f, 2000);
            Assert.IsFalse(card.MakePayment(2100));
            Assert.AreEqual(card.Amount(), 2000);
        }

        [TestMethod]
        public void CashBackCardMakePaymentPositive()
        {
            CashBackCard card = new CashBackCard(12345678, new ValidDate(10, 2023),
                               new CardHolder("Ivan", "Smirnou"), 355, 0.05f, 2000);
            Assert.IsTrue(card.MakePayment(2000));
            Assert.AreEqual(card.Amount(), 100);
        }

        [TestMethod]
        public void CheckCashBackCardTopUp()
        {
            CashBackCard card = new CashBackCard(12345678, new ValidDate(10, 2023),
                               new CardHolder("Ivan", "Smirnou"), 355, 0.05f, 2000);

            Assert.IsTrue(card.TopUp(200));
            Assert.AreEqual(card.Amount(), 2210);
        }
    }
}

