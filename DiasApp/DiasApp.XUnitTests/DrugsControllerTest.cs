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
    public class DrugsControllerTest
    {
        [Fact]
        public async Task ConstructorTest()
        {
            var drug = new Drug("Meth", "Breaking Bad");
            Assert.Equal("Meth", drug.Name);
            Assert.Equal("Breaking Bad", drug.Description);
        }

        [Fact]
        public async Task InsertTest()
        {
            var fakeRepository = Mock.Of<IDrugRepository>();
            var drugService = new DrugService(fakeRepository);

            var drug = new Drug() { Name = "Korvalol", Type = "For heart", Description = "heart for designed medicine" };
            await drugService.Insert(drug);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IDrugRepository>();
            var drugService = new DrugService(fakeRepository);

            var drug = new Drug() { Name = "Korvalol", Type = "For heart", Description = "heart for designed medicine" };
            await drugService.Update(drug);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IDrugRepository>();
            var drugService = new DrugService(fakeRepository);

            var drug = new Drug() { Name = "Korvalol", Type = "For heart", Description = "heart for designed medicine" };
            await drugService.Delete(drug);
        }


        [Fact]
        public async Task GetDrugsTest()
        {
            var drugs = new List<Drug>
            {
                new Drug() { Name = "Korvalol", Type = "For heart", Description = "heart for designed medicine" },
                new Drug() { Name = "Korvalol", Type = "For heart", Description = "heart for designed medicine" },
            };

            var fakeRepositoryMock = new Mock<IDrugRepository>();
            fakeRepositoryMock.Setup(x => x.GetDrugs()).ReturnsAsync(drugs);


            var drugService = new DrugService(fakeRepositoryMock.Object);

            var resultDrugs = await drugService.GetDrugs();

            Assert.Collection(resultDrugs, drug =>
            {
                Assert.Equal("Korvalol", drug.Name);
            },
            drug =>
            {
                Assert.Equal("For heart", drug.Type);
            });
        }

        [Fact]
        public async Task SearchTest()
        {
            var movies = new List<Drug>
            {
                new Drug() { Name = "Korvalol", Type = "For heart", Description = "heart for designed medicine" },
                new Drug() { Name = "Korvalol", Type = "For heart", Description = "heart for designed medicine" },
            };

            var fakeRepositoryMock = new Mock<IDrugRepository>();
            fakeRepositoryMock.Setup(x => x.GetDrugWithPredicate(It.IsAny<Expression<Func<Drug, bool>>>())).ReturnsAsync(movies);


            var drugService = new DrugService(fakeRepositoryMock.Object);

            var resultDrugs = await drugService.Search("Dias");

            Assert.Collection(resultDrugs, drug =>
            {
                Assert.Equal("Korvalol", drug.Name);
            },
            drug =>
            {
                Assert.Equal("For heart", drug.Type);
            });
        }

        [Fact]
        public void DrugExistsTest()
        {
            int UserId = 1;

            var fakeRepositoryMock = new Mock<IDrugRepository>();
            fakeRepositoryMock.Setup(x => x.DrugExists(UserId)).Returns(true);

            var drugService = new DrugService(fakeRepositoryMock.Object);

            var isExist = drugService.DrugExists(UserId);

            Assert.True(isExist);
        }
    }
}
