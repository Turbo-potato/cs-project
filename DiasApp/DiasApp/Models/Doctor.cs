using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class Doctor
    {
        private int id;
        private string firstname;
        private string lastname;
        private string certificate;
        private List<Patient> patients;
        public int Id { set; get; }

        [Remote(action: "VerifyName", controller: "DoctorsController", AdditionalFields = nameof(Firstname))]
        public string Firstname { set; get; }
        [Remote(action: "VerifyName", controller: "DoctorsController", AdditionalFields = nameof(Firstname))]
        public string Lastname { set; get; }
        public string Certificate { set; get; }
        //ONE doctor MANY patients
        public List<Patient> Patients { set; get; }

        //ONE-TO-ONE       
        public Organization Organization { get; set; }
    }
}
