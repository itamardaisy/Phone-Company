using System;
using Common.Models;
using Dal.DataModels;
using Dal.ModelConverters;
using FakeItEasy;
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

            var fake = A.Fake<Call>(o => o.Wrapping(commonCall));
            //Act
            var results = dbCall.DbToCommon();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<Call>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void DbToCommon_GetClient_Convert()
        {
            //Arrange
            var commonClient = new Client();
            var dbClient = new DbClient();

            var fake = A.Fake<Client>(o => o.Wrapping(commonClient));
            //Act
            var results = dbClient.DbToCommon();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<Client>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void DbToCommon_GetClientType_Convert()
        {
            //Arrange
            var commonClientType = new ClientType();
            var dbClientType = new DbClientType();

            var fake = A.Fake<ClientType>(o => o.Wrapping(commonClientType));
            //Act
            var results = dbClientType.DbToCommon();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<ClientType>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void DbToCommon_GetLine_Convert()
        {
            //Arrange
            var commonLine = new Line();
            var dbLine = new DbLine();

            var fake = A.Fake<Line>(o => o.Wrapping(commonLine));
            //Act
            var results = dbLine.DbToCommon();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<Line>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void DbToCommon_GetPackage_Convert()
        {
            //Arrange
            var commonPackage = new Package();
            var dbPackage = new DbPackage();

            var fake = A.Fake<Package>(o => o.Wrapping(commonPackage));
            //Act
            var results = dbPackage.DbToCommon();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<Package>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void DbToCommon_GetPayment_Convert()
        {
            //Arrange
            var commonPayment = new Payment();
            var dbPayment = new DbPayment();

            var fake = A.Fake<Payment>(o => o.Wrapping(commonPayment));
            //Act
            var results = dbPayment.DbToCommon();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<Payment>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void DbToCommon_GetSelectedNumber_Convert()
        {
            //Arrange
            var commonSelectedNumber = new SelectedNumber();
            var dbSelectedNumber = new DbSelectedNumber();

            var fake = A.Fake<SelectedNumber>(o => o.Wrapping(commonSelectedNumber));
            //Act
            var results = dbSelectedNumber.DbToCommon();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<SelectedNumber>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void DbToCommon_GetSMS_Convert()
        {
            //Arrange
            var commonSMS = new SMS();
            var dbSMS = new DbSMS();

            var fake = A.Fake<SMS>(o => o.Wrapping(commonSMS));
            //Act
            var results = dbSMS.DbToCommon();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<SMS>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void DbToCommon_GetUnsignClient_Convert()
        {
            //Arrange
            var commonUnsignClient = new UnsignClient();
            var dbUnsignClient = new DbUnsignClient();

            var fake = A.Fake<UnsignClient>(o => o.Wrapping(commonUnsignClient));
            //Act
            var results = dbUnsignClient.DbToCommon();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<UnsignClient>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }

        [TestMethod]
        public void DbToCommon_GetUser_Convert()
        {
            //Arrange
            var commonUser = new User();
            var dbUser = new DbUser();

            var fake = A.Fake<User>(o => o.Wrapping(commonUser));
            //Act
            var results = dbUser.DbToCommon();
            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<User>(0);
                    return results.Id == other.Id;
                });
            //Assert
            Assert.AreEqual(fake, results);
        }
    }
}