using Lab8_DnilsonAchahuancoHuarilloclla.Data;
using Lab8_DnilsonAchahuancoHuarilloclla.Models;
using Lab8_DnilsonAchahuancoHuarilloclla.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Repositories;



public class ProductRepository : IProductRepository
{
    private readonly LinqExampleContext _context;

    public ProductRepository(LinqExampleContext context)
    {
        _context = context;
    }

    // CRUD Básico
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Orderdetails)
            .FirstOrDefaultAsync(p => p.ProductId == id);
    }

    public async Task<Product> AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        return product;
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
        }
    }

    // Ejercicio 2: Obtener productos con precio mayor a un valor específico (usando LINQ)
    public async Task<IEnumerable<Product>> GetByPriceGreaterThanAsync(decimal price)
    {
        return await _context.Products
            .Where(p => p.Price > price)
            .ToListAsync();
    }

    // Ejercicio 5: Obtener el producto más caro (usando LINQ)
    public async Task<Product?> GetMostExpensiveAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }

    // Ejercicio 7: Obtener el promedio de precio de los productos (usando LINQ)
    public async Task<decimal> GetAveragePriceAsync()
    {
        var hasProducts = await _context.Products.AnyAsync();
        if (!hasProducts)
            return 0;
            
        return await _context.Products
            .Select(p => p.Price)
            .AverageAsync();
    }

    // Ejercicio 8: Obtener productos sin descripción (usando LINQ)
    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }

    // Ejercicio 11: Obtener productos vendidos por un cliente específico (usando LINQ)
    public async Task<IEnumerable<Product>> GetProductsByClientIdAsync(int clientId)
    {
        return await _context.Orderdetails
            .Where(od => od.Order.ClientId == clientId)
            .Select(od => od.Product)
            .Distinct()
            .ToListAsync();
    }
}