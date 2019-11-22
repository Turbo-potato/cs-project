using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class Prescription
    {
        private int id;
        private DateTime startTime;
        private DateTime endTime;
        private string patientName;            
        private int quantity;
        private string frequency;
        private string instruction;

        public Prescription()
        {

        }
        public Prescription(string patientName, string frequency, string instruction)
        {
            PatientName = patientName;
            Frequency = frequency;
            Instruction = instruction;
        }

        public int Id { set; get; }
        [Required(ErrorMessage = "StartTime is required")]
        public DateTime StartTime { set; get; }
        [Required(ErrorMessage = "EndTime is required")]
        public DateTime EndTime { set; get; }
        [Required(ErrorMessage = "Firstname is required")]
        public string PatientName { set; get; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { set; get; }
        [Required(ErrorMessage = "Frequency is required")]
        public string Frequency { set; get; }
        [Required(ErrorMessage = "Instruction is required")]
        public string Instruction { set; get; }
    }
}
