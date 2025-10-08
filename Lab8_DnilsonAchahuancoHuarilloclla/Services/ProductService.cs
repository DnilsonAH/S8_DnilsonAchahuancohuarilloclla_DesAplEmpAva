using Lab8_DnilsonAchahuancoHuarilloclla.Data;
using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;
using Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProductDto>> GetByPriceGreaterThanAsync(decimal price)
    {
        var products = await _unitOfWork.Products.GetByPriceGreaterThanAsync(price);
        return products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        });
    }

    public async Task<ProductDto?> GetMostExpensiveAsync()
    {
        var product = await _unitOfWork.Products.GetMostExpensiveAsync();
        if (product == null) return null;

        return new ProductDto
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }

    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _unitOfWork.Products.GetAveragePriceAsync();
    }

    public async Task<IEnumerable<ProductDto>> GetProductsWithoutDescriptionAsync()
    {
        var products = await _unitOfWork.Products.GetProductsWithoutDescriptionAsync();
        return products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        });
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByClientIdAsync(int clientId)
    {
        var products = await _unitOfWork.Products.GetProductsByClientIdAsync(clientId);
        return products.Select(p => new ProductDto
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price
        });
    }
}