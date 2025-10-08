using Lab8_DnilsonAchahuancoHuarilloclla.Data;
using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;
using Lab8_DnilsonAchahuancoHuarilloclla.Models;
using Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Services;

public class OrderDetailService : IOrderDetailService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderDetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OrderDetailDto>> GetAllOrderDetailsAsync()
    {
        var orderDetails = await _unitOfWork.OrderDetails.GetAllAsync();
        return orderDetails.Select(od => new OrderDetailDto
        {
            OrderDetailId = od.OrderDetailId,
            OrderId = od.OrderId,
            ProductId = od.ProductId,
            ProductName = od.Product.Name,
            Quantity = od.Quantity,
            UnitPrice = od.Product.Price
        });
    }

    public async Task<OrderDetailDto?> GetOrderDetailByIdAsync(int id)
    {
        var orderDetail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
        if (orderDetail == null) return null;

        return new OrderDetailDto
        {
            OrderDetailId = orderDetail.OrderDetailId,
            OrderId = orderDetail.OrderId,
            ProductId = orderDetail.ProductId,
            ProductName = orderDetail.Product.Name,
            Quantity = orderDetail.Quantity,
            UnitPrice = orderDetail.Product.Price
        };
    }

    public async Task<OrderDetailDto> CreateOrderDetailAsync(CreateOrderDetailDto createOrderDetailDto)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(createOrderDetailDto.ProductId);
        if (product == null)
            throw new KeyNotFoundException($"Producto con ID {createOrderDetailDto.ProductId} no encontrado");

        var orderDetail = new Orderdetail
        {
            OrderId = createOrderDetailDto.OrderId,
            ProductId = createOrderDetailDto.ProductId,
            Quantity = createOrderDetailDto.Quantity
        };

        await _unitOfWork.OrderDetails.AddAsync(orderDetail);
        await _unitOfWork.SaveChangesAsync();

        return new OrderDetailDto
        {
            OrderDetailId = orderDetail.OrderDetailId,
            OrderId = orderDetail.OrderId,
            ProductId = orderDetail.ProductId,
            ProductName = product.Name,
            Quantity = orderDetail.Quantity,
            UnitPrice = product.Price
        };
    }

    public async Task UpdateOrderDetailAsync(int id, UpdateOrderDetailDto updateOrderDetailDto)
    {
        var orderDetail = await _unitOfWork.OrderDetails.GetByIdAsync(id);
        if (orderDetail == null)
            throw new KeyNotFoundException($"Detalle de orden con ID {id} no encontrado");

        var product = await _unitOfWork.Products.GetByIdAsync(updateOrderDetailDto.ProductId);
        if (product == null)
            throw new KeyNotFoundException($"Producto con ID {updateOrderDetailDto.ProductId} no encontrado");

        orderDetail.ProductId = updateOrderDetailDto.ProductId;
        orderDetail.Quantity = updateOrderDetailDto.Quantity;

        await _unitOfWork.OrderDetails.UpdateAsync(orderDetail);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteOrderDetailAsync(int id)
    {
        await _unitOfWork.OrderDetails.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderDetailDto>> GetByOrderIdAsync(int orderId)
    {
        var orderDetails = await _unitOfWork.OrderDetails.GetByOrderIdAsync(orderId);
        return orderDetails.Select(od => new OrderDetailDto
        {
            OrderDetailId = od.OrderDetailId,
            OrderId = od.OrderId,
            ProductId = od.ProductId,
            ProductName = od.Product.Name,
            Quantity = od.Quantity,
            UnitPrice = od.Product.Price
        });
    }

    public async Task<decimal> GetTotalAmountByOrderIdAsync(int orderId)
    {
        return await _unitOfWork.OrderDetails.GetTotalAmountByOrderIdAsync(orderId);
    }

    public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        return await _unitOfWork.OrderDetails.GetTotalQuantityByOrderIdAsync(orderId);
    }

    public async Task<IEnumerable<OrderDetailDto>> GetByProductIdAsync(int productId)
    {
        var orderDetails = await _unitOfWork.OrderDetails.GetByProductIdAsync(productId);
        return orderDetails.Select(od => new OrderDetailDto
        {
            OrderDetailId = od.OrderDetailId,
            OrderId = od.OrderId,
            ProductId = od.ProductId,
            ProductName = od.Product.Name,
            Quantity = od.Quantity,
            UnitPrice = od.Product.Price
        });
    }
}