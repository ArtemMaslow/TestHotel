using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Entities
{
    public class Room
    {
        public string Number { get; set; }
        public int Capacity { get; set; }
        public string Type { get; set; }
        public bool State { get; set; }

        public Room()
        {

        }

        public Room(string number, int capacity, string type, bool state)
        {
            Number = number;
            Capacity = capacity;
            Type = type;
            State = state;
        }
    }
}
