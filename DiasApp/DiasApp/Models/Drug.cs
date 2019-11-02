﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class Drug
    {
        private int id;
        private string name;
        private string description;
        private string type;
        private double dosage;
        private decimal price;
        private List<Manufacturer> manufacturers;

        public int Id { set; get; }
        public double Dosage { set; get; }

        [Required]
        [Range(1, 100), DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { set; get; }

        public string Name { set; get; }
        public string Type { set; get; }

        [StringLength(150, MinimumLength = 3)]
        public string Description { set; get; }

        //MANY TO MANY
        public List<DrugManufacturer> DrugManufacturers { set; get; }

    }
}
