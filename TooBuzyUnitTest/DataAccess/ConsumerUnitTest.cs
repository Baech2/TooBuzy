using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TooBuzyBusinessLogic;
using TooBuzyDataAccess;
using TooBuzyEntities;

namespace TooBuzyUnitTest.DataAccess
{
    [TestClass]
    public class ConsumerUnitTest
    {
        private ConsumerDb _consumerDb = new ConsumerDb();
        [TestMethod]
        public void ConsumerCreateInDatabase()
        {
            //Arrange
            Consumer testConsumer = new Consumer
            {
                Name = "lalalallalalalala",
                PhoneNo = 98653698,
                Password = "nytpassword"
            };
            //Act
            bool isCreated = _consumerDb.Create(testConsumer);
            //Assert
            Assert.IsTrue(isCreated);
        }
        [TestMethod]
        public void ConsumerCreateInDatabaseFail()
        {
            //Arrange
            Consumer testConsumer = new Consumer
            {
                Name = "lalalallalalalala",
                PhoneNo = 98653698,
                Password = "nytpassword"
            };
            //Act
            bool isCreated = _consumerDb.Create(testConsumer);
            //Assert
            Assert.IsFalse(isCreated);
        }
        [TestMethod]
        public void ConsumerUpdateInDatabase()
        {
            //Arrange
            Consumer testConsumer = new Consumer
            {
              Name = "lululala",
              PhoneNo = 98784512,
              Password = "updatepw"
            };
            //Act
            bool isUpdated = _consumerDb.Update(testConsumer);
            //Assert
            Assert.IsTrue(isUpdated);
        }
        [TestMethod]
        public void ConsumerDeletedInDatabase()
        {
            //Arrange
            int Id = 8;
            //Act
            bool isDeleted = _consumerDb.Delete(Id);
            //Assert
            Assert.IsTrue(isDeleted);
        }
    }
}
