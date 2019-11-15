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
    public class PrescriptionsControllerTest
    {
        [Fact]
        public async Task InsertTest()
        {
            var fakeRepository = Mock.Of<IPrescriptionRepository>();
            var prescriptionService = new PrescriptionService(fakeRepository);

            var prescription = new Prescription() { PatientName = "Dias", Instruction = "Not for a child", Frequency = "2 times a day" };
            await prescriptionService.Insert(prescription);
        }

        [Fact]
        public async Task UpdateTest()
        {
            var fakeRepository = Mock.Of<IPrescriptionRepository>();
            var prescriptionService = new PrescriptionService(fakeRepository);

            var prescription = new Prescription() { PatientName = "Dias", Instruction = "Not for a child", Frequency = "2 times a day" };
            await prescriptionService.Update(prescription);
        }

        [Fact]
        public async Task DeleteTest()
        {
            var fakeRepository = Mock.Of<IPrescriptionRepository>();
            var prescriptionService = new PrescriptionService(fakeRepository);

            var prescription = new Prescription() { PatientName = "Dias", Instruction = "Not for a child", Frequency = "2 times a day" };
            await prescriptionService.Delete(prescription);
        }


        [Fact]
        public async Task GetPrescriptionsTest()
        {
            var prescriptions = new List<Prescription>
            {
                new Prescription() { PatientName = "Dias", Instruction = "Not for a child", Frequency = "2 times a day" },
                new Prescription() { PatientName = "Said", Instruction = "Not for a child", Frequency = "2 times a day" },
            };

            var fakeRepositoryMock = new Mock<IPrescriptionRepository>();
            fakeRepositoryMock.Setup(x => x.GetPrescriptions()).ReturnsAsync(prescriptions);


            var prescriptionService = new PrescriptionService(fakeRepositoryMock.Object);

            var resultPrescriptions = await prescriptionService.GetPrescriptions();

            Assert.Collection(resultPrescriptions, prescription =>
            {
                Assert.Equal("Said", prescription.PatientName);
            },
            prescription =>
            {
                Assert.Equal("Not for a child", prescription.Instruction);
            });
        }

        [Fact]
        public async Task SearchTest()
        {
            var movies = new List<Prescription>
            {
                new Prescription() { PatientName = "Dias" },
                new Prescription() { PatientName = "Said" },
            };

            var fakeRepositoryMock = new Mock<IPrescriptionRepository>();
            fakeRepositoryMock.Setup(x => x.GetPrescriptionWithPredicate(It.IsAny<Expression<Func<Prescription, bool>>>())).ReturnsAsync(movies);


            var prescriptionService = new PrescriptionService(fakeRepositoryMock.Object);

            var resultPrescriptions = await prescriptionService.Search("Dias");

            Assert.Collection(resultPrescriptions, prescription =>
            {
                Assert.Equal("Dias", prescription.PatientName);
            },
            prescription =>
            {
                Assert.Equal("Said", prescription.PatientName);
            });
        }

        [Fact]
        public void PrescriptionExistsTest()
        {
            int UserId = 1;

            var fakeRepositoryMock = new Mock<IPrescriptionRepository>();
            fakeRepositoryMock.Setup(x => x.PrescriptionExists(UserId)).Returns(true);

            var prescriptionService = new PrescriptionService(fakeRepositoryMock.Object);

            var isExist = prescriptionService.PrescriptionExists(UserId);

            Assert.True(isExist);
        }
    }
}
