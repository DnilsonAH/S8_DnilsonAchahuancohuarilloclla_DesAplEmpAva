using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;
using Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("by-name/{name}")]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetByName(string name)
    {
        var clients = await _clientService.GetByNameAsync(name);
        return Ok(clients);
    }

    [HttpGet("most-orders")]
    public async Task<ActionResult<ClientWithOrdersDto>> GetClientWithMostOrders()
    {
        var client = await _clientService.GetClientWithMostOrdersAsync();
        if (client == null)
            return NotFound();
        return Ok(client);
    }

    [HttpGet("by-product/{productId:int}")]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetClientsByProduct(int productId)
    {
        var clients = await _clientService.GetClientsByProductIdAsync(productId);
        return Ok(clients);
    }
}
