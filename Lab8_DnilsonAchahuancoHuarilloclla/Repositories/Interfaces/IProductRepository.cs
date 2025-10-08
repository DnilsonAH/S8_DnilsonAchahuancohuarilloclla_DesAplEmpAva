using Lab8_DnilsonAchahuancoHuarilloclla.Models;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Repositories.Interfaces;

public interface IProductRepository
{
    // CRUD Básico
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    
    // Ejercicio 2: Productos con precio mayor a un valor (LINQ)
    Task<IEnumerable<Product>> GetByPriceGreaterThanAsync(decimal price);
    
    // Ejercicio 5: Producto más caro (LINQ)
    Task<Product?> GetMostExpensiveAsync();
    
    // Ejercicio 7: Promedio de precio de productos (LINQ)
    Task<decimal> GetAveragePriceAsync();
    
    // Ejercicio 8: Productos sin descripción (LINQ)
    Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync();
    
    // Ejercicio 11: Productos vendidos a un cliente específico (LINQ)
    Task<IEnumerable<Product>> GetProductsByClientIdAsync(int clientId);
    Task<int> GetTotalSoldAsync(int productId);
    Task<Product?> GetByIdWithDetailsAsync(int id);
}