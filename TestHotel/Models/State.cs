using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Models
{
    public class State
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public List<Room> Rooms { get; set; }
        
        public State()
        {

        }

        public State(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
