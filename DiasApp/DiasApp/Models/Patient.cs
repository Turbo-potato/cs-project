using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class Patient
    {
        private int id;
        private string firstname;
        private string lastname;
        private Doctor doctor;
        public int Id { set; get; }
        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { set; get; }
        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { set; get; }
        //ONE doctor for MANY patient
        public int DoctorId { set; get; }
        public Doctor Doctor { set; get; }

    }
}
