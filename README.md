
Product Management API

Overview

The Product Management API is a RESTful web service built with ASP.NET Core that allows clients to manage product data. It provides endpoints for retrieving product lists, creating new products, and generating mock reports.

Technologies Used

ASP.NET Core for building the API

C# for backend development

Microsoft.AspNetCore.Mvc for API controllers

Dependency Injection for managing services

Task-based Asynchronous Pattern (TAP) for asynchronous operations

Logging (Console Logging as a placeholder, recommended: Serilog)

Endpoints

1. Get All Products

GET /api/product

Response:

200 OK: Returns a list of products.

500 Internal Server Error: If an error occurs.

2. Create a Product

POST /api/product

Request Body:

{
    "id": 1,
    "name": "Product Name",
    "price": 100.00
}

Response:

200 OK: Returns true if the product was created successfully.

500 Internal Server Error: If an error occurs.

3. Get Mock Report

GET /api/product/report

Response:

200 OK: Returns a mock product report.

500 Internal Server Error: If an error occurs.

Setup & Installation

Prerequisites

.NET SDK (latest version recommended)

An IDE like Visual Studio, Visual Studio Code, or JetBrains Rider

Steps to Run

Clone the repository:

git clone https://github.com/your-repo-url.git

Navigate to the project folder:

cd ProductManagement

Restore dependencies:

dotnet restore

Run the application:

dotnet run

The API will be available at https://localhost:5001/api/product

Improvements & Next Steps

Implement proper logging with Serilog or another logging provider.

Add Unit Tests for the controller and service layers.

Use Swagger for API documentation.

Implement a database (e.g., SQL Server, PostgreSQL) for persistent data storage.

License

This project is open-source and available under the MIT License.
