using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.DataModels;
using Dal.Repositories;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dal.UnitTest
{
    [TestClass]
    public class CallsRepository_UnitTest
    {
        [TestMethod]
        public void AddNewCall_RecivedNewCall_CallWasAddedToTheDB()
        {
            //Arrange
            //var testData = new List<DbCall>
            //{
            //    new DbCall{Id = 1,CallDate= DateTime.Now,DestinationNumber = "123123",Duration = 43,LineId=4},
            //    new DbCall{Id = 2,CallDate= DateTime.Now,DestinationNumber = "123123",Duration = 43,LineId=3},
            //    new DbCall{Id = 3,CallDate= DateTime.Now,DestinationNumber = "123123",Duration = 43,LineId=2},
            //    new DbCall{Id = 4,CallDate= DateTime.Now,DestinationNumber = "123123",Duration = 43,LineId=1},
            //};
            //var set = A.Fake<DbSet<DbCall>>
            //    (c => c.Implements(typeof(IQueryable<DbCall>))
            //    .Implements(typeof(IDbAsyncEnumerable<DbCall>)))
            //    .AddRange(testData);

            //var context = A.Fake<PhoneCompanyContext>();
            //A.CallTo(() => context.Calls).ReturnsLazily(set);

            //var productService = new ProductService(context);

            //Act

            //Assert
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