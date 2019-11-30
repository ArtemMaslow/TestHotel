using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.Services
{
    public class StateService
    {
        private DatabaseContext _context;

        public StateService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateState(string state)
        {
            var newstate = new State(state);
            _context.States.Add(newstate);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateState(Guid stateId, string name)
        {
            var state = _context.States.FirstOrDefault(s=>s.Id == stateId);
            state.Name = name;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteState(Guid stateId)
        {
            var state = _context.States.FirstOrDefault(s => s.Id == stateId);
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
        }

        public async Task<State> GetState(Guid stateId)
        {
            var state = await _context.States.SingleAsync(s => s.Id == stateId);
            return state;
        }

        public async Task<List<State>> GetStates()
        {
            var states = await _context.States.ToListAsync();
            return states;
        }
    }
}
