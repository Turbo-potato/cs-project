using System;
using System.Collections.Generic;
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

        public int Id { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public string PatientName { set; get; }
        public int Quantity { set; get; }
        public string Frequency { set; get; }
        public string Instruction { set; get; }
    }
}
