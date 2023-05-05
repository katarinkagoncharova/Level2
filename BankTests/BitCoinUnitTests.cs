using Cards;
using Cards.Client;
using Cards.PaymentTools;

namespace BankTests

{
    [TestClass]
    public class BitCoinUnitTests
    {
        [TestMethod]
        public void BitCoinToStringMethod()
        {
            BitCoin bitCoin = new BitCoin(500);
            string expectedResult = "BitCoin amount: 500\n";
            string actualResult = bitCoin.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void BitCoinEqualsTestPositive()
        {
            BitCoin bitCoin = new BitCoin(500);
            BitCoin bitCoin1 = new BitCoin(500);
            Assert.AreEqual(bitCoin, bitCoin1);
        }

        [TestMethod]
        public void BitCoinEqualsTestNegative()
        {
            BitCoin bitCoin = new BitCoin(500);
            BitCoin bitCoin1 = new BitCoin(100);
            Assert.AreNotEqual(bitCoin, bitCoin1);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckBitCoinAmountLess0()
        {
            BitCoin bitCoin = new BitCoin(-50);
        }

        [TestMethod]
        public void BitCoinMakePaymentNegative()
        {
            BitCoin bitCoin = new BitCoin(500);
            Assert.IsFalse(bitCoin.MakePayment(1200));
            Assert.AreEqual(bitCoin.Amount(), 1000);
        }

        [TestMethod]
        public void BitCoinMakePaymentPositive()
        {
            BitCoin bitCoin = new BitCoin(500);
            Assert.IsTrue(bitCoin.MakePayment(900));
            Assert.AreEqual(bitCoin.Amount(), 100);
        }

        [TestMethod]
        public void CheckBitCoinTopUp()
        {
            BitCoin bitCoin = new BitCoin(500);

            Assert.IsTrue(bitCoin.TopUp(200));
            Assert.AreEqual(bitCoin.Amount(), 1200);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckNegativeAmound()
        {
            BitCoin bitCoin = new BitCoin(-500);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MakePaymentSumNegative()
        {
            BitCoin bitCoin = new BitCoin(500);
            bitCoin.MakePayment(-1200);
        }


    }
}
