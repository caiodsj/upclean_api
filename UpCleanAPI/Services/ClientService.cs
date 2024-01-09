using Microsoft.EntityFrameworkCore;
using UpCleanAPI.Data;
using UpCleanAPI.DTOs;
using UpCleanAPI.Models;

namespace UpCleanAPI.Services
{
    public class ClientService : IClientService
    {
        private readonly DataContext _context;

        public ClientService(DataContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateClient(ClientInsertDTO request)
        {
            var client = new Client
            {
                GivenName = request.GivenName,
                Surname = request.Surname,
                DateOfBirth = request.DateOfBirth,
                CPF = request.CPF,
                Address = new Address()
            };
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if(client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByCPF(string CPFrequest)
        {
            return await _context.Clients.Include(c => c.Address).FirstOrDefaultAsync(c => c.CPF == CPFrequest);
        }

        public async Task<Client> UpdateClient(int id, ClientUpdateDTO request)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if(client != null)
            {
                client.GivenName = request.GivenName;
                client.Surname = request.Surname;
                client.DateOfBirth = request.DateOfBirth;
            }
            await _context.SaveChangesAsync();
            return client;
        }
    }
}
