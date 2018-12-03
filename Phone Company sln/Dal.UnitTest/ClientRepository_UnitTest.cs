using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.DataModels;
using Dal.ModelConverters;
using Dal.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace Dal.UnitTest
{
    [TestClass]
    public class ClientRepository_UnitTest
    {
        private Mock<DbSet<DbClient>> _mockSet;
        private Mock<PhoneCompanyContext> _mockContext;

        [TestMethod]
        public void AddNewClient_RecivedClient_UserWasAddedToTheDB()
        {
            _mockSet = new Mock<DbSet<DbClient>>();

            _mockContext = new Mock<PhoneCompanyContext>();
            _mockContext.Setup(m => m.Clients).Returns(_mockSet.Object);

            var service = new ClientRepository(_mockContext.Object);
            service.AddNewClient(ModelsGenerateForUnitTests.GenrateClient());

            _mockSet.Verify(m => m.Add(It.IsAny<DbClient>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void UpdateClient_NewIfoOnTheUserWasRecived_UserUpdatedInTheDB()
        {
            var ClientData = new List<Client>
            {
                new Client
                {
                    Adress = "sadasd",CallToCenter = 1,ClientTypeId = 1,ContactNumber = "4561465",
                    Id = 1,LastName = "asdasd",Name = "asdasd",SignDate = DateTime.Now,UserId = 1
                },
                new Client
                {
                    Adress = "sadasd",CallToCenter = 1212,ClientTypeId = 2,ContactNumber = "121212",
                    Id = 2,LastName = "asdasd",Name = "asdasd",SignDate = DateTime.Now,UserId = 1
                },
                new Client
                {
                    Adress = "sadasd",CallToCenter = 1,ClientTypeId = 1,ContactNumber = "323232",
                    Id = 3,LastName = "asdasd",Name = "asdasd",SignDate = DateTime.Now,UserId = 2
                }
            };

            var repository = new Mock<IClientRepository>();

            //var context = new PhoneCompanyContext
            //{
            //    Clients = new Mock<DbSet<DbClient>>().Object
            //};

            //var clientToChange = new Client
            //{
            //    Id = 1,
            //    Adress = "Hello, 12",
            //    CallToCenter = 11,
            //    ClientTypeId = 1,
            //    ContactNumber = "0584313648",
            //    LastName = "adsdasd",
            //    Name = "sadasd",
            //    SignDate = DateTime.Today,
            //    UserId = 1
            //};

            //_mockSet = new Mock<DbSet<DbClient>>();

            //_mockContext = new Mock<PhoneCompanyContext>();

            //context.Clients = ModelsGenerateForUnitTests.GetQueryableMockDbSet(clientToChange.CommonToDb());

            ////var clientToChange = context.Clients
            ////    .Select(c => c.DbToCommon()).FirstOrDefault();

            //_mockContext.Setup(m => m.Clients).Returns(_mockSet.Object);

            //var service = new ClientRepository(_mockContext.Object);

            //service.UpdateClient(new Client
            //{
            //    Id = 1,
            //    Adress = "Hello, 12",
            //    CallToCenter = 11,
            //    ClientTypeId = 1,
            //    ContactNumber = "0584313648",
            //    LastName = "aaaaaa",
            //    Name = "sadasd",
            //    SignDate = DateTime.Today,
            //    UserId = 1
            //});

            //Assert.AreEqual(clientToChange.LastName == "aaaaaa", true);
        }

        [TestMethod]
        public void DeleteClient_RecivedClientID_TheClientWillDeletedAndAddedToTheUnSignTable()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void GetClientByID_RecivedClientID_ClientWasRetrivedFromDB()
        {
            throw new NotImplementedException();
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void GetClientByID_RecivedClientID_NoClientWasFound()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }
    }
}