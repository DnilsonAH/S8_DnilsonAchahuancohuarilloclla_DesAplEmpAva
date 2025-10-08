using Lab8_DnilsonAchahuancoHuarilloclla.Data;
using Lab8_DnilsonAchahuancoHuarilloclla.Models;
using Lab8_DnilsonAchahuancoHuarilloclla.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Repositories;

public class OrderDetailRepository : IOrderDetailRepository
{
    private readonly LinqExampleContext _context;

    public OrderDetailRepository(LinqExampleContext context)
    {
        _context = context;
    }

    // CRUD Básico
    public async Task<IEnumerable<Orderdetail>> GetAllAsync()
    {
        return await _context.Orderdetails
            .Include(od => od.Product)
            .Include(od => od.Order)
                .ThenInclude(o => o.Client)
            .ToListAsync();
    }

    public async Task<Orderdetail?> GetByIdAsync(int id)
    {
        return await _context.Orderdetails
            .Include(od => od.Product)
            .Include(od => od.Order)
                .ThenInclude(o => o.Client)
            .FirstOrDefaultAsync(od => od.OrderDetailId == id);
    }

    public async Task<Orderdetail> AddAsync(Orderdetail orderDetail)
    {
        await _context.Orderdetails.AddAsync(orderDetail);
        return orderDetail;
    }

    public async Task UpdateAsync(Orderdetail orderDetail)
    {
        _context.Orderdetails.Update(orderDetail);
    }

    public async Task DeleteAsync(int id)
    {
        var orderDetail = await _context.Orderdetails.FindAsync(id);
        if (orderDetail != null)
        {
            _context.Orderdetails.Remove(orderDetail);
        }
    }

    // Ejercicio 3: Obtener detalles de productos en una orden (usando LINQ)
    public async Task<IEnumerable<Orderdetail>> GetByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .Include(od => od.Product)
            .ToListAsync();
    }

    // Ejercicio 4: Obtener cantidad total de productos por orden (usando LINQ)
    public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        var hasDetails = await _context.Orderdetails.AnyAsync(od => od.OrderId == orderId);
        if (!hasDetails)
            return 0;
            
        return await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .Select(od => od.Quantity)
            .SumAsync();
    }

    // Ejercicio 10: Todos los pedidos con detalles (usando LINQ)
    public async Task<IEnumerable<Orderdetail>> GetAllWithProductsAsync()
    {
        return await _context.Orderdetails
            .Include(od => od.Product)
            .Include(od => od.Order)
                .ThenInclude(o => o.Client)
            .ToListAsync();
    }

    public async Task<decimal> GetTotalAmountByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Include(od => od.Product)
            .Where(od => od.OrderId == orderId)
            .SumAsync(od => od.Quantity * od.Product.Price);
    }

    public async Task<IEnumerable<Orderdetail>> GetByProductIdAsync(int productId)
    {
        return await _context.Orderdetails
            .Include(od => od.Product)
            .Include(od => od.Order)
            .Where(od => od.ProductId == productId)
            .ToListAsync();
    }
}