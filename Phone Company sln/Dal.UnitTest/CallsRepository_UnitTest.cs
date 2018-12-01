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

            var service = new CallsRepository(_mockContext.Object);
            service.AddNewCall(ModelsGenerateForUnitTests.GenrateCall());

            _mockSet.Verify(m => m.Add(It.IsAny<DbCall>()),Times.Once);
            _mockContext.Verify(m => m.SaveChanges(),Times.Once);
        }

        [TestMethod]
        public void GetLineCall_RecivedLineNumber_RecivedCallListFromDB()
        {
            var testData = new List<DbCall>
               {
                   ModelsGenerateForUnitTests.GenrateCall().CommonToDb(),
               }.AsQueryable();

 

            _mockContext = new Mock<PhoneCompanyContext>();
            _mockContext.Setup(m => m.Calls).Returns(_mockSet.Object);

            var service = new CallsRepository(_mockContext.Object);
            var results = service.GetLineCalls("1231212");
            
            //Assert
            Assert.AreEqual(results, ModelsGenerateForUnitTests.GenrateCall().CommonToDb());
        }

        [TestMethod]
        public void GetLineCall_RecivedLineNumber_NoLineCallsWasFoundInTheDB()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }

        [TestMethod]
        public void GetLineCallsMonth_RecivedLineNumber_RecivedLineCallsOfTheMonthFromDB()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }

        [TestMethod]
        public void GetLineCallsMonth_RecivedLineNumber_NoLineCallsOfTheMonthWasFound()
        {
            //Arrange
            throw new NotImplementedException();
            //Act

            //Assert
        }
    }
}