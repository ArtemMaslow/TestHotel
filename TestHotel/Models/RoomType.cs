using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Models
{
    public class RoomType
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public List<Room> Rooms { get; set; }

        public RoomType()
        {

        }

        public RoomType(string type)
        {
            Id = Guid.NewGuid();
            Type = type;
        }
    }
}
