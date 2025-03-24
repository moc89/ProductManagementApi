using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Services.Dtos;

public class ProductDto
{
    [Key]
    public int Id { get; set; }
        
    public required string Category { get; set; }
        
    public required string Name { get; set; }
        
    public required string ProductCode { get; set; }
    
    public required decimal Price { get; set; }
    
    public required string SKU { get; set; }
        
    public required int StockQuantity { get; set; }
        
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
}