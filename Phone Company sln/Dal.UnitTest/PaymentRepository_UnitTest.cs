using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dal.UnitTest
{
    [TestClass]
    public class PaymentRepository_UnitTest
    {
        [TestMethod]
        public void GetByMonth_RecivedDate_ReceviedPaymentByTheMothAndSentIt
   ()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void GetByMonth_RecivedDate_PaymentWasNotFound
()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void AddPaymeny_ReceviedNewPayment_PaymentWasAddedToTheDBAndSentTrue
()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod]
        public void AddPaymeny_ReceviedNewPayment_PaymentWaNotsAddedToTheDBAndSentFalse
()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}