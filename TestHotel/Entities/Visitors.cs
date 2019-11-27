using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Entities
{
    public class Visitors
    {
        public Guid Record { get; set; }
        public string Number { get; set; }
        public string Phone { get; set; }
        public DateTime Arrive { get; set; }
        public DateTime Leave { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Room Room { get; set; }

        public Visitors()
        {

        }

        public Visitors(string number, string phone, DateTime arrive, DateTime leave)
        {
            Record = Guid.NewGuid();
            Number = number;
            Phone = phone;
            Arrive = arrive;
            Leave = leave;
        }
    }
}
