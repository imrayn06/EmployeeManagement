# Employee Management System API

## Overview

This is a RESTful API built using .NET 9, designed to manage employee data in an organization. It supports CRUD operations, follows SOLID principles, and includes JWT authentication for secure access.

## Features

- **CRUD Operations**: Create, Read, Update, Delete employees.
- **Authentication**: JWT-based authentication for securing endpoints.
- **Entity Framework Core**: SQL database integration with EF Core.
- **Dependency Injection**: Modular architecture for maintainability.
- **SOLID Principles**: Ensures a scalable and maintainable codebase.
- **Swagger Documentation**: Auto-generated API documentation.

## Technologies Used

- .NET 9 Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger (Swashbuckle)

## Project Structure

```
EmployeeManagementAPI/
│-- Controllers/        # API Controllers
│-- EmployeeServices/           # Business Logic Layer
│-- EmployeesRepositories/       # Data Access Layer
│-- EmployeeModels/             # Data Models
│-- DTOs/               # Data Transfer Objects (optional)
│-- Data/               # DbContext and Migrations
│-- Program.cs          # Application Entry Point
│-- appsettings.json    # Configuration Settings
```

## Installation

### Prerequisites

Ensure you have the following installed:

- .NET 9 SDK
- SQL Server 
- Entity Framework Core

### Setup Instructions

Clone the repository:

```sh
git clone https://github.com/imrayn06/Employee_management
cd EmployeeManagementAPI
```

Install required dependencies:

```sh
dotnet restore
```

Add EF Core design package:

```sh
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Apply Migrations:

```sh
dotnet ef migrations add InitialCreate
```

```sh
dotnet ef database update
```

Run the API:

```sh
dotnet run
```

Open Swagger UI at:

```
http://localhost:5103/swagger/index.html
```

## API Endpoints

### Authentication

- **POST** `/api/Auth/login` - Authenticate and get JWT token

### Employee Management

- **GET** `/api/Employees` - Get all Employees
- **POST** `/api/Employees` - Create a new employee
- **PUT** `/api/Employees/{id}` - Update an employee
- **DELETE** `/api/Employees/{id}` - Delete an employee
