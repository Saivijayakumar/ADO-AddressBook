using ADO_AddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ADO_AddressBookTesting
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepo repo;
        AddressBookData data;
        [TestInitialize]
        public void setup()
        {
            repo = new AddressBookRepo();
            data = new AddressBookData();
        }
        [TestMethod]
        public void DisplayingAndReturnCount()
        {
            int expected = 4;
            int actual = repo.RetriveAllData();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenUpdatedValuesAndReturnResult()
        {
            data.firstname = "Ram";
            data.lastName = "K";
            data.phone = 123456789;
            string expected="Updated";
            string actual = repo.UpdateContactPhoneNumber(data);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RetrivePersonsAtParticularPeriodAndReturnCount()
        {
            int expected = 2;
            int actual = repo.RetriveBaseONPerticularPeriod();
            Assert.AreEqual(expected, actual);
        }
    }
}
