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
        [Ignore("Method Isn't In GitHub")]
        public void CommonToDb_GetCall_Convert()
        {
            //Arrange
            var commonCall = new Call();
            var dbCall = new DbCall();
            //Act
            dbCall = commonCall.CommonToDb();
            //Assert
            Assert.AreEqual(dbCall, commonCall);
        }

        [TestMethod]
        [Ignore("Method Isn't In GitHub")]
        public void CommonToDb_GetClient_Convert()
        {
            //Arrange
            var commonClient = new Client();
            var dbClient = new DbClient();
            //Act
            dbClient = commonClient.CommonToDb();
            //Assert
            Assert.AreEqual(dbClient, commonClient);
        }

        [TestMethod]
        [Ignore("Method Isn't In GitHub")]
        public void CommonToDb_GetClientType_Convert()
        {
            //Arrange
            var commonClientType = new ClientType();
            var dbClientType = new DbClientType();
            //Act
            dbClientType = commonClientType.CommonToDb();
            //Assert
            Assert.AreEqual(dbClientType, commonClientType);
        }

        [TestMethod]
        [Ignore("Method Isn't In GitHub")]
        public void CommonToDb_GetLine_Convert()
        {
            //Arrange
            var commonLine = new Line();
            var dbLine = new DbLine();
            //Act
            dbLine = commonLine.CommonToDb();
            //Assert
            Assert.AreEqual(dbLine, commonLine);
        }

        [TestMethod]
        [Ignore("Method Isn't In GitHub")]
        public void CommonToDb_GetPackage_Convert()
        {
            //Arrange
            var commonPackage = new Package();
            var dbPackage = new DbPackage();
            //Act
            dbPackage = commonPackage.CommonToDb();
            //Assert
            Assert.AreEqual(dbPackage, commonPackage);
        }

        [TestMethod]
        [Ignore("Method Isn't In GitHub")]
        public void CommonToDb_GetPayment_Convert()
        {
            //Arrange
            var commonPayment = new Payment();
            var dbPayment = new DbPayment();
            //Act
            dbPayment = commonPayment.CommonToDb();
            //Assert
            Assert.AreEqual(dbPayment, commonPayment);
        }

        [TestMethod]
        [Ignore("Method Isn't In GitHub")]
        public void CommonToDb_GetSelectedNumber_Convert()
        {
            //Arrange
            var commonSelectedNumber = new SelectedNumber();
            var dbSelectedNumber = new DbSelectedNumber();
            //Act
            dbSelectedNumber = commonSelectedNumber.CommonToDb();
            //Assert
            Assert.AreEqual(dbSelectedNumber, commonSelectedNumber);
        }

        [TestMethod]
        [Ignore("Method Isn't In GitHub")]
        public void CommonToDb_GetSMS_Convert()
        {
            //Arrange
            var commonSMS = new SMS();
            var dbSMS = new DbSMS();
            //Act
            dbSMS = commonSMS.CommonToDb();
            //Assert
            Assert.AreEqual(dbSMS, commonSMS);
        }

        [TestMethod]
        [Ignore("Method Isn't In GitHub")]
        public void CommonToDb_GetUnsignClient_Convert()
        {
            //Arrange
            var commonUnsignClient = new UnsignClient();
            var dbUnsignClient = new DbUnsignClient();
            //Act
            dbUnsignClient = commonUnsignClient.CommonToDb();
            //Assert
            Assert.AreEqual(dbUnsignClient, commonUnsignClient);
        }

        [TestMethod]
        [Ignore("Method Isn't In GitHub")]
        public void CommonToDb_GetUser_Convert()
        {
            //Arrange
            var commonUser = new User();
            var dbUser = new DbUser();
            //Act
            dbUser = commonUser.CommonToDb();
            //Assert
            Assert.AreEqual(dbUser, commonUser);
        }
    }
}
