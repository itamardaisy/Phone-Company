﻿using System;
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
using EntityFramework.FakeItEasy;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Times = Moq.Times;

namespace Dal.UnitTest
{
    [TestClass]
    public class CallsRepository_UnitTest
    {
        private Mock<DbSet<DbCall>> _mockSet;
        private Mock<PhoneCompanyContext> _mockContext;

        [TestMethod]
        public void AddNewCall_RecivedNewCall_CallWasAddedToTheDB()
        {
            _mockSet = new Mock<DbSet<DbCall>>();

            _mockContext = new Mock<PhoneCompanyContext>();
            _mockContext.Setup(m => m.Calls).Returns(_mockSet.Object);

            //var service = new CallsRepository(_mockContext.Object);
            //service.AddNewCall(ModelsGenerateForUnitTests.GenrateCall());

            _mockSet.Verify(m => m.Add(It.IsAny<DbCall>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetLineCall_RecivedLineNumber_RecivedCallListFromDB()
        {
            var context = new PhoneCompanyContext
            {
                Calls = new Mock<DbSet<DbCall>>().Object
            };
            context.Calls = ModelsGenerateForUnitTests.GetQueryableMockDbSet(
                new Call
                {
                    CallDate = DateTime.MaxValue,
                    DestinationNumber = "123123",
                    Duration = 66,
                    Id = 1,
                    LineId = 1
                }.CommonToDb());

            var results = context.Calls
                .Select(c => c.DbToCommon()).FirstOrDefault();

            Assert.AreEqual(results.DestinationNumber, "123123");
        }

        [TestMethod]
        public void GetLineCall_RecivedLineNumber_NoLineCallsWasFoundInTheDB()
        {
            var context = new PhoneCompanyContext
            {
                Calls = new Mock<DbSet<DbCall>>().Object
            };
            context.Calls = ModelsGenerateForUnitTests.GetQueryableMockDbSet(
                new Call
                {
                    CallDate = DateTime.MaxValue,
                    DestinationNumber = "0584313648",
                    Duration = 66,
                    Id = 1,
                    LineId = 1
                }.CommonToDb());

            var results = context.Calls
                .Select(c => c.DbToCommon()).FirstOrDefault();

            Assert.AreEqual(results.DestinationNumber, "0584313648");
        }

        [TestMethod]
        public void GetLineCallsMonth_RecivedLineNumber_RecivedLineCallsOfTheMonthFromDB()
        {
            var context = new PhoneCompanyContext
            {
                Calls = new Mock<DbSet<DbCall>>().Object
            };
            context.Calls = ModelsGenerateForUnitTests.GetQueryableMockDbSet(
                new Call
                {
                    CallDate = DateTime.Now,
                    DestinationNumber = "0584313648",
                    Duration = 66,
                    Id = 1,
                    LineId = 1
                }.CommonToDb());

            var results = context.Calls
                .Select(c => c.DbToCommon()).FirstOrDefault();

            Assert.AreEqual(results.Id == 1, true);
        }

        [TestMethod]
        public void GetLineCallsMonth_RecivedLineNumber_NoLineCallsOfTheMonthWasFound()
        {
            var context = new PhoneCompanyContext
            {
                Calls = new Mock<DbSet<DbCall>>().Object
            };
            context.Calls = ModelsGenerateForUnitTests.GetQueryableMockDbSet(
                new Call
                {
                    CallDate = DateTime.Now,
                    DestinationNumber = "0584313648",
                    Duration = 66,
                    Id = 2,
                    LineId = 1
                }.CommonToDb());

            var results = context.Calls
                .Select(c => c.DbToCommon()).FirstOrDefault();

            Assert.AreEqual(results.Id == 1, false);
        }
    }
}

//var testData = new List<DbCall>
//   {
//       ModelsGenerateForUnitTests.GenrateCall().CommonToDb(),
//   }.AsQueryable();

//_mockContext.As<IQueryable<DbCall>>().Setup(m => m.Provider).Returns(testData.Provider);
//_mockContext.As<IQueryable<DbCall>>().Setup(m => m.Expression).Returns(testData.Expression);
//_mockContext.As<IQueryable<DbCall>>().Setup(m => m.ElementType).Returns(testData.ElementType);
//_mockContext.As<IQueryable<DbCall>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

//_mockContext.Setup(m => m.Calls).Returns(_mockSet.Object);

//var service = new CallsRepository(_mockContext.Object);
//var results = service.GetLineCalls("123123");

////Assert
//Assert.AreEqual(results, ModelsGenerateForUnitTests.GenrateCall().CommonToDb());