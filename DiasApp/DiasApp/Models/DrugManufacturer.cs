using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class DrugManufacturer
    {
        public int DrugId { get; set; }
        public Drug Drug { get; set; }

        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

    }
}
