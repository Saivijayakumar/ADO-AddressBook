using ADO_AddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ADO_AddressBookTesting
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepo repo;
        [TestInitialize]
        public void setup()
        {
            repo = new AddressBookRepo();
        }
        [TestMethod]
        public void DisplayingAndReturnCount()
        {
            int expected = 4;
            int actual = repo.RetriveAllData();
            Assert.AreEqual(expected, actual);
        }
    }
}
