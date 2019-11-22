using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DiasApp.Services;
using DiasApp.Models;
using System.Linq.Expressions;
using Assert = Xunit.Assert;
using System;
using DiasApp.Interfaces;

namespace DiasApp.XUnitTests
{
    public class ManufacturersControllerTest
    {
        [Fact]
        public async Task ConstructorTest()
        {
            var manufacturer = new Manufacturer("IITU", "Zhanodsov st.");
            Assert.Equal("IITU", manufacturer.Name);
            Assert.Equal("Zhanodsov st.", manufacturer.Address);
        }

        [Fact]
        public async Task InsertTest()
        {
            var fakeRepository = Mock.Of<IManufacturerRepository>();
            var manufacturerService = new ManufacturerService(fakeRepository);

            var manufacturer = new Manufacturer() { Name = "Dias", Address = "USA LA" };
            await manufacturerService.Insert(manufacturer);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IManufacturerRepository>();
            var manufacturerService = new ManufacturerService(fakeRepository);

            var manufacturer = new Manufacturer() { Name = "Dias", Address = "USA LA" };
            await manufacturerService.Update(manufacturer);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IManufacturerRepository>();
            var manufacturerService = new ManufacturerService(fakeRepository);

            var manufacturer = new Manufacturer() { Name = "Dias", Address = "USA LA" };
            await manufacturerService.Delete(manufacturer);
        }


        [Fact]
        public async Task GetManufacturersTest()
        {
            var manufacturers = new List<Manufacturer>
            {
                new Manufacturer() { Name = "Said", Address = "USA LA" },
                new Manufacturer() { Name = "Said", Address = "USA LA" },
            };

            var fakeRepositoryMock = new Mock<IManufacturerRepository>();
            fakeRepositoryMock.Setup(x => x.GetManufacturers()).ReturnsAsync(manufacturers);


            var manufacturerService = new ManufacturerService(fakeRepositoryMock.Object);

            var resultManufacturers = await manufacturerService.GetManufacturers();

            Assert.Collection(resultManufacturers, manufacturer =>
            {
                Assert.Equal("Said", manufacturer.Name);
            },
            manufacturer =>
            {
                Assert.Equal("USA LA", manufacturer.Address);
            });
        }

        [Fact]
        public async Task SearchTest()
        {
            var movies = new List<Manufacturer>
            {
                new Manufacturer() { Name = "Dias" },
                new Manufacturer() { Name = "Said" },
            };

            var fakeRepositoryMock = new Mock<IManufacturerRepository>();
            fakeRepositoryMock.Setup(x => x.GetManufacturerWithPredicate(It.IsAny<Expression<Func<Manufacturer, bool>>>())).ReturnsAsync(movies);


            var manufacturerService = new ManufacturerService(fakeRepositoryMock.Object);

            var resultManufacturers = await manufacturerService.Search("Dias");

            Assert.Collection(resultManufacturers, manufacturer =>
            {
                Assert.Equal("Dias", manufacturer.Name);
            },
            manufacturer =>
            {
                Assert.Equal("Said", manufacturer.Name);
            });
        }

        [Fact]
        public void ManufacturerExistsTest()
        {
            int UserId = 1;

            var fakeRepositoryMock = new Mock<IManufacturerRepository>();
            fakeRepositoryMock.Setup(x => x.ManufacturerExists(UserId)).Returns(true);

            var manufacturerService = new ManufacturerService(fakeRepositoryMock.Object);

            var isExist = manufacturerService.ManufacturerExists(UserId);

            Assert.True(isExist);
        }
    }
}
