using Microsoft.Extensions.Logging;
using ProductManagement.Repository.Interfaces;
using ProductManagement.Repository.Models;
using ProductManagement.Services.Dtos;
using ProductManagement.Services.Interfaces;

namespace ProductManagement.Services.Services;

public class ProductService:IProductService
{
    private readonly ILogger<ProductService> _logger;
    private readonly IProductRepository _productRepository;

    public ProductService( ILogger<ProductService> logger, IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    
    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        try
        {
            _logger.LogInformation("Fetching all products");

            // Get product list
            var products = await _productRepository.GetProductsAsync();

            IEnumerable<ProductDto> productsResponse = products.Select(p => new ProductDto()
            {
                Category = p.Category, Name = p.Name, Price = p.Price, ProductCode = p.ProductCode,
                StockQuantity = p.StockQuantity, SKU = p.SKU, Id = p.Id, DateAdded = p.DateAdded
            });

            return productsResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching products.");
            // Note: We can create our own exception class and throw meaningful message here
            throw;
        }
    }

    public async Task<bool> CreateProduct(ProductDto productDto)
    {
        try
        {
            _logger.LogInformation("Create a product...");

            if(productDto is null) 
                throw new ArgumentNullException(nameof(productDto));

            var product = new Product()
            {
                Category = productDto.Category,
                Name = productDto.Name,
                Price = productDto.Price,
                ProductCode = productDto.ProductCode,
                StockQuantity = productDto.StockQuantity,
                SKU = productDto.SKU,
                DateAdded = productDto.DateAdded
            };
            
            // Create product,
            var isCreated = await _productRepository.CreateProduct(product);

            return isCreated;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating product.");
            return false;   
        }
    }

    public async Task<IEnumerable<ProductDto>> GetMockReport()
    {
        try
        {
            _logger.LogInformation("Fetching all products");

            // Get product list
            var products = await _productRepository.GetMockReportAsync();

            IEnumerable<ProductDto> productsResponse = products.Select(p => new ProductDto()
            {
                Category = p.Category, Name = p.Name, Price = p.Price, ProductCode = p.ProductCode,
                StockQuantity = p.StockQuantity, SKU = p.SKU, Id = p.Id, DateAdded = p.DateAdded
            });

            return productsResponse;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while fetching products.");
            // Note: We can create our own exception class and throw meaningful message here
            throw;
        }
    }
}