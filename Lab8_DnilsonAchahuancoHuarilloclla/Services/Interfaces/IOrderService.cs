using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetOrdersAfterDateAsync(DateTime date);
    Task<IEnumerable<OrderWithDetailsDto>> GetAllOrdersWithDetailsAsync();
    Task<IEnumerable<ProductInOrderDto>> GetProductsInOrderAsync(int orderId);
    Task<int> GetTotalQuantityByOrderIdAsync(int orderId);
}