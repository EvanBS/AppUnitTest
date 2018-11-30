using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppUnitTest.Controllers;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace AppUnitTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public async Task IndexViewModelNotNullAsync()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var res = await controller.Index() as ViewResult;
            
            // Assert
            Assert.IsNotNull(res.Model);
        }

    }
}
