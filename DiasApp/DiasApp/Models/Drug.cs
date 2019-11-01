using System;
using System.Collections.Generic;
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
        public decimal Price { set; get; }

        public string Name { set; get; }
        public string Type { set; get; }
        public string Description { set; get; }

        //MANY TO MANY
        public List<DrugManufacturer> DrugManufacturers { set; get; }

    }
}
