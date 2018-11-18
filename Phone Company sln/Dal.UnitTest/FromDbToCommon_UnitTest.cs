using System;
using Common.Models;
using Dal.DataModels;
using Dal.ModelConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dal.UnitTest
{
    [TestClass]
    public class FromDbToCommon_UnitTest
    {
        [TestMethod]
        public void DbToCommon_GetCall_Convert()
        {
            //Arrange
            var commonCall = new Call();
            var dbCall = new DbCall();
            //Act
            var results = dbCall.DbToCommon();
            //Assert
            Assert.AreEqual(commonCall, results);
        }

        [TestMethod]
        public void DbToCommon_GetClient_Convert()
        {
            //Arrange
            var commonClient = new Client();
            var dbClient = new DbClient();
            //Act
            var results = dbClient.DbToCommon();
            //Assert
            Assert.AreEqual(commonClient, results);
        }

        [TestMethod]
        public void DbToCommon_GetClientType_Convert()
        {
            //Arrange
            var commonClientType = new ClientType();
            var dbClientType = new DbClientType();
            //Act
            var results = dbClientType.DbToCommon();
            //Assert
            Assert.AreEqual(commonClientType, results);
        }

        [TestMethod]
        public void DbToCommon_GetLine_Convert()
        {
            //Arrange
            var commonLine = new Line();
            var dbLine = new DbLine();
            //Act
            var results = dbLine.DbToCommon();
            //Assert
            Assert.AreEqual(commonLine, results);
        }

        [TestMethod]
        public void DbToCommon_GetPackage_Convert()
        {
            //Arrange
            var commonPackage = new Package();
            var dbPackage = new DbPackage();
            //Act
            var results = dbPackage.DbToCommon();
            //Assert
            Assert.AreEqual(commonPackage, results);
        }

        [TestMethod]
        public void DbToCommon_GetPayment_Convert()
        {
            //Arrange
            var commonPayment = new Payment();
            var dbPayment = new DbPayment();
            //Act
            var results = dbPayment.DbToCommon();
            //Assert
            Assert.AreEqual(commonPayment, results);
        }

        [TestMethod]
        public void DbToCommon_GetSelectedNumber_Convert()
        {
            //Arrange
            var commonSelectedNumber = new SelectedNumber();
            var dbSelectedNumber = new DbSelectedNumber();
            //Act
            var results = dbSelectedNumber.DbToCommon();
            //Assert
            Assert.AreEqual(commonSelectedNumber, results);
        }

        [TestMethod]
        public void DbToCommon_GetSMS_Convert()
        {
            //Arrange
            var commonSMS = new SMS();
            var dbSMS = new DbSMS();
            //Act
            var results = dbSMS.DbToCommon();
            //Assert
            Assert.AreEqual(commonSMS, results);
        }

        [TestMethod]
        public void DbToCommon_GetUnsignClient_Convert()
        {
            //Arrange
            var commonUnsignClient = new UnsignClient();
            var dbUnsignClient = new DbUnsignClient();
            //Act
            var results = dbUnsignClient.DbToCommon();
            //Assert
            Assert.AreEqual(commonUnsignClient, results);
        }

        [TestMethod]
        public void DbToCommon_GetUser_Convert()
        {
            //Arrange
            var commonUser = new User();
            var dbUser = new DbUser();
            //Act
            var results = dbUser.DbToCommon();
            //Assert
            Assert.AreEqual(commonUser, results);
        }
    }
}