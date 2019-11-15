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
    public class OrderControllerTest
    {
        [Fact]
        public async Task InsertTest()
        {
            var fakeRepository = Mock.Of<IOrderRepository>();
            var orderService = new OrderService(fakeRepository);

            var order = new Order() { StartTime = DateTime.Now };
            await orderService.Insert(order);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IOrderRepository>();
            var orderService = new OrderService(fakeRepository);

            var order = new Order() { StartTime = DateTime.Now };
            await orderService.Update(order);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IOrderRepository>();
            var orderService = new OrderService(fakeRepository);

            var order = new Order() { StartTime = DateTime.Now };
            await orderService.Delete(order);
        }


        [Fact]
        public async Task GetOrdersTest()
        {
            var orders = new List<Order>
            {
                new Order() { StartTime = DateTime.Now },
                new Order() { StartTime = DateTime.Now },
            };

            var fakeRepositoryMock = new Mock<IOrderRepository>();
            fakeRepositoryMock.Setup(x => x.GetOrders()).ReturnsAsync(orders);


            var orderService = new OrderService(fakeRepositoryMock.Object);

            var resultOrders = await orderService.GetOrders();

            Assert.Collection(resultOrders, order =>
            {
                Assert.Equal("16.11.2019", order.StartTime.ToString());
            },
            order =>
            {
                Assert.Equal("22.11.2019", order.StartTime.ToString());
            });
        }

        [Fact]
        public async Task SearchTest()
        {
            var movies = new List<Order>
            {
                new Order() { StartTime = DateTime.Now },
                new Order() { StartTime = DateTime.Now },
            };

            var fakeRepositoryMock = new Mock<IOrderRepository>();
            fakeRepositoryMock.Setup(x => x.GetOrderWithPredicate(It.IsAny<Expression<Func<Order, bool>>>())).ReturnsAsync(movies);


            var orderService = new OrderService(fakeRepositoryMock.Object);

            var resultOrders = await orderService.Search("Dias");

            Assert.Collection(resultOrders, order =>
            {
                Assert.Equal("16.11.2019", order.StartTime.ToString());
            },
            order =>
            {
                Assert.Equal("15.11.2019", order.StartTime.ToString());
            });
        }

        [Fact]
        public void OrderExistsTest()
        {
            int UserId = 1;

            var fakeRepositoryMock = new Mock<IOrderRepository>();
            fakeRepositoryMock.Setup(x => x.OrderExists(UserId)).Returns(true);

            var orderService = new OrderService(fakeRepositoryMock.Object);

            var isExist = orderService.OrderExists(UserId);

            Assert.True(isExist);
        }
    }
}
