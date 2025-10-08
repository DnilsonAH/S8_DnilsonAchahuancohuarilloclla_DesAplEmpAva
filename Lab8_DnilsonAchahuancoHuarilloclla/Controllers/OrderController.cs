using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;
using Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("after-date/{date}")]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersAfterDate(DateTime date)
    {
        var orders = await _orderService.GetOrdersAfterDateAsync(date);
        return Ok(orders);
    }

    [HttpGet("with-details")]
    public async Task<ActionResult<IEnumerable<OrderWithDetailsDto>>> GetAllOrdersWithDetails()
    {
        var orders = await _orderService.GetAllOrdersWithDetailsAsync();
        return Ok(orders);
    }

    [HttpGet("{orderId:int}/products")]
    public async Task<ActionResult<IEnumerable<ProductInOrderDto>>> GetProductsInOrder(int orderId)
    {
        var products = await _orderService.GetProductsInOrderAsync(orderId);
        return Ok(products);
    }

    [HttpGet("{orderId:int}/total-quantity")]
    public async Task<ActionResult<int>> GetTotalQuantity(int orderId)
    {
        var quantity = await _orderService.GetTotalQuantityByOrderIdAsync(orderId);
        return Ok(quantity);
    }
}
