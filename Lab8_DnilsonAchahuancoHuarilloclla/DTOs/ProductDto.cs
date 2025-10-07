namespace Lab8_DnilsonAchahuancoHuarilloclla.DTOs;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

public class CreateProductDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

public class UpdateProductDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

public class ProductInOrderDto
{
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
}

public class ProductWithDetailsDto
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int TotalSold { get; set; }
}