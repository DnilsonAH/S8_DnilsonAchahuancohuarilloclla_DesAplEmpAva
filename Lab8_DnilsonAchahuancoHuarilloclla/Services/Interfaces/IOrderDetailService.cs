using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;

public interface IOrderDetailService
{
    Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync();
    Task<OrderDetailDto?> GetOrderDetailByIdAsync(int id);
    Task<OrderDetailDto> CreateOrderDetailAsync(CreateOrderDetailDto createOrderDetailDto);
    Task UpdateOrderDetailAsync(int id, UpdateOrderDetailDto updateOrderDetailDto);
    Task DeleteOrderDetailAsync(int id);
    Task<IEnumerable<OrderDetailDto>> GetByOrderIdAsync(int orderId);
    Task<decimal> GetTotalAmountByOrderIdAsync(int orderId);
    Task<int> GetTotalQuantityByOrderIdAsync(int orderId);
    Task<IEnumerable<OrderDetailDto>> GetByProductIdAsync(int productId);
}