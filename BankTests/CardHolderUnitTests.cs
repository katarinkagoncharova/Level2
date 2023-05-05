using Cards.Client;



namespace BankTests
{
    [TestClass]
    public class CardHolderUnitTests
    {
        [TestMethod]
        public void CardHolderToStringMethod()
        {
            CardHolder cardHolder = new CardHolder("Ivan", "Petrov");
            string expectedResult = "Ivan Petrov";
            string actualResult = cardHolder.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CardHolderEqualsTestPositive()
        {
            CardHolder cardHolder = new CardHolder("Ivan", "Petrov");
            CardHolder cardHolder1 = new CardHolder("Ivan", "Petrov");

            Assert.AreEqual(cardHolder, cardHolder1);
        }

        [TestMethod]
        [DataRow("Ivan", "Ivanov")]
        [DataRow(" Ivan", "Petrov")]
        [DataRow("Petr", "Lom")]
        public void AddressEqualsTestNegative(string name, string surname)
        {
            CardHolder cardHolder = new CardHolder("Ivan", "Petrov");
            CardHolder cardHolder1 = new CardHolder(name, surname);
            Assert.AreNotEqual(cardHolder, cardHolder1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CheckNullName()
        {
            CardHolder cardHolder = new CardHolder(null, "Petrov");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CheckNullSurname()
        {
            CardHolder cardHolder = new CardHolder("Ivan", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckNameMore20Char()
        {
            CardHolder cardHolder = new CardHolder("Ivannnnnnnnnnnnnnnnnnn", "Petrov");
        }

        
    }
}
