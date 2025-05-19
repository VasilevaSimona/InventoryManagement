<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <title>Inventory Management System - README</title>
</head>
<body>
  <div class="container">
    <h1>Inventory Management System</h1>

    <h2>Overview</h2>
    <p>This is a simple full-stack Inventory Management System where users can add, view, update, and delete products from an inventory. The backend is built with .NET 9 and the frontend is developed using Angular.</p>

    <h2>Features</h2>

    <h3>Backend (.NET 9)</h3>
    <ul>
      <li>RESTful API with CRUD operations:
        <ul>
          <li><code>GET /products</code> — Retrieve all products</li>
          <li><code>POST /products</code> — Add a new product</li>
          <li><code>GET /products/{id}</code> — Get product details by ID</li>
          <li><code>PUT /products/{id}</code> — Update product by ID</li>
          <li><code>DELETE /products/{id}</code> — Delete product by ID</li>
        </ul>
      </li>
      <li>Data storage using SQL Server</li>
      <li>Pagination and filtering support on product list (by name and category)</li>
    </ul>

    <h3>Frontend (Angular)</h3>
    <ul>
      <li>Table view of all products</li>
      <li>Form for adding and editing products</li>
      <li>Delete product functionality</li>
      <li>Basic form validation (required fields, price ≥ 0, quantity ≥ 0)</li>
  
    </ul>

    <h2>Technologies Used</h2>
    <ul>
      <li>Backend: .NET 9, Entity Framework Core, SQL Server</li>
      <li>Frontend: Angular, TypeScript, RxJS, HTML, CSS</li>
    </ul>

    <h2>Getting Started</h2>

    <h3>Prerequisites</h3>
    <ul>
      <li><a href="https://dotnet.microsoft.com/en-us/download/dotnet/9.0" target="_blank" rel="noopener noreferrer">.NET 9 SDK</a></li>
      <li><a href="https://nodejs.org/en/download/" target="_blank" rel="noopener noreferrer">Node.js and npm</a></li>
      <li>SQL Server</li>
      <li>Angular CLI (optional, for frontend development)
        <pre><code>npm install -g @angular/cli</code></pre>
      </li>
    </ul>

    <h3>Setup Instructions</h3>

    <h4>Backend Setup</h4>
    <ol>
      <li>Clone the repository:
        <pre><code>git clone https://github.com/VasilevaSimona/InventoryManagement.git</code></pre>
      </li>
      <li>Navigate to the backend project folder (if applicable):
        <pre><code>cd InventoryManagement</code></pre>
      </li>
      <li>Configure the database connection string in <code>appsettings.json</code> for your SQL Server instance.</li>
      <li>Apply migrations to create the database schema:
        <pre><code>dotnet ef database update</code></pre>
      </li>
      <li>Run the backend API server:
        <p>You can access the backend Swagger UI for testing and API exploration here:</p>
        <p><a href="https://localhost:44324/swagger/index.html" target="_blank" rel="noopener noreferrer">https://localhost:44324/swagger/index.html</a></p>
      </li>
    </ol>

    <h4>Frontend Setup</h4>
    <ol>
      <li>Navigate to the frontend project folder:
        <pre><code>cd InventoryManagementFrontend</code></pre>
      </li>
      <li>Install frontend dependencies:
        <pre><code>npm install</code></pre>
      </li>
      <li>Start the Angular development server:
        <pre><code>ng serve</code></pre>
      </li>
      <li>Open your browser and navigate to:
        <p><code>http://localhost:4200</code></p>
      </li>
    </ol>
    
    <h2>Usage</h2>
    <p>After starting both backend and frontend servers, you can use the Angular app to manage products via the user interface.</p>
    <p>Alternatively, you can test backend API endpoints directly using the Swagger UI.</p>

    
  </div>
</body>
</html>
