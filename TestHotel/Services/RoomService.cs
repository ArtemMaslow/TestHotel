using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.Services
{
    public class RoomService
    {
        private DatabaseContext _context;

        public RoomService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateRoom(string number, int capacity, Guid typeId, Guid stateId, decimal price)
        {
            var room = new Room(number, capacity, typeId, stateId, price);
            _context.Rooms.Add(room);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoom(Guid roomId, string number, int capacity, Guid typeId, Guid stateId, decimal price)
        {
            var room = await _context.Rooms.SingleAsync(r => r.Id == roomId);
            room.Number = number;
            room.Capacity = capacity;
            room.TypeId = typeId;
            room.StateId = stateId;
            room.Price = price;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(Guid roomId)
        {
            var room = await _context.Rooms.SingleAsync(r => r.Id == roomId);
            _context.Rooms.Remove(room);

            await _context.SaveChangesAsync();
        }

        public async Task<Room> GetRoom(Guid roomId)
        {
            var room = await _context.Rooms.SingleAsync(r => r.Id == roomId);
            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.Include(s => s.State).Include(t=>t.Type).ToListAsync();
            return rooms;
        }

        public async Task ChangeState(Guid roomId, Guid stateId)
        {
            var room = await _context.Rooms.SingleAsync(r => r.Id == roomId);
            room.StateId = stateId;

            await _context.SaveChangesAsync();
        }
    }
}
