using Lab8_DnilsonAchahuancoHuarilloclla.Models;


namespace Lab8_DnilsonAchahuancoHuarilloclla.Repositories.Interfaces;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAllAsync();
    Task<Client?> GetByIdAsync(int id);
    Task<IEnumerable<Client>> GetByNameAsync(string name);
    Task<Client> AddAsync(Client client);
    Task<Client?> GetClientWithMostOrdersAsync();
    Task<IEnumerable<Client>> GetClientsByProductIdAsync(int productId);
    Task UpdateAsync(Client client);
    Task DeleteAsync(int id);
}