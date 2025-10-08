using Lab8_DnilsonAchahuancoHuarilloclla.Models;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Repositories.Interfaces;

public interface IOrderRepository
{
    // CRUD Básico
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<Order> AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(int id);
    
    // Ejercicio 6: Pedidos después de una fecha específica (LINQ)
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
    
    // Métodos adicionales
    Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId);
    Task<object> GetAllWithDetailsAsync();
}