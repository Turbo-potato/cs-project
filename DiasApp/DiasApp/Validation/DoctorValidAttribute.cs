using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Validation
{
    public class DrugValidAttribute : ValidationAttribute
    {
        //private double _dosage;

        public DrugValidAttribute()
        {
           // _dosage = dosage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var drug = (Drug)validationContext.ObjectInstance;
            double doseEmpty = 0.0;

            if (drug.Dosage == doseEmpty)
            {
                return new ValidationResult(GetErrorLackDoseMessage());
            }
            else if (drug.Dosage >= 999.99)
            {
                return new ValidationResult(GetErrorOverdoseMessage());
            }

            return ValidationResult.Success;
        }

        public string GetErrorLackDoseMessage()
        {
            return $"Lack of dose!";
        }

        public string GetErrorOverdoseMessage()
        {
            return $"Overdose!";
        }


    }
}
