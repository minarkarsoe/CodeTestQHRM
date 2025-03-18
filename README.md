# CodeTestQHRM

# Product Management Web Application

This is a simple web application built with ASP.NET Core and Dapper. It allows users to manage a list of products, with basic CRUD (Create, Read, Update, Delete) functionality.

## Features

- List all products
- Add a new product
- Edit an existing product
- Delete a product

## Requirements

- .NET Core SDK
- SQL Server Database
- Dapper

## Setup Instructions

1. Clone the repository.
   ```bash
   git clone https://github.com/minarkarsoe/CodeTestQHRM.git
   cd CodeTestQHRM
2.	Create a SQL Server database and run the following SQL script to create the Products table:
CREATE TABLE Products (
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar(100) NOT NULL,
	Description nvarchar(255) NOT NULL,
	CreatedDate datetime NULL,
	UpdatedDate datetime NULL
	)

Update the connection string in appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=QHRM;Trusted_Connection=True;"
}
Build and run the application:
dotnet build
dotnet run
