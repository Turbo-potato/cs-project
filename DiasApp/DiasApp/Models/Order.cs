using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiasApp.Models
{
    public class Order
    {
        private int id;
        private DateTime startTime;
        private DateTime endTime;

        public int Id { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
    }
}
