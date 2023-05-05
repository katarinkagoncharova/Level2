using Cards.Client;

namespace BankTests
{
    [TestClass]
    public class ValidDateUnitTests
    {
        [TestMethod]
        public void ValidDateToStringMethod()
        {
            ValidDate date = new ValidDate(12, 2023);
            string expectedResult = "12/2023";
            string actualResult = date.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ValidDateEqualsTestPositive()
        {
            ValidDate date = new ValidDate(12, 2023);
            ValidDate date1 = new ValidDate(12, 2023);
            Assert.AreEqual(date, date1);
        }

        
        [TestMethod]
        [DataRow(10, 2023)]
        [DataRow(12, 2024)]
        [DataRow(10, 2024)]
        public void ValidDateEqualsTestNegative(int month, int year)
        {
            ValidDate date = new ValidDate(12, 2023);
            ValidDate date1 = new ValidDate(month, year);
            Assert.AreNotEqual(date, date1);
        }

        [TestMethod]
        [DataRow(-5, 2023)]
        [DataRow(13, 2024)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckMonthOutOfRange(int month, int year)
        {
            ValidDate date = new ValidDate(month, year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckYearLess0()
        {
            ValidDate date = new ValidDate(12, -2023);
        }

    }
}
