namespace Lab8_DnilsonAchahuancoHuarilloclla.DTOs;

public class OrderDto
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public string ClientName { get; set; } = null!;
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

public partial class OrderWithDetailsDto
{
    public int OrderId { get; set; }
    public string ClientName { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderDetailDto> Details { get; set; } = new List<OrderDetailDto>();
}