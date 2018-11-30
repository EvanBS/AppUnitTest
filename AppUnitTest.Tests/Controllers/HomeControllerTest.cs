using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppUnitTest.Controllers;
using System.Web.Mvc;
using System.Threading.Tasks;
using Moq;
using AppUnitTest.Models;
using System.Collections.Generic;

namespace AppUnitTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public async Task IndexViewModelNotNullAsync()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>());
            HomeController controller = new HomeController(mock.Object);

            // Act
            var res = await controller.Index() as ViewResult;
        }

        [TestMethod]
        public async Task IndexViewBagMessageAsync()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>() { new Computer() });
            HomeController controller = new HomeController(mock.Object);
            string expected = "DB has 1 objects";

            // Act
            var res = await controller.Index() as ViewResult;
            string actual = res.ViewBag.Message as string;

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
