namespace Lab8_DnilsonAchahuancoHuarilloclla.DTOs;

public class CreateCompleteOrderDto
{
    public int ClientId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItemDto> Items { get; set; } = new();
}

public class OrderItemDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class CompleteOrderResponseDto
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public string ClientName { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public int TotalItems { get; set; }
    public decimal TotalAmount { get; set; }
    public List<ProductInOrderDto> Products { get; set; } = new();
    public string Message { get; set; } = "Orden creada exitosamente";
}