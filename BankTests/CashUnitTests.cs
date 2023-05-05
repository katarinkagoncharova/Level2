using Cards.PaymentTools;

namespace BankTests
{
    [TestClass]
    public class CashUnitTests
    {
        [TestMethod]
        public void CashToStringMethod()
        {
            Cash cash = new Cash(500);
            string expectedResult = "Cash amount: 500\n";
            string actualResult = cash.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CashEqualsTestPositive()
        {
            Cash cash = new Cash(500);
            Cash cash1 = new Cash(500);
            Assert.AreEqual(cash, cash1);
        }

        [TestMethod]
        public void CashEqualsTestNegative()
        {
            Cash cash = new Cash(500);
            Cash cash1 = new Cash(700);
            Assert.AreNotEqual(cash, cash1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckCashAmountLess0()
        {
            Cash cash = new Cash(-50);
        }

        [TestMethod]
        public void CashMakePaymentNegative()
        {
            Cash cash = new Cash(500);

            Assert.IsFalse(cash.MakePayment(700));
            Assert.AreEqual(cash.Amount(), 500);
        }

        [TestMethod]
        public void CashMakePaymentPositive()
        {
            Cash cash = new Cash(500);

            Assert.IsTrue(cash.MakePayment(200));
            Assert.AreEqual(cash.Amount(), 300);
        }

        [TestMethod]
        public void CheckCashTopUp()
        {
            Cash cash = new Cash(500);

            Assert.IsTrue(cash.TopUp(200));
            Assert.AreEqual(cash.Amount(), 700);
        }


    }
}
