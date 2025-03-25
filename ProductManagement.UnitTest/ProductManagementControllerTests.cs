using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductManagement.Controllers;
using ProductManagement.Services.Dtos;
using ProductManagement.Services.Interfaces;

namespace ProductManagement.UnitTest;

public class ProductManagementControllerTests
{
    private readonly Mock<IProductService> _mockService;
    private readonly ProductManagementController _controller;

    public ProductManagementControllerTests()
    {
        _mockService = new Mock<IProductService>();
        _controller = new ProductManagementController(_mockService.Object);
    }
    
    [Fact]
    public async Task GetProducts_ReturnsOkResult_WithProductList()
    {
        // Arrange
        var mockProducts = new List<ProductDto>
        {
            new ProductDto { Id = 1, Name = "Product 1", Category = "Category 1", ProductCode = "123", Price = 123, StockQuantity = 123, SKU = "123" },
            new ProductDto { Id = 2, Name = "Product 2", Category = "Category 2", ProductCode = "123", Price = 123, StockQuantity = 123, SKU = "123" }
        };
        
        _mockService.Setup(service => service.GetProducts()).ReturnsAsync(mockProducts);

        // Act
        var result = await _controller.GetProducts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnValue = Assert.IsType<List<ProductDto>>(okResult.Value);
        Assert.Equal(2, returnValue.Count);
    }
    
    [Fact]
    public async Task GetProducts_Returns500_WhenExceptionOccurs()
    {
        // Arrange
        _mockService.Setup(service => service.GetProducts()).ThrowsAsync(new Exception("Database error"));

        // Act
        var result = await _controller.GetProducts();

        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
        Assert.Equal(500, statusCodeResult.StatusCode);
        Assert.Equal("An error occurred while retrieving products.", statusCodeResult.Value);
    }
}