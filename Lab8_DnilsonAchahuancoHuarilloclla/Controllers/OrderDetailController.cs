using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;
using Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController : ControllerBase
{
    private readonly IOrderDetailService _orderDetailService;

    public OrderDetailController(IOrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetAll()
    {
        var orderDetails = await _orderDetailService.GetAllOrderDetailsAsync();
        return Ok(orderDetails);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<OrderDetailDto>> GetById(int id)
    {
        var orderDetail = await _orderDetailService.GetOrderDetailByIdAsync(id);
        if (orderDetail == null)
            return NotFound();
        return Ok(orderDetail);
    }

    [HttpPost]
    public async Task<ActionResult<OrderDetailDto>> Create(CreateOrderDetailDto createOrderDetailDto)
    {
        var createdOrderDetail = await _orderDetailService.CreateOrderDetailAsync(createOrderDetailDto);
        return CreatedAtAction(nameof(GetById), new { id = createdOrderDetail.OrderDetailId }, createdOrderDetail);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateOrderDetailDto updateOrderDetailDto)
    {
        try
        {
            await _orderDetailService.UpdateOrderDetailAsync(id, updateOrderDetailDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _orderDetailService.DeleteOrderDetailAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet("by-order/{orderId:int}")]
    public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetByOrderId(int orderId)
    {
        var orderDetails = await _orderDetailService.GetByOrderIdAsync(orderId);
        return Ok(orderDetails);
    }

    [HttpGet("order/{orderId:int}/total-amount")]
    public async Task<ActionResult<decimal>> GetTotalAmountByOrder(int orderId)
    {
        var totalAmount = await _orderDetailService.GetTotalAmountByOrderIdAsync(orderId);
        return Ok(totalAmount);
    }

    [HttpGet("order/{orderId:int}/total-quantity")]
    public async Task<ActionResult<int>> GetTotalQuantityByOrder(int orderId)
    {
        var totalQuantity = await _orderDetailService.GetTotalQuantityByOrderIdAsync(orderId);
        return Ok(totalQuantity);
    }

    [HttpGet("by-product/{productId:int}")]
    public async Task<ActionResult<IEnumerable<OrderDetailDto>>> GetByProductId(int productId)
    {
        var orderDetails = await _orderDetailService.GetByProductIdAsync(productId);
        return Ok(orderDetails);
    }
}
