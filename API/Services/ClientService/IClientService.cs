using API.Dtos.Client;
using API.Models;

namespace API.Services.ClientService
{
    public interface IClientService
    {
        Task<ServiceResponse<List<GetClientDto>>> GetAllClients();
        Task<ServiceResponse<GetClientDto>> GetClientById(int id);
        Task<ServiceResponse<GetClientDto>> AddClient(AddClientDto newClient);
        Task<ServiceResponse<GetClientDto>> UpdateClient(int id, UpdateClientDto updatedClient);
        Task<ServiceResponse<string>> DeleteClient(int id);
    }
}