using Lab8_DnilsonAchahuancoHuarilloclla.Data;
using Lab8_DnilsonAchahuancoHuarilloclla.Models;
using Lab8_DnilsonAchahuancoHuarilloclla.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly LinqExampleContext _context;

    public ClientRepository(LinqExampleContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client?> GetByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    // Ejercicio 1: Obtener clientes por nombre (usando LINQ)
    public async Task<IEnumerable<Client>> GetByNameAsync(string name)
    {
        return await _context.Clients
            .Where(c => c.Name.Contains(name))
            .ToListAsync();
    }

    public async Task<Client> AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
        // SaveChanges se maneja desde UnitOfWork
        return client;
    }

    // Ejercicio 9: Obtener cliente con mayor número de pedidos (usando LINQ)
    public async Task<Client?> GetClientWithMostOrdersAsync()
    {
        var clientWithMostOrders = await _context.Orders
            .GroupBy(o => o.ClientId)
            .OrderByDescending(g => g.Count())
            .Select(g => new { ClientId = g.Key, OrderCount = g.Count() })
            .FirstOrDefaultAsync();

        if (clientWithMostOrders == null)
            return null;

        return await _context.Clients.FindAsync(clientWithMostOrders.ClientId);
    }

    // Ejercicio 12: Obtener clientes que han comprado un producto específico (usando LINQ)
    public async Task<IEnumerable<Client>> GetClientsByProductIdAsync(int productId)
    {
        return await _context.Orderdetails
            .Where(od => od.ProductId == productId)
            .Select(od => od.Order.Client)
            .Distinct()
            .ToListAsync();
    }

    public async Task UpdateAsync(Client client)
    {
        _context.Clients.Update(client);
        // SaveChanges se maneja desde UnitOfWork
    }

    public async Task DeleteAsync(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client != null)
        {
            _context.Clients.Remove(client);
            // SaveChanges se maneja desde UnitOfWork
        }
    }
}