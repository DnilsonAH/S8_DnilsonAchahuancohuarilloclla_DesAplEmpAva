using Lab8_DnilsonAchahuancoHuarilloclla.Data;
using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;
using Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;
using System.Linq;
namespace Lab8_DnilsonAchahuancoHuarilloclla.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OrderDto>> GetOrdersAfterDateAsync(DateTime date)
    {
        var orders = await _unitOfWork.Orders.GetOrdersAfterDateAsync(date);
        return orders.Select(o => new OrderDto
        {
            OrderId = o.OrderId,
            ClientId = o.ClientId,
            OrderDate = o.OrderDate,
            ClientName = o.Client?.Name ?? "Cliente no encontrado"
        });
    }

    public async Task<IEnumerable<OrderWithDetailsDto>> GetAllOrdersWithDetailsAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllWithDetailsAsync();
        return orders.Select(o => new OrderWithDetailsDto
        {
            OrderId = o.OrderId,
            ClientName = o.Client?.Name ?? "Cliente no encontrado",
            OrderDate = o.OrderDate,
            Details = o.Orderdetails.Select(od => new OrderDetailDto
            {
                ProductId = od.ProductId,
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            }).ToList()
        });
    }

    public async Task<IEnumerable<ProductInOrderDto>> GetProductsInOrderAsync(int orderId)
    {
        var orderDetails = await _unitOfWork.OrderDetails.GetByOrderIdAsync(orderId);
        return orderDetails.Select(od => new ProductInOrderDto
        {
            ProductName = od.Product.Name,
            Quantity = od.Quantity
        });
    }

    public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        return await _unitOfWork.OrderDetails.GetTotalQuantityByOrderIdAsync(orderId);
    }
}
