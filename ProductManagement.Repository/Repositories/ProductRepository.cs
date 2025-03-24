using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.Interfaces;
using ProductManagement.Repository.Models;

namespace ProductManagement.Repository.Repositories;

public class ProductRepository: ProductContextAppDbContext, IProductRepository
{
    private readonly ProductContextAppDbContext _context;

    public ProductRepository(ProductContextAppDbContext context) : base(options: new DbContextOptions<ProductContextAppDbContext>())
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        try
        {
            return await _context.Products.ToListAsync();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // Return default error product
            return new List<Product>
            {
                new Product { Name = "Error", Price = 0, Category = "Unknown" }
            };
        }
    }

    public async Task<bool> CreateProduct(Product product)
    {
        try
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<IEnumerable<Product>> GetMockReportAsync()
    {
        try
        {
            var mock = GetMockProducts();

            _context.Products.RemoveRange(_context.Products);
            await _context.Products.AddRangeAsync((mock));
            await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<Product>
            {
                new Product { Name = "Error", Price = 0, Category = "Unknown" }
            };
        }
    }
    
    
public List<Product> GetMockProducts()
{
    return new List<Product>
    {
        new Product
        {
            Id = 1,
            Category = "Electronics",
            Name = "Wireless Headphones",
            ProductCode = "WH1000XM4",
            Price = 299.99m,
            SKU = "ELEC-12345",
            StockQuantity = 50,
            DateAdded = DateTime.UtcNow.AddDays(-10)
        },
        new Product
        {
            Id = 2,
            Category = "Electronics",
            Name = "Smartphone",
            ProductCode = "GALAXYS23",
            Price = 899.99m,
            SKU = "ELEC-67890",
            StockQuantity = 30,
            DateAdded = DateTime.UtcNow.AddDays(-5)
        },
        new Product
        {
            Id = 3,
            Category = "Home Appliances",
            Name = "Air Fryer",
            ProductCode = "AF-2023",
            Price = 129.99m,
            SKU = "HOME-11122",
            StockQuantity = 20,
            DateAdded = DateTime.UtcNow.AddDays(-15)
        },
        new Product
        {
            Id = 4,
            Category = "Furniture",
            Name = "Office Chair",
            ProductCode = "CHAIR-001",
            Price = 149.99m,
            SKU = "FURN-54321",
            StockQuantity = 40,
            DateAdded = DateTime.UtcNow.AddDays(-30)
        },
        new Product
        {
            Id = 5,
            Category = "Gaming",
            Name = "Gaming Laptop",
            ProductCode = "GL-RTX4080",
            Price = 1999.99m,
            SKU = "GAME-98765",
            StockQuantity = 10,
            DateAdded = DateTime.UtcNow.AddDays(-7)
        }
    };
}
}

