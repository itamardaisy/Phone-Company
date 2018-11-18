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

            //Act

            //Assert
        }

        [TestMethod]
        public void DeletePackage_RecivedPackageName_PackageWasDeletedFromDBAndSendTrue()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void DeletePackage_RecivedPackageName_PackageWasNotFoundAndSendFalse()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void GetPackageByName_RecivedPackageName_FoundPackageAndSentIt()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void GetPackageByName_RecivedPackageName_PackageWasNotFound()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void UpdatePackage_RecivedPackageNameAndTheUpdateDitails_PackageWasUpdatedAndSendTrue()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void UpdatePackage_RecivedPackageNameAndTheUpdateDitails_PackageWasNotRemoveFromDBAndSendFlase()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}