using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.UI.Client;
using Web.UI.Client.Controllers;

namespace Web.UI.Client.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Post()
        {
            // Arrange
            LoginController controller = new LoginController();

            // Act
            //controller.Post("value");

            // Assert
            throw new NotImplementedException();

        }
    }
}
