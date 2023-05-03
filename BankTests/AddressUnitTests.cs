using Cards.Client;

namespace BankTests

{
    [TestClass]
    public class AddressUnitTests
    {
        [TestMethod]
        public void AddressToStringMethod()
        {
            Address address = new Address("Gomel", "Lesnaya", 5, 5);
            string expectedResult = "Address: Gomel, Lesnaya 5/5";
            string actualResult = address.ToString();
            Assert.AreEqual(expectedResult,actualResult);
        }

        [TestMethod]
        public void AddressEqualsTestPositive()
        {
            Address address = new Address("Gomel", "Lesnaya", 5, 5);
            Address address1 = new Address("Gomel", "Lesnaya", 5, 5);
            
            Assert.AreEqual(address, address1);
        }

        [TestMethod]
        [DataRow(" Gomel", "Lesnaya", 5, 5)]
        [DataRow("Gomel", "Lesnayaf", 5, 5)]
        [DataRow("Gomel", "Lesnaya", 54, 5)]
        [DataRow("Gomel", "Lesnaya", 5, 17)]
        public void AddressEqualsTestNegative(string city, string street, int house, int apartment)
        {
            Address address = new Address("Gomel", "Lesnaya", 5, 5);
            Address address1 = new Address(city, street, house, apartment);
            Assert.AreNotEqual(address, address1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CheckNullCity()
        {
            Address address = new Address(null, "Bogdanovicha", 0, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CheckNullStreet()
        {
            Address address = new Address("Gomel", null, 0, 7);
        }

        [TestMethod]
        [DataRow("Gomel", "Lesnaya", -5, 5)]
        [DataRow("Gomel", "Lesnayaf", 501, 5)]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckNumberHouseNoValid(string city, string street, int house, int apartment)
        {
            Address address = new Address(city, street, house, apartment);
        }

    }   
}