using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class Organization
    {
        private int id;
        private string name;
        private string address;

        public int Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }

        //ONE-TO-ONE
        public int DoctorForeignKey { get; set; }
        public Doctor Doctor { get; set; }
    }
}
