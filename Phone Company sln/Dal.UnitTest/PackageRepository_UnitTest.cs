using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dal.UnitTest
{
    [TestClass]
    public class PackageRepository_UnitTest
    {
        [TestMethod]
        public void AddNewPackage_RecivedNewPackage_PackageWasAddedToTheDBAndWasSent()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }

        [TestMethod]
        public void DeletePackage_RecivedPackageName_PackageWasDeletedFromDBAndSendTrue()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }

        [TestMethod]
        public void DeletePackage_RecivedPackageName_PackageWasNotFoundAndSendFalse()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }

        [TestMethod]
        public void GetPackageByName_RecivedPackageName_FoundPackageAndSentIt()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }

        [TestMethod]
        public void GetPackageByName_RecivedPackageName_PackageWasNotFound()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }

        [TestMethod]
        public void UpdatePackage_RecivedPackageNameAndTheUpdateDitails_PackageWasUpdatedAndSendTrue()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }

        [TestMethod]
        public void UpdatePackage_RecivedPackageNameAndTheUpdateDitails_PackageWasNotRemoveFromDBAndSendFlase()
        {
            //Arrange
            throw new NotImplementedException();

            //Act

            //Assert
        }
    }
}