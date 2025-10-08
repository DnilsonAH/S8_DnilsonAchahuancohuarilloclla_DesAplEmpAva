using Lab8_DnilsonAchahuancoHuarilloclla.Data;
using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;
using Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Services;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ClientDto>> GetByNameAsync(string name)
    {
        var clients = await _unitOfWork.Clients.GetByNameAsync(name);
        return clients.Select(c => new ClientDto
        {
            ClientId = c.ClientId,
            Name = c.Name,
            Email = c.Email
        });
    }

    public async Task<ClientWithOrdersDto?> GetClientWithMostOrdersAsync()
    {
        var client = await _unitOfWork.Clients.GetClientWithMostOrdersAsync();
        if (client == null) return null;

        return new ClientWithOrdersDto
        {
            ClientId = client.ClientId,
            Name = client.Name,
            Email = client.Email,
            TotalOrders = client.Orders.Count,
            TotalSpent = client.Orders.Sum(o => o.Orderdetails.Sum(od => od.Quantity * od.Product.Price))
        };
    }

    public async Task<IEnumerable<ClientDto>> GetClientsByProductIdAsync(int productId)
    {
        var clients = await _unitOfWork.Clients.GetClientsByProductIdAsync(productId);
        return clients.Select(c => new ClientDto
        {
            ClientId = c.ClientId,
            Name = c.Name,
            Email = c.Email
        });
    }
}