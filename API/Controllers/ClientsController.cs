using API.Dtos.Client;
using API.Models;
using API.Services.ClientService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ClientsController : BaseApiController
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Client>>>> Get()
    {
        return Ok(await _clientService.GetAllClients());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<Client>>> GetSingle(int id)
    {
        return Ok(await _clientService.GetClientById(id));
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<Client>>>> AddClient(AddClientDto newClient)
    {
        return Ok(await _clientService.AddClient(newClient));
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<ServiceResponse<GetClientDto>>> UpdateClient(int id, UpdateClientDto updatedClient)
    {
        var response = await _clientService.UpdateClient(id, updatedClient);
        if (response.Data == null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<ServiceResponse<string>>> Delete(int id)
    {
        var response = await _clientService.DeleteClient(id);
        if (response.Data == null && response.Success == false)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}