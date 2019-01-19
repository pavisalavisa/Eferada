//using Business.Services.Contracts;
//using Eferada.Controllers;
//using FluentAssertions;
//using Moq;
//using NUnit.Framework;
//using System.Web.Mvc;

//namespace Eferada.Tests.Controllers
//{
//    [TestFixture]
//    public class HomeControllerTest
//    {
//        private Mock<ITestService> _testService;

//        private HomeController _controller;
//        [SetUp]
//        public void SetUp()
//        {
//            _testService = new Mock<ITestService>();

//            _controller=new HomeController(_testService.Object);
//        }
//       //[Test]
//       // public void Index()
//       // {
//       //     // Act
//       //     ViewResult result = _controller.Index() as ViewResult;

//       //     // Assert
//       //     result.Should().NotBeNull();
//       // }

//        //[TestMethod]
//        //public void About()
//        //{
//        //    // Arrange
//        //    HomeController controller = new HomeController();

//        //    // Act
//        //    ViewResult result = controller.About() as ViewResult;

//        //    // Assert
//        //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
//        //}

//        //[TestMethod]
//        //public void Contact()
//        //{
//        //    // Arrange
//        //    HomeController controller = new HomeController();

//        //    // Act
//        //    ViewResult result = controller.Contact() as ViewResult;

//        //    // Assert
//        //    Assert.IsNotNull(result);
//        //}
//    }
//}
