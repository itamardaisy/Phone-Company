using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web.UI.Client;
using Web.UI.Client.Controllers;

namespace Web.UI.Client.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
