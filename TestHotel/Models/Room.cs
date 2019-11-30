using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }
        public Guid TypeId { get; set; }
        public Guid StateId { get; set; }
        public decimal Price { get; set; }
        
        public virtual RoomType Type { get; set; }
        public virtual State State { get; set; }

        public Room()
        {

        }

        public Room(string number, int capacity, Guid typeId, Guid stateId, decimal price)
        {
            Id = Guid.NewGuid();
            Number = number;
            Capacity = capacity;
            TypeId = typeId;
            StateId = stateId;
            Price = price;
        }
    }
}
