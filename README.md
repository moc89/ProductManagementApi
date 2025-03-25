# Product Management API

## Overview
The **Product Management API** is a RESTful web service built with .NET9 that allows clients to manage product data. It provides endpoints for retrieving product lists, creating new products, and generating mock reports.

## Technologies Used
- **.NET 9** for building the API (.NET Core 3.1 has reached end-of-life (EOL) as of December 13, 2022 and is no longer officially available for download from Microsoft. And .NET Core has been rebranded to just .NET since .NET 5. So, this project needs the latest .NET SDK instead.)
- **C#** for backend development
- **Swagger** for API documentation.
- **Dependency Injection** for managing services
- **Task-based Asynchronous Pattern (TAP)** for asynchronous operations
- **Logging (Console Logging as a placeholder, recommended: Serilog)**

## Endpoints

### 1. Get All Products
**GET** `/api/product`
#### Response:
- **200 OK**: Returns a list of products.
- **500 Internal Server Error**: If an error occurs.

### 2. Create a Product
**POST** `/api/product`
#### Request Body:
```json
{
        "id": 1,
        "category": "Electronics",
        "name": "Wireless Headphones",
        "productCode": "WH1000XM4",
        "price": 299.99,
        "sku": "ELEC-12345",
        "stockQuantity": 50,
        "dateAdded": "2025-03-15T16:04:29.154556Z"
    },
```
#### Response:
- **200 OK**: Returns `true` if the product was created successfully.
- **500 Internal Server Error**: If an error occurs.

### 3. Get Mock Report
**GET** `/api/product/report`
#### Response:
- **200 OK**: Returns a mock product report.
- **500 Internal Server Error**: If an error occurs.

## Setup & Installation

### Prerequisites
- .NET SDK (latest version recommended)
- An IDE like Visual Studio, Visual Studio Code, or JetBrains Rider

### Steps to Run
1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo-url.git
   ```
2. Navigate to the project folder:
   ```sh
   cd ProductManagement
   ```
3. Restore dependencies:
   ```sh
   dotnet restore
   ```
4. Run the application:
   ```sh
   dotnet run
   ```
5. The API will be available at `https://localhost:5001/api/product`

## Improvements & Next Steps
- Implement proper logging with **Serilog** or another logging provider.
- Add **Unit Tests** service layers.
- Implement a database (e.g., **SQL Server, PostgreSQL**) for persistent data storage.

## License
This project is open-source and available under the MIT License.
