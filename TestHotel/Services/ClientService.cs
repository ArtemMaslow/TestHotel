using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestHotel.Models;

namespace TestHotel.Services
{
    public class ClientService
    {
        private DatabaseContext _context;

        public ClientService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateClient(string name, string surname, string patronymic, string phone)
        {
            var client = new Client(name, surname, patronymic, phone);
            _context.Clietns.Add(client);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateClient(Guid clientId, string name, string surname, string patronymic, string phone)
        {
            var client = await _context.Clietns.SingleAsync(c => c.Id == clientId);
            client.Name = name;
            client.Surname = surname;
            client.Patronymic = patronymic;
            client.Phone = phone;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteClient(Guid clientId)
        {
            var client = await _context.Clietns.SingleAsync(c => c.Id == clientId);
            _context.Clietns.Remove(client);

            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetClient(Guid clientId)
        {
            var client = await _context.Clietns.SingleAsync(c => c.Id == clientId);
            return client;
        }

        public async Task<List<Client>> GetClients()
        {
            var clients = await _context.Clietns.ToListAsync();
            return clients;
        }

    }
}
