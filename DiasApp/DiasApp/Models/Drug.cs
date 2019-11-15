using DiasApp.Validation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class Drug : IValidatableObject
    {
        private int id;
        private string name;
        private string description;
        private string type;
        private double dosage;
        private decimal price;
        private List<Manufacturer> manufacturers;

        public Drug()
        {

        }
        public Drug(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public int Id { set; get; }
        [Required]
        [DrugValid]
        //[Range(1, 100), DataType(DataType.Currency)]
        public double Dosage { set; get; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { set; get; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Type is required")]
        public string Type { set; get; }

        [Required]
        [Remote(action: "VerifyDescription", controller: "Drugs", ErrorMessage = "Description must contain proper values")]
        [StringLength(150, MinimumLength = 3)]
        public string Description { set; get; }

        //MANY TO MANY
        public List<DrugManufacturer> DrugManufacturers { set; get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Price <= 0 )
            {
                yield return new ValidationResult(
                    $"Drug Price must not be empty or negative!",
                    new[] { "Price" });
            }
        }

    }
}
