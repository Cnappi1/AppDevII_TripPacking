using TripListApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace TripListAppTests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Create_ValidName_RedirectsToIndex()
        {
            var controller = new HomeController(null);

            var result = controller.Create("Beach Trip");

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

        [Fact]
        public void Create_EmptyName_RedirectsToIndex()
        {
            var controller = new HomeController(null);

            var result = controller.Create("");

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }

        [Fact]
        public void Create_NullName_RedirectsToIndex()
        {
            var controller = new HomeController(null);

            var result = controller.Create(null);

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
        }
    }
}