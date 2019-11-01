using System;
using System.Collections.Generic;
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
        public string Firstname { set; get; }
        public string Lastname { set; get; }
        //ONE doctor for MANY patient
        public int DoctorId { set; get; }
        public Doctor Doctor { set; get; }

    }
}
