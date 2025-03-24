using Microsoft.EntityFrameworkCore;
using ProductManagement.Repository;
using ProductManagement.Repository.Interfaces;
using ProductManagement.Repository.Repositories;
using ProductManagement.Services.Interfaces;
using ProductManagement.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Register the DbContext to use In-Memory Database
builder.Services.AddDbContext<ProductContextAppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        corsBuilder => corsBuilder.WithOrigins("http://localhost:5173") 
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.MapControllers(); // This ensures your controllers are correctly mapped to routes
app.UseCors("AllowSpecificOrigin");

app.Run();

