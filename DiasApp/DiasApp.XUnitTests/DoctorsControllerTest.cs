
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

namespace DiasApp.XUnitTests
{
    [TestClass]
    public class DoctorsControllerTest
    {
        [Fact]
        public async Task ConstructorTest()
        {
            var doctor = new Doctor("Dias", "Isabekov");
            Assert.Equal("Dias", doctor.Firstname);
            Assert.Equal("Isabekov", doctor.Lastname);
        }

        [Fact]
        public async Task InsertTest()
        {
            var fakeRepository = Mock.Of<IDoctorRepository>();
            var doctorService = new DoctorService(fakeRepository);

            var doctor = new Doctor() { Firstname = "Dias", Lastname = " Isabekov", Certificate = "IITU doctor" };
            await doctorService.Insert(doctor);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IDoctorRepository>();
            var doctorService = new DoctorService(fakeRepository);

            var doctor = new Doctor() { Firstname = "Dias", Lastname = " Isabekov", Certificate = "IITU doctor" };
            await doctorService.Update(doctor);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IDoctorRepository>();
            var doctorService = new DoctorService(fakeRepository);

            var doctor = new Doctor() { Firstname = "Dias", Lastname = " Isabekov", Certificate = "IITU doctor" };
            await doctorService.Delete(doctor);
        }


        [Fact]
        public async Task GetDoctorsTest()
        {
            var doctors = new List<Doctor>
            {
                new Doctor() { Firstname = "Dias", Lastname = " Isabekov", Certificate = "IITU doctor" },
                new Doctor() { Firstname = "Said", Lastname = " Isabekov", Certificate = "IITU doctor" },
            };

            var fakeRepositoryMock = new Mock<IDoctorRepository>();
            fakeRepositoryMock.Setup(x => x.GetDoctors()).ReturnsAsync(doctors);


            var doctorService = new DoctorService(fakeRepositoryMock.Object);

            var resultDoctors = await doctorService.GetDoctors();

            Assert.Collection(resultDoctors, doctor =>
            {
                Assert.Equal("Said", doctor.Firstname);
            },
            doctor =>
            {
                Assert.Equal("Dias", doctor.Lastname);
            });
        }

        [Fact]
        public async Task SearchTest()
        {
            var movies = new List<Doctor>
            {
                new Doctor() { Firstname = "Dias" },
                new Doctor() { Firstname = "Said" },
            };

            var fakeRepositoryMock = new Mock<IDoctorRepository>();
            fakeRepositoryMock.Setup(x => x.GetDoctorWithPredicate(It.IsAny<Expression<Func<Doctor, bool>>>())).ReturnsAsync(movies);


            var doctorService = new DoctorService(fakeRepositoryMock.Object);

            var resultDoctors = await doctorService.Search("Dias");

            Assert.Collection(resultDoctors, doctor =>
            {
                Assert.Equal("Dias", doctor.Firstname);
            },
            doctor =>
            {
                Assert.Equal("Dias", doctor.Lastname);
            });
        }

        [Fact]
        public void DoctorExistsTest()
        {
            int UserId = 1;

            var fakeRepositoryMock = new Mock<IDoctorRepository>();
            fakeRepositoryMock.Setup(x => x.DoctorExists(UserId)).Returns(true);

            var doctorService = new DoctorService(fakeRepositoryMock.Object);

            var isExist = doctorService.DoctorExists(UserId);

            Assert.True(isExist);
        }
    }
}
