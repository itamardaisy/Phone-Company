using System;
using Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BL.UnitTests.Services_UnitTests
{
    [TestClass]
    public class LoginService_UnitTest
    {
        [TestMethod]
        public void LoginEmployee_RecivedNameAndPassword_ReturnUser()
        {
            //Arrange
            var user = new User { Name = "gaga", SignDate = DateTime.Now, CallAnswer = 9, Email = "lkmflkms@lf.com", Id = 4, Password = "12345678", Type = Common.Enums.UserType.Emploee };
            //Act
           // var res = new LoginService();
        }
    }
}