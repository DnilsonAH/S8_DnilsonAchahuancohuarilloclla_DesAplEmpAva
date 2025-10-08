using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetByNameAsync(string name);
    Task<ClientWithOrdersDto?> GetClientWithMostOrdersAsync();
    Task<IEnumerable<ClientDto>> GetClientsByProductIdAsync(int productId);
}