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
    public class PatientsControllerTest
    {
        [Fact]
        public async Task InsertTest()
        {
            var fakeRepository = Mock.Of<IPatientRepository>();
            var patientService = new PatientService(fakeRepository);

            var patient = new Patient() { Firstname = "Dias", Lastname = " Isabekov" };
            await patientService.Insert(patient);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IPatientRepository>();
            var patientService = new PatientService(fakeRepository);

            var patient = new Patient() { Firstname = "Dias", Lastname = " Isabekov" };
            await patientService.Update(patient);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IPatientRepository>();
            var patientService = new PatientService(fakeRepository);

            var patient = new Patient() { Firstname = "Dias", Lastname = " Isabekov"  };
            await patientService.Delete(patient);
        }


        [Fact]
        public async Task GetPatientsTest()
        {
            var patients = new List<Patient>
            {
                new Patient() { Firstname = "Dias", Lastname = " Isabekov"  },
                new Patient() { Firstname = "Said", Lastname = " Isabekov"  },
            };

            var fakeRepositoryMock = new Mock<IPatientRepository>();
            fakeRepositoryMock.Setup(x => x.GetPatients()).ReturnsAsync(patients);


            var patientService = new PatientService(fakeRepositoryMock.Object);

            var resultPatients = await patientService.GetPatients();

            Assert.Collection(resultPatients, patient =>
            {
                Assert.Equal("Said", patient.Firstname);
            },
            patient =>
            {
                Assert.Equal("Dias", patient.Lastname);
            });
        }

        [Fact]
        public async Task SearchTest()
        {
            var movies = new List<Patient>
            {
                new Patient() { Firstname = "Dias" },
                new Patient() { Firstname = "Said" },
            };

            var fakeRepositoryMock = new Mock<IPatientRepository>();
            fakeRepositoryMock.Setup(x => x.GetPatientWithPredicate(It.IsAny<Expression<Func<Patient, bool>>>())).ReturnsAsync(movies);


            var patientService = new PatientService(fakeRepositoryMock.Object);

            var resultPatients = await patientService.Search("Dias");

            Assert.Collection(resultPatients, patient =>
            {
                Assert.Equal("Dias", patient.Firstname);
            },
            patient =>
            {
                Assert.Equal("Dias", patient.Lastname);
            });
        }

        [Fact]
        public void PatientExistsTest()
        {
            int UserId = 1;

            var fakeRepositoryMock = new Mock<IPatientRepository>();
            fakeRepositoryMock.Setup(x => x.PatientExists(UserId)).Returns(true);

            var patientService = new PatientService(fakeRepositoryMock.Object);

            var isExist = patientService.PatientExists(UserId);

            Assert.True(isExist);
        }
    }
}
