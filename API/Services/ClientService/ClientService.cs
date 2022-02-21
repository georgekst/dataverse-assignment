using API.Data;
using API.Dtos.Client;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ClientService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetClientDto>>> GetAllClients()
        {
            var serviceResponse = new ServiceResponse<List<GetClientDto>>();
            var dbClients = await _context.Clients
                .Include(c => c.ContactInfo)
                .ToListAsync();
            serviceResponse.Data = _mapper.Map<List<GetClientDto>>(dbClients);;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetClientDto>> GetClientById(int id)
        {
            var serviceResponse = new ServiceResponse<GetClientDto>();
            var dbClient = await _context.Clients
                .Include(c => c.ContactInfo)
                .FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetClientDto>(dbClient);;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetClientDto>> AddClient(AddClientDto newClient)
        {
            var serviceResponse = new ServiceResponse<GetClientDto>();
            var clientToSave = _mapper.Map<Client>(newClient);
            _context.Clients.Add(clientToSave);
            await _context.SaveChangesAsync();
            serviceResponse.Data =  _mapper.Map<GetClientDto>(clientToSave);;
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetClientDto>> UpdateClient(int id, UpdateClientDto updatedClient)
        {
            var serviceResponse = new ServiceResponse<GetClientDto>();
            try
            {
                Client client = await _context.Clients
                    .Include(c => c.ContactInfo)
                    .FirstOrDefaultAsync(c => c.Id == id);
                if (client != null)
                {
                    client.FirstName = updatedClient.FirstName;
                    client.LastName = updatedClient.LastName;
                    client.ContactInfo = _mapper.Map<List<ContactInfo>>(updatedClient.ContactInfo);
                    client.Address = updatedClient.Address;
                    client.Email = updatedClient.Email;

                    await _context.SaveChangesAsync();

                    serviceResponse.Data = _mapper.Map<GetClientDto>(client);
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Client not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<string>> DeleteClient(int id)
        {
            var serviceResponse = new ServiceResponse<string>();
            try
            {
                var client = await _context.Clients
                    .Include(c => c.ContactInfo)
                    .FirstOrDefaultAsync(c => c.Id == id);
                if (client != null)
                {
                    _context.Clients.Remove(client);
                    await _context.SaveChangesAsync();

                    serviceResponse.Message = "Client successfully deleted.";
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Client not found.";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}