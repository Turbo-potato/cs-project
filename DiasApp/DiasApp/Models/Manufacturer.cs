using System;
using System.Collections.Generic;
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

        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }

        //MANY drugs to MANY MANFS
        public List<DrugManufacturer> DrugManufacturers { set; get; }

    }
}
