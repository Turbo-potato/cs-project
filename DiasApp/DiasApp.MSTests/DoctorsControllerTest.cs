using DiasApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xunit;
using Moq;
using DiasApp.Services;
using DiasApp.Models;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace DiasApp.MSTests
{
    [TestClass]
    class DoctorsControllerTest
    {
        [Fact]
        public void InsertTest()
        {
            var fakeRepository = Mock.Of<IDoctorRepository>();
            var movieService = new DoctorService(fakeRepository);

            var doctor = new Doctor() { Firstname = "Dias", Lastname = " Isabekov", Certificate = "IITU doctor" };
             movieService.Insert(doctor);
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
            var movies = new List<Movie>
            {
                new Movie() { Name = "test movie 1" },
                new Movie() { Name = "test movie 2" },
            };

            var fakeRepositoryMock = new Mock<IMovieRepository>();
            fakeRepositoryMock.Setup(x => x.GetMovies(It.IsAny<Expression<Func<Movie, bool>>>())).ReturnsAsync(movies);


            var movieService = new MovieService(fakeRepositoryMock.Object);

            var resultMovies = await movieService.Search("TEST");

            Assert.Collection(resultMovies, movie =>
            {
                Assert.Equal("test movie 1", movie.Name);
            },
            movie =>
            {
                Assert.Equal("test movie 2", movie.Name);
            });
        }
    }
}
