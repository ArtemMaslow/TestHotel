using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.Services
{
    public class VisitService
    {
        private DatabaseContext _context;

        public VisitService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateVisit(Guid clientId, Guid roomId, DateTime arrive, DateTime leave, Guid stateId)
        {
            var visit = new Visit(clientId, roomId, arrive, leave);
            
            var room = await _context.Rooms.SingleAsync(r => r.Id == roomId);
            room.StateId = stateId;
            
            _context.Visits.Add(visit);

            await _context.SaveChangesAsync();
        }

        public async Task CloseVisit(Guid visitId, decimal cost, Guid stateId)
        {
            var visit = await _context.Visits.SingleAsync(v => v.Id == visitId);
            visit.Cost = cost;

            var room = await _context.Rooms.SingleAsync(r => r.Id == visit.RoomId);
            room.StateId = stateId;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateVisit(Guid visitId, Guid clientId, Guid roomId, DateTime arrive, DateTime leave)
        {
            var visit = await _context.Visits.SingleAsync(v => v.Id == visitId);
            visit.ClientId = clientId;
            visit.RoomId = roomId;
            visit.Arrive = arrive;
            visit.Leave = leave;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteVisit(Guid visitId)
        {
            var visit = await _context.Visits.SingleAsync(v => v.Id == visitId);
            _context.Visits.Remove(visit);

            await _context.SaveChangesAsync();
        }

        public async Task<Visit> GetVisit(Guid visitId)
        {
            var visit = await _context.Visits.SingleAsync(c => c.Id == visitId);
            return visit;
        }

        public async Task<List<Visit>> GetVisits()
        {
            var visits = await _context.Visits.ToListAsync();
            return visits;
        }
    }
}
