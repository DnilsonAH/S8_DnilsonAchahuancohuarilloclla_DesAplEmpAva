using Lab8_DnilsonAchahuancoHuarilloclla.Data;
using Lab8_DnilsonAchahuancoHuarilloclla.Models;
using Lab8_DnilsonAchahuancoHuarilloclla.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly LinqExampleContext _context;

    public OrderRepository(LinqExampleContext context)
    {
        _context = context;
    }

    // CRUD Básico
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders
            .Include(o => o.Client)
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .FirstOrDefaultAsync(o => o.OrderId == id);
    }

    public async Task<Order> AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        return order;
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
        }
    }

    // Ejercicio 6: Obtener pedidos después de una fecha específica (usando LINQ)
    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.OrderDate > date)
            .Include(o => o.Client)
            .ToListAsync();
    }

    // Método adicional
    public async Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId)
    {
        return await _context.Orders
            .Where(o => o.ClientId == clientId)
            .Include(o => o.Client)
            .Include(o => o.Orderdetails)
            .ThenInclude(od => od.Product)
            .ToListAsync();
    }
}