using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class Order
    {
        private int id;
        private DateTime startTime;
        private DateTime endTime;

        public Order()
        {

        }
        public Order(DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public int Id { set; get; }
        [Required(ErrorMessage = "StartTime is required")]
        public DateTime StartTime { set; get; }
        [Required(ErrorMessage = "EndTime is required")]
        public DateTime EndTime { set; get; }
    }
}
