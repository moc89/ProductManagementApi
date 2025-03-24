using Microsoft.AspNetCore.Mvc;
using ProductManagement.Services.Dtos;
using ProductManagement.Services.Interfaces;

namespace ProductManagement.Controllers;

[ApiController]
[Route("api/product")]
public class ProductManagementController: ControllerBase
{
    private readonly IProductService _productManagementService;

    public ProductManagementController(IProductService productManagementService)
    {
        _productManagementService = productManagementService;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        try
        {
            var products = await _productManagementService.GetProducts();
            return Ok(products);
        }
        catch (Exception ex)
        {
            // Log the error (Consider using a logging framework like Serilog)
            Console.WriteLine($"Error: {ex.Message}");
            return StatusCode(500, "An error occurred while retrieving products.");
        }
    }
    
    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<bool>> CreateProduct(ProductDto product)
    {
        try
        {
            var isCreated = await _productManagementService.CreateProduct(product);
            return Ok(isCreated);
        }
        catch (Exception ex)
        {
            // Log the error (Consider using a logging framework like Serilog)
            Console.WriteLine($"Error: {ex.Message}");
            return StatusCode(500, "An error occurred while creating product.");
        }
    }
    
    // GET: api/products
    [Route("report")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetMockReport()
    {
        try
        {
            var products = await _productManagementService.GetMockReport();
            return Ok(products);
        }
        catch (Exception ex)
        {
            // Log the error (Consider using a logging framework like Serilog)
            Console.WriteLine($"Error: {ex.Message}");
            return StatusCode(500, "An error occurred while retrieving products.");
        }
    }
}