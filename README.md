# Inventory Management System

## Overview

This is a simple full-stack Inventory Management System where users can add, view, update, and delete products from an inventory. The backend is built with .NET 9 and the frontend is developed using Angular.

## Features

### Backend (.NET 9)

- RESTful API with CRUD operations:
  - `GET /products` — Retrieve all products
  - `POST /products` — Add a new product
  - `GET /products/{id}` — Get product details by ID
  - `PUT /products/{id}` — Update product by ID
  - `DELETE /products/{id}` — Delete product by ID
- Data storage using SQL Server
- Pagination and filtering support on product list (by name and category)

### Frontend (Angular)

- Table view of all products
- Form for adding and editing products
- Delete product functionality
- Basic form validation (required fields, price ≥ 0, quantity ≥ 0)

## Technologies Used

- Backend: .NET 9, Entity Framework Core, SQL Server
- Frontend: Angular, TypeScript, RxJS, HTML, CSS

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Node.js and npm](https://nodejs.org/en/download/)
- SQL Server
- Angular CLI (optional, for frontend development)

```bash
npm install -g @angular/cli
```
## Setup Instructions

### Backend Setup

Clone the repository:

```bash
git clone https://github.com/VasilevaSimona/InventoryManagement.git
```
### Navigate to the backend project folder :
```bash
cd InventoryManagement
```
Configure the database connection string in appsettings.json
Apply migrations to create the database schema:
```bash
dotnet ef database update
```
### Run the backend API server.

### You can access the backend Swagger UI for testing and API exploration here:

https://localhost:44324/swagger/index.html

### Frontend Setup
### Navigate to the frontend project folder:

```bash
cd InventoryManagement-frontend
```
Install frontend dependencies:

```bash
npm install
```
### Start the Angular development server:

```bash
ng serve
```
### Open your browser and navigate to:

http://localhost:4200

### Usage
After starting both backend and frontend servers, you can use the Angular app to manage products via the user interface.
Alternatively, you can test backend API endpoints directly using the Swagger UI.


