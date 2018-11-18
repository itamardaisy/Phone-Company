using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dal.UnitTest
{
    [TestClass]
    public class ClientTypeRepository_UnitTest
    {
        [TestMethod]
        public void GetClientByName_RecivedClientName_ClientTypeWasRecivedFromDB()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void GetClientByName_RecivedClientName_NoClientTypeFound()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void AddNewClient_RecivedClientType_ClientTypeAddedToTheDB
()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void DeleteType_RecivedClientTypeName_ClientTypeWasDeleted
()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void GetAllTypes_RecivedCallToFunction_RecivedAllClientTypesFromDB()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void UpdateMinutePrice_RecivedTypeToUpdateAndNewPrice_MinutePriceWasUpdatedInDB()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void UpdateSMSPrice_RecivedTypeToUpdateAndNewPrice_SMSPriceWasUpdatedInDB()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}