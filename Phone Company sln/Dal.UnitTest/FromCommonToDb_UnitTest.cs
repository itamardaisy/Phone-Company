using Common.Models;
using Dal.DataModels;
using Dal.ModelConverters;
using FakeItEasy;
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

            var fake = A.Fake<DbCall>(o => o.Wrapping(dbCall));
            //Act
            var results = commonCall.CommonToDb();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<DbCall>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void CommonToDb_GetClient_Convert()
        {
            //Arrange
            var commonClient = new Client();
            var dbClient = new DbClient();

            var fake = A.Fake<DbClient>(o => o.Wrapping(dbClient));
            //Act
            var results = commonClient.CommonToDb();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<DbClient>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void CommonToDb_GetClientType_Convert()
        {
            //Arrange
            var commonClientType = new ClientType();
            var dbClientType = new DbClientType();

            var fake = A.Fake<DbClientType>(o => o.Wrapping(dbClientType));
            //Act
            var results = commonClientType.CommonToDb();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<DbClientType>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void CommonToDb_GetLine_Convert()
        {
            //Arrange
            var commonLine = new Line();
            var dbLine = new DbLine();

            var fake = A.Fake<DbLine>(o => o.Wrapping(dbLine));
            //Act
            var results = commonLine.CommonToDb();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
               call =>
                 {
                     var other = call.GetArgument<DbLine>(0);
                     return results.Id == other.Id;
                 });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void CommonToDb_GetPackage_Convert()
        {
            //Arrange
            var commonPackage = new Package();
            var dbPackage = new DbPackage();

            var fake = A.Fake<DbPackage>(o => o.Wrapping(dbPackage));
            //Act
            var results = commonPackage.CommonToDb();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                  {
                      var other = call.GetArgument<DbPackage>(0);
                      return results.Id == other.Id;
                  });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void CommonToDb_GetPayment_Convert()
        {
            //Arrange
            var commonPayment = new Payment();
            var dbPayment = new DbPayment();

            var fake = A.Fake<DbPayment>(o => o.Wrapping(dbPayment));
            //Act
            var results = commonPayment.CommonToDb();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<DbPayment>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void CommonToDb_GetSelectedNumber_Convert()
        {
            //Arrange
            var commonSelectedNumber = new SelectedNumber();
            var dbSelectedNumber = new DbSelectedNumber();

            var fake = A.Fake<DbSelectedNumber>(o => o.Wrapping(dbSelectedNumber));
            //Act
            var results = commonSelectedNumber.CommonToDb();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<DbSelectedNumber>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void CommonToDb_GetSMS_Convert()
        {
            //Arrange
            var commonSMS = new SMS();
            var dbSMS = new DbSMS();

            var fake = A.Fake<DbSMS>(o => o.Wrapping(dbSMS));
            //Act
            var results = commonSMS.CommonToDb();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
               call =>
               {
                   var other = call.GetArgument<DbSMS>(0);
                   return results.Id == other.Id;
               });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void CommonToDb_GetUnsignClient_Convert()
        {
            //Arrange
            var commonUnsignClient = new UnsignClient();
            var dbUnsignClient = new DbUnsignClient();

            var fake = A.Fake<DbUnsignClient>(o => o.Wrapping(dbUnsignClient));
            //Act
            var results = commonUnsignClient.CommonToDb();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
               call =>
               {
                   var other = call.GetArgument<DbUnsignClient>(0);
                   return results.Id == other.Id;
               });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void CommonToDb_GetUser_Convert()
        {
            //Arrange
            var commonUser = new User();
            var dbUser = new DbUser();

            var fake = A.Fake<DbUser>(o => o.Wrapping(dbUser));
            //Act
            var results = commonUser.CommonToDb();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<DbUser>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }
    }
}