using AddressBook_DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenQuery_WhenRetrieve_ShouldReturnNumberOfRowsRetrieved()
        {
            int expectedResult = 12;
            AddressBookDatabase database = new AddressBookDatabase();
            int result = database.GetPersonDetailsfromDatabase();
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenQuery_whenUpdate_ShouldUpdateContactInDB()
        {
            bool expectedResult = true;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                Firstname = "Naveen",
                Lastname = "K",
                Address = "Shivamoga",
                City = "Shivamoga",
                State = "Karnataka",
                ZipCode = "123456",
                PhoneNumber = "1234567893",
                EmailId = "Naveen@gmail.com",
                AddressBookName = "Book2",
                Type = "Friends",
                AddedDate = new DateTime(2021, 11, 02)                           
            };
            bool result = database.UpdateContact(model);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenDate_ShouldReturnRecordsInAParticularPeriod()
        {
            bool expectedResult = true;
            AddressBookDatabase database = new AddressBookDatabase();
            bool result = database.RetriveContactsInPurticularPeriod();
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GivenQuery_WhenRetrieveByCityOrState_ShouldRetrievContactAndReturnNoOfCounts()
        {
            int expectedResult = 3;
            AddressBookDatabase database = new AddressBookDatabase();
            AddressBookModel model = new AddressBookModel()
            {
                State = "Karnataka"
            };
            int result = database.RetriveCountByCityOrState();
            Assert.AreEqual(expectedResult, result);
        }
    }
}
