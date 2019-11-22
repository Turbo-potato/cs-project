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
    public class OrganizationsControllerTest
    {
        [Fact]
        public async Task ConstructorTest()
        {
            var organization = new Organization("Health inc.", @"Manasov 25/8");
            Assert.Equal("Health inc.", organization.Name);
            Assert.Equal(@"Manasov 25/8", organization.Address);
        }

        [Fact]
        public async Task InsertTest()
        {
            var fakeRepository = Mock.Of<IOrganizationRepository>();
            var organizationService = new OrganizationService(fakeRepository);

            var organization = new Organization() { Name = "Dias", Address = " IITU Zhandosov st." };
            await organizationService.Insert(organization);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IOrganizationRepository>();
            var organizationService = new OrganizationService(fakeRepository);

            var organization = new Organization() { Name = "Dias", Address = " IITU Zhandosov st." };
            await organizationService.Update(organization);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IOrganizationRepository>();
            var organizationService = new OrganizationService(fakeRepository);

            var organization = new Organization() { Name = "Dias", Address = " IITU Zhandosov st." };
            await organizationService.Delete(organization);
        }


        [Fact]
        public async Task GetOrganizationsTest()
        {
            var organizations = new List<Organization>
            {
                new Organization() { Name = "Said", Address = "IITU Zhandosov st." },
                new Organization() { Name = "Said", Address = "IITU Zhandosov st." },
            };

            var fakeRepositoryMock = new Mock<IOrganizationRepository>();
            fakeRepositoryMock.Setup(x => x.GetOrganizations()).ReturnsAsync(organizations);


            var organizationService = new OrganizationService(fakeRepositoryMock.Object);

            var resultOrganizations = await organizationService.GetOrganizations();

            Assert.Collection(resultOrganizations, organization =>
            {
                Assert.Equal("Said", organization.Name);
            },
            organization =>
            {
                Assert.Equal("IITU Zhandosov st.", organization.Address);
            });
        }

        [Fact]
        public async Task SearchTest()
        {
            var movies = new List<Organization>
            {
                new Organization() { Name = "Dias" },
                new Organization() { Name = "Said" },
            };

            var fakeRepositoryMock = new Mock<IOrganizationRepository>();
            fakeRepositoryMock.Setup(x => x.GetOrganizationWithPredicate(It.IsAny<Expression<Func<Organization, bool>>>())).ReturnsAsync(movies);


            var organizationService = new OrganizationService(fakeRepositoryMock.Object);

            var resultOrganizations = await organizationService.Search("Dias");

            Assert.Collection(resultOrganizations, organization =>
            {
                Assert.Equal("Dias", organization.Name);
            },
            organization =>
            {
                Assert.Equal("Said", organization.Name);
            });
        }

        [Fact]
        public void OrganizationExistsTest()
        {
            int UserId = 1;

            var fakeRepositoryMock = new Mock<IOrganizationRepository>();
            fakeRepositoryMock.Setup(x => x.OrganizationExists(UserId)).Returns(true);

            var organizationService = new OrganizationService(fakeRepositoryMock.Object);

            var isExist = organizationService.OrganizationExists(UserId);

            Assert.True(isExist);
        }
    }
}
