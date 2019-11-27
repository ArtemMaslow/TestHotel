using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Entities;

namespace TestHotel.Services
{
    public class RoomService
    {
        private DatabaseContext _context;

        public RoomService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Room> GetRoomInfo(string number)
        {
            var roomInfo = await _context.Rooms.SingleAsync(n => n.Number == number);
            Console.WriteLine($"{roomInfo.Number} {roomInfo.Type} {roomInfo.Capacity} {roomInfo.State}");

            return roomInfo;
        }

        public async Task Room(string number, int capacity, string type, bool state)
        {
            var room = new Room(number, capacity, type, state);
            _context.Rooms.Add(room);

            await _context.SaveChangesAsync();
        }
    }
}
