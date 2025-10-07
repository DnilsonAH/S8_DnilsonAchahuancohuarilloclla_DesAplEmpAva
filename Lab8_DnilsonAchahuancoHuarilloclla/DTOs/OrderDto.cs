namespace Lab8_DnilsonAchahuancoHuarilloclla.DTOs;

public class OrderDto
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public string? ClientName { get; set; }
    public DateTime OrderDate { get; set; }
}

public class CreateOrderDto
{
    public int ClientId { get; set; }
    public DateTime OrderDate { get; set; }
}

public class UpdateOrderDto
{
    public int ClientId { get; set; }
    public DateTime OrderDate { get; set; }
}

public class OrderWithDetailsDto
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public string ClientName { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public List<ProductInOrderDto> Products { get; set; } = new();
       public int TotalQuantity { get; set; }
    public decimal TotalAmount { get; set; }
}