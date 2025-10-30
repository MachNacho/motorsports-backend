using Microsoft.AspNetCore.Mvc;
using Moq;
using motorsports_backend.Controllers;
using motorsports_Service.DTOs.Driver;
using motorsports_Service.Interface;

namespace motorsports_UnitTests.Controller
{
    [TestFixture]
    public class DriverControllerUnitTest
    {
        private Mock<IDriverService> _driverServiceMock;
        private DriverController _driverController;

        [SetUp]
        public void Setup()
        {
            _driverServiceMock = new Mock<IDriverService>();
            _driverController = new DriverController(_driverServiceMock.Object);
        }

        private List<DriverDTO> sampleDriverCollection() => new()
        {
            new DriverDTO
            {
                Id = Guid.NewGuid(),
                Firstname = "Lando",
                Lastname = "Norris",
                Code = "UK",
                Country = "United Knigdom",
                RaceNumber = 12,
                TeamName= "McLaren F1"
            }
        };
        [Test]
        public async Task GetAllDrivers_DriversExists_ReturnList()
        {
            var A = sampleDriverCollection();
            //Arrange
            _driverServiceMock.Setup(a => a.GetAllDriversAsync()).ReturnsAsync(A);
            //Act
            var results = await _driverController.GetAllDrivers();
            //Assert
            Assert.That(results, Is.Not.Null);

            var okResult = results as OkObjectResult;
            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(A));
        }
    }
}
