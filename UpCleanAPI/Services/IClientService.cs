using System.Numerics;
using UpCleanAPI.DTOs;
using UpCleanAPI.Models;

namespace UpCleanAPI.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClients();
        Task<Client> GetClientByCPF(string CPFrequest);
        Task<Client> CreateClient(ClientInsertDTO request);
        Task<Client> UpdateClient(int id, ClientUpdateDTO request);
        Task DeleteClient(int id);
    }
}
