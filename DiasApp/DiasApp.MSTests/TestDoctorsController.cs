using System;
using System.Collections.Generic;
using System.Text;
using DiasApp.Controllers;
using DiasApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiasApp.MSTests
{
    class DoctorControllerTest
    {

        private List<Doctor> GetTestProducts()
        {
            var testDoctors = new List<Doctor>();
            testDoctors.Add(new Doctor { Id = 1, Firstname = "Alexey", Lastname = "Ivanov", Certificate = "PhD 2.4" });
            testDoctors.Add(new Doctor { Id = 2, Firstname = "Aybek", Lastname = "Ivanov", Certificate = "PhD 2.0" });
            testDoctors.Add(new Doctor { Id = 3, Firstname = "Ali", Lastname = "Ivanov", Certificate = "PhD 3.0" });
            testDoctors.Add(new Doctor { Id = 4, Firstname = "Anvar", Lastname = "Ivanov", Certificate = "PhD 2.0" });

            return testDoctors;
        }     
    }
}
