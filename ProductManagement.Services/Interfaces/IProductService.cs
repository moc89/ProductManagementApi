using ProductManagement.Services.Dtos;

namespace ProductManagement.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<bool> CreateProduct(ProductDto productDto);
    Task<IEnumerable<ProductDto>> GetMockReport();
} 