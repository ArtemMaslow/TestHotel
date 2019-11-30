using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.Services
{
    public class RoomTypeService
    {
        private DatabaseContext _context;

        public RoomTypeService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateRoomType(string roomType)
        {
            var newRoomType = new RoomType(roomType);
            _context.RoomTypes.Add(newRoomType);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomType(Guid roomTypeId, string type)
        {
            var roomType = _context.RoomTypes.FirstOrDefault(rt => rt.Id == roomTypeId);
            roomType.Type = type;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomType(Guid roomTypeId)
        {
            var roomType = _context.RoomTypes.FirstOrDefault(rt => rt.Id == roomTypeId);
            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();
        }

        public async Task<RoomType> GetRoomType(Guid roomTypeId)
        {
            var roomType = await _context.RoomTypes.SingleAsync(rt => rt.Id == roomTypeId);
            return roomType;
        }

        public async Task<List<RoomType>> GetRoomTypes()
        {
            var roomTypes = await _context.RoomTypes.ToListAsync();
            return roomTypes;
        }
    }
}
