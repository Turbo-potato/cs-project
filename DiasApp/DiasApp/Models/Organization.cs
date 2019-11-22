using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class Organization
    {
        private int id;

        private string name;
        private string address;

        public Organization()
        {

        }
        public Organization(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public int Id { set; get; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { set; get; }

        //ONE-TO-ONE
        public int DoctorForeignKey { get; set; }
        public Doctor Doctor { get; set; }
    }
}
