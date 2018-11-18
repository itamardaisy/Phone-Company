using Common.Models;
using Dal.DataModels;
using Dal.ModelConverters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.UnitTest
{
    [TestClass]
    public class FromCommonToDb_UnitTest
    {
        [TestMethod]
        public void CommonToDb_GetCall_Convert()
        {
            //Arrange
            var commonCall = new Call();
            var dbCall = new DbCall();
            //Act
            var results = commonCall.CommonToDb();
            //Assert
            Assert.AreEqual(dbCall, results);
        }

        [TestMethod]
        public void CommonToDb_GetClient_Convert()
        {
            //Arrange
            var commonClient = new Client();
            var dbClient = new DbClient();
            //Act
            var results = commonClient.CommonToDb();
            //Assert
            Assert.AreEqual(dbClient, results);
        }

        [TestMethod]
        public void CommonToDb_GetClientType_Convert()
        {
            //Arrange
            var commonClientType = new ClientType();
            var dbClientType = new DbClientType();
            //Act
            var results = commonClientType.CommonToDb();
            //Assert
            Assert.AreEqual(dbClientType, results);
        }

        [TestMethod]
        public void CommonToDb_GetLine_Convert()
        {
            //Arrange
            var commonLine = new Line();
            var dbLine = new DbLine();
            //Act
            var results = commonLine.CommonToDb();
            //Assert
            Assert.AreEqual(dbLine, results);
        }

        [TestMethod]
        public void CommonToDb_GetPackage_Convert()
        {
            //Arrange
            var commonPackage = new Package();
            var dbPackage = new DbPackage();
            //Act
            var results = commonPackage.CommonToDb();
            //Assert
            Assert.AreEqual(dbPackage, results);
        }

        [TestMethod]
        public void CommonToDb_GetPayment_Convert()
        {
            //Arrange
            var commonPayment = new Payment();
            var dbPayment = new DbPayment();
            //Act
            var results = commonPayment.CommonToDb();
            //Assert
            Assert.AreEqual(dbPayment, results);
        }

        [TestMethod]
        public void CommonToDb_GetSelectedNumber_Convert()
        {
            //Arrange
            var commonSelectedNumber = new SelectedNumber();
            var dbSelectedNumber = new DbSelectedNumber();
            //Act
            var results = commonSelectedNumber.CommonToDb();
            //Assert
            Assert.AreEqual(dbSelectedNumber, results);
        }

        [TestMethod]
        public void CommonToDb_GetSMS_Convert()
        {
            //Arrange
            var commonSMS = new SMS();
            var dbSMS = new DbSMS();
            //Act
            var results = commonSMS.CommonToDb();
            //Assert
            Assert.AreEqual(dbSMS, results);
        }

        [TestMethod]
        public void CommonToDb_GetUnsignClient_Convert()
        {
            //Arrange
            var commonUnsignClient = new UnsignClient();
            var dbUnsignClient = new DbUnsignClient();
            //Act
            var results = commonUnsignClient.CommonToDb();
            //Assert
            Assert.AreEqual(dbUnsignClient, results);
        }

        [TestMethod]
        public void CommonToDb_GetUser_Convert()
        {
            //Arrange
            var commonUser = new User();
            var dbUser = new DbUser();
            //Act
            var results = commonUser.CommonToDb();
            //Assert
            Assert.AreEqual(dbUser, results);
        }
    }
}