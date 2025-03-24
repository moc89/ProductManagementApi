using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository.Models;

namespace ProductManagement.Repository;

public class ProductContextAppDbContext : DbContext
{
    public ProductContextAppDbContext(DbContextOptions<ProductContextAppDbContext> options)
        : base(options)
    { }
    public DbSet<Product> Products { get; set; }
    
}