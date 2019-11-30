using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Models
{
    public class Visit
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime Arrive { get; set; }
        public DateTime Leave { get; set; }
        public decimal? Cost { get; set; }

        public virtual Client Client { get; set; }
        public virtual Room Room { get; set; }

        public Visit()
        {

        }

        public Visit(Guid clientId, Guid roomId, DateTime arrive, DateTime leave)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            RoomId = roomId;
            Arrive = arrive;
            Leave = leave;
            //Cost = cost;
        }
    }
}
