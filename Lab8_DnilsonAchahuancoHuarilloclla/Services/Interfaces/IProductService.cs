using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetByPriceGreaterThanAsync(decimal price);
    Task<ProductDto?> GetMostExpensiveAsync();
    Task<decimal> GetAveragePriceAsync();
    Task<IEnumerable<ProductDto>> GetProductsWithoutDescriptionAsync();
    Task<IEnumerable<ProductDto>> GetProductsByClientIdAsync(int clientId);
}