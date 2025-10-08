using Lab8_DnilsonAchahuancoHuarilloclla.DTOs;
using Lab8_DnilsonAchahuancoHuarilloclla.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("price-greater-than/{price:decimal}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetByPriceGreaterThan(decimal price)
    {
        var products = await _productService.GetByPriceGreaterThanAsync(price);
        return Ok(products);
    }

    [HttpGet("most-expensive")]
    public async Task<ActionResult<ProductDto>> GetMostExpensive()
    {
        var product = await _productService.GetMostExpensiveAsync();
        if (product == null)
            return NotFound();
        return Ok(product);
    }

    [HttpGet("average-price")]
    public async Task<ActionResult<decimal>> GetAveragePrice()
    {
        var averagePrice = await _productService.GetAveragePriceAsync();
        return Ok(averagePrice);
    }

    [HttpGet("without-description")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsWithoutDescription()
    {
        var products = await _productService.GetProductsWithoutDescriptionAsync();
        return Ok(products);
    }

    [HttpGet("by-client/{clientId:int}")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByClient(int clientId)
    {
        var products = await _productService.GetProductsByClientIdAsync(clientId);
        return Ok(products);
    }
}
