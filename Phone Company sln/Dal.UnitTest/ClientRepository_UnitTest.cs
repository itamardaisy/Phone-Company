using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dal.UnitTest
{
    [TestClass]
    public class ClientRepository_UnitTest
    {
        [TestMethod]
        public void AddNewClient_RecivedClient_UserWasAddedToTheDB()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }

        [TestMethod]
        public void UpdateClient_NewIfoOnTheUserWasRecived_UserUpdatedInTheDB()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
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