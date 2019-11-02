using DiasApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Validation
{
    public class DrugIValidatable : IValidatableObject
    {
        private const string _empty = "";

        public int Id { set; get; }

        [Required]
        public double Dosage { set; get; }

        [Required]
        [Range(1, 100), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { set; get; }

        [Required]
        [StringLength(150)]
        public string Name { set; get; }

        [Required]
        public string Type { set; get; }

        [StringLength(150, MinimumLength = 3)]
        public string Description { set; get; }

        //MANY TO MANY
        public List<DrugManufacturer> DrugManufacturers { set; get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == _empty)
            {
                yield return new ValidationResult(
                    $"Drug name must not be empty!",
                    new[] { "Name" });
            }
        }

    }
}
