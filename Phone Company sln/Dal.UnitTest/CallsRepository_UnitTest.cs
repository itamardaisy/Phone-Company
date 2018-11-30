using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Common.Enums;
using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.DataModels;
using Dal.ModelConverters;
using Dal.Repositories;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Dal.UnitTest;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Dal.UnitTest
{
    [TestClass]
    public class CallsRepository_UnitTest
    {
 
        [TestMethod]
        public void AddNewCall_RecivedNewCall_CallWasAddedToTheDB()
        {
            // Arrange
            var testData = new List<DbCall>
            {
                ModelsGenerateForUnitTests.GenrateCall().CommonToDb(),
            };

            var newCall = new Call
                {CallDate = DateTime.Now, DestinationNumber = "121212", Duration = 123, LineId = 1};

            var set = A.Fake<DbSet<DbCall>>
                (c => c.Implements(typeof(IQueryable<DbCall>))
                .Implements(typeof(IDbAsyncEnumerable<DbCall>)))
                .SetupData(testData);

            var context = A.Fake<PhoneCompanyContext>();
            A.CallTo(() => context.Calls).Returns(set);

            var controller = new CallsRepository();

            //Act
            controller.AddNewCall(newCall);
            var results = controller.GetLineCalls("1232131");
            //Assert
            Assert.AreEqual(results,newCall);

        }

        [TestMethod]
        public void GetLineCall_RecivedLineNumber_RecivedCallListFromDB()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void GetLineCall_RecivedLineNumber_NoLineCallsWasFoundInTheDB()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void GetLineCallsMonth_RecivedLineNumber_RecivedLineCallsOfTheMonthFromDB()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void GetLineCallsMonth_RecivedLineNumber_NoLineCallsOfTheMonthWasFound()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}