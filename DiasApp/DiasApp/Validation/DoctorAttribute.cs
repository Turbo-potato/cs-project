using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Validation
{
    public class DoctorAttribute : ValidationAttribute
    {
        private string _lastname;

        public DoctorAttribute(string lastname)
        {
            _lastname = lastname;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var doctor = (Doctor)validationContext.ObjectInstance;
            string lastname = "";

            if(doctor.Lastname == lastname)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Lastname must not be empty!";
        }


    }
}
