using ProductManagement.Repository.Models;

namespace ProductManagement.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<bool> CreateProduct(Product product);
        Task<IEnumerable<Product>> GetMockReportAsync();
    }
}