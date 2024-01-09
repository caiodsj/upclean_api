using UpCleanAPI.DTOs;
using UpCleanAPI.Models;

namespace UpCleanAPI.Services
{
    public class ClientService : IClientService
    {
        public Task<Client> CreateClient(ClientInsertDTO request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Client>> GetAllClients()
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientByCPF(string CPFrequest)
        {
            throw new NotImplementedException();
        }

        public Task<Client> UpdateClient(int id, ClientUpdateDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
