using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TooBuzyDataAccess;
using TooBuzyEntities;

namespace TooBuzyUnitTest.DataAccess
{
    [TestClass]
    public class CustomerUnitTest
    {
        private CustomerDb _CustomerDb = new CustomerDb();
        [TestMethod]
        public void CustomerCreateInDatabase()
        {
            //Arrange
            Customer testCustomer = new Customer
            {
                Name = "testCustomer",
                Type = "Pizza & Kebab",
                PhoneNo = 23568974,
                Address = "Jyllandsgade 5",
                ZipCode = 9000,
                Password = "lalala"

            };
            //Act
            bool isCreated = _CustomerDb.Create(testCustomer);
            //Assert
            Assert.IsTrue(isCreated);
        }
        [TestMethod]
        public void CustomerCreateInDatabaseFail()
        {
            //Arrange
            Customer testCustomer = new Customer
            {
                Name = "asdf",
                Type = "Pizza & Kebab",
                PhoneNo = 23568974,
                Address = "Jyllandsgade 5",
                ZipCode = 9000,
                Password = "lalala"

            };
            //Act
            bool isCreated = _CustomerDb.Create(testCustomer);
            //Assert
            Assert.IsFalse(isCreated);
        }
        [TestMethod]
        public void CustomerUpdateInDatabase()
        {
            //Arrange
            Customer testCustomer = new Customer
            {
                Name = "asdf",
                Type = "Pizzaa & Kebab",
                PhoneNo = 23568974,
                Address = "Ribegade 5",
                ZipCode = 9000,
                Password = "lalalaa"
            };
            //Act
            bool isUpdated = _CustomerDb.Update(testCustomer);
            //Assert
            Assert.IsTrue(isUpdated);
        }
        [TestMethod]
        public void CustomerDeletedInDatabase()
        {
            //Arrange
            int Id = 8;
            //Act
            bool isDeleted = _CustomerDb.Delete(Id);
            //Assert
            Assert.IsTrue(isDeleted);
        }
    }
}
