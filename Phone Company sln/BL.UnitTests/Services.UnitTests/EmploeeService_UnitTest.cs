using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using BL.Services;
using Common.Models;
using Dal.DataModels;
using Dal.ModelConverters;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BL.UnitTests.Services_UnitTests
{
    [TestClass]
    public class EmploeeService_UnitTest
    {
        [TestMethod]
        public void AddNewClient_RecivedNewClient_ClientWasMovedToTheRepositoryFunction()
        {
            //Arrange
            var newClientDB = new DbClient
            {
                Id = 1,
                Adress = "blablabla",
                CallToCenter = 69,
                ClientTypeId = 1,
                ContactNumber = "124214214",
                LastName = "boo",
                Name = "itamar",
                SignDate = DateTime.Now,
                UserId = 1
            };
            var newClient = new Client
            {
                Id = 1,
                Adress = "blablabla",
                CallToCenter = 69,
                ClientTypeId = 1,
                ContactNumber = "124214214",
                LastName = "boo",
                Name = "itamar",
                SignDate = DateTime.Now,
                UserId = 1
            };
            var employeeService = new EmploeeService();

            var fake = A.Fake<Client>(o => o.Wrapping(newClient));

            var results = newClient.CommonToDb();

            A.CallTo(() => fake.Equals(A<object>._)).ReturnsLazily(
                call =>
                {
                    var other = call.GetArgument<Client>(0);
                    return results.Id == other.Id;
                });

            var set = A.Fake<DbSet<Client>>
                (c => c.Implements(typeof(IQueryable<Client>))
                .Implements(typeof(IDbAsyncEnumerable<Client>)))
                .Add(results.DbToCommon());
            //Act
            employeeService.AddNewClient(results.DbToCommon());
            //Assert
        }
    }
}