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

            //Act

            //Assert
        }

        [TestMethod]
        public void UpdateClient_NewIfoOnTheUserWasRecived_UserUpdatedInTheDB()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void DeleteClient_RecivedClientID_TheClientWillDeletedAndAddedToTheUnSignTable()
        {

        }

        [TestMethod]
        public void GetClientByID_RecivedClientID_ClientWasRetrivedFromDB()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void GetClientByID_RecivedClientID_NoClientWasFound()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}