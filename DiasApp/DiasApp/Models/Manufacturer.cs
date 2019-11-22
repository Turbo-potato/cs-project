using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class Manufacturer
    {
        private int id;
        private string name;
        private string address;
        private List<Drug> drugs;

        public Manufacturer()
        {

        }
        public Manufacturer(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public int Id { set; get; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { set; get; }

        //MANY drugs to MANY MANFS
        public List<DrugManufacturer> DrugManufacturers { set; get; }

    }
}
