using ADO_AddressBook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ADO_AddressBookTesting
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookRepo repo;
        AddressBookData data;
        AddressBookThreads threads;
        [TestInitialize]
        public void setup()
        {
            repo = new AddressBookRepo();
            data = new AddressBookData();
            threads = new AddressBookThreads();
        }
        [TestMethod]
        public void DisplayingAndReturnCount()
        {
            int expected = 7;
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
        [TestMethod]
        public void GetingNumberOfContactBaseONSate()
        {
            List<int> actual = repo.GetingTheCountOfContactsUsingState();
            int[] temp = { 1, 2 };
            var expected = new List<int>(temp);
            CollectionAssert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void InsertdataUsingTransactionAndReturnCount()
        {
            data.addressBookId = 1;
            data.firstname = "Traine 1";
            data.lastName = "ASP";
            data.address = "Company address";
            data.city = "Ramapuram";
            data.state = "TS";
            data.Zipcode = 54434;
            data.phone = 987654321;
            data.emailId = "traine@gamil.com";
            data.personTypeId = 1;
            string expected = "Updated";
            string actual = repo.InsertPersonThroughTransaction(data);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CallingAMethodToDisplayAndTransverToListWeGetCountHere()
        {
            int expected = 7;
            int actual = threads.TransverDataToListUsingThreads();
            Assert.AreEqual(expected, actual);
        }
    }
}
