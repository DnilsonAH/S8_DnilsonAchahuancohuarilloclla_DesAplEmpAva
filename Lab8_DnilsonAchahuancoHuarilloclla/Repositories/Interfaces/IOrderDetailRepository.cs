using Lab8_DnilsonAchahuancoHuarilloclla.Models;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Repositories.Interfaces;

public interface IOrderDetailRepository
{
    Task<IEnumerable<Orderdetail>> GetAllAsync();
    Task<Orderdetail?> GetByIdAsync(int id);
    Task<IEnumerable<Orderdetail>> GetByOrderIdAsync(int orderId);
    Task<int> GetTotalQuantityByOrderIdAsync(int orderId);
    Task<Orderdetail> AddAsync(Orderdetail orderDetail);
    Task UpdateAsync(Orderdetail orderDetail);
    Task DeleteAsync(int id);
}