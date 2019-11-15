using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Doctor()
        {

        }
        public Doctor(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public int Id { set; get; }

        [Required]
        [Remote(action: "VerifyName", controller: "Doctors", AdditionalFields = nameof(Lastname), ErrorMessage = "Firstname must not be empty")]
        public string Firstname { set; get; }
        [Required]
        [Remote(action: "VerifyName", controller: "Doctors", AdditionalFields = nameof(Firstname), ErrorMessage = "Lastname must not be empty")]
        public string Lastname { set; get; }
        [Required(ErrorMessage = "Certificate is required")]
        public string Certificate { set; get; }
        //ONE doctor MANY patients
        public List<Patient> Patients { set; get; }

        //ONE-TO-ONE       
        public Organization Organization { get; set; }
    }
}
