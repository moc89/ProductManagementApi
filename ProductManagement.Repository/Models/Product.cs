using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Repository.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
        
    [StringLength(100)]  // Limit the length to 100 characters
    public string?  Category { get; set; }
        
    [StringLength(100)]  // Limit the length to 100 characters
    public string? Name { get; set; }
        
    [StringLength(100)]  // Limit the length to 100 characters
    public  string? ProductCode { get; set; }
    
    public  decimal Price { get; set; }
    
    [StringLength(100)]  // Limit the length to 100 characters
    public  string? SKU { get; set; }
        
    public  int StockQuantity { get; set; }
        
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;
}