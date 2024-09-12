### Micro Service In Asp.Net Core

This is an example of micro service in asp.net core. You will find the overall concept of microservice using API gateway. I have used the concept of Ocelot for creating gateway that can be accessed by clients.

### Table of Contents

- Features
- Technologies
- Setup
- Usage

### Features

- Product (GetAll, GetById and Add) operation
- Order (GetAll, GetById and Add) operation

### Technologies

- Asp.Net Core
- EntityFramework Core
- SQL Server
- Ocelet

### Setup

1. Clone the repository

```sh
git clone
```

2. Navigate to the project directory

```sh
cd MicroService
```

3. Create appsettings.json file inside ProductMicroservice.Web and OrderMicroservice.Web, add following codes and fill required fields.

- For Product

```sh
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ProductMicroservices": "Server=localhost\\SQLEXPRESS;Database=MicroService_Db_Product;user=your_username;password=your_password;connect timeout=500;TrustServerCertificate=True;"
  }
}
```

- For Order

```sh
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ProductMicroservices": "Server=localhost\\SQLEXPRESS;Database=MicroService_Db_Order;user=your_username;password=your_password;connect timeout=500;TrustServerCertificate=True;"
  }
}
```

4. Setup databse

```sh
dotnet ef database update
```

5. Right Click on solution explorer, click Configure start up project, select multiple startup project and add ProductMicroservice.Web OrderMicroservice.Web
6. Run the application

```sh
dotnet run
```

### Usage

1. Open Api client such as postman or web browser
2. Use the add product end point to create the product
3. Use the place order endpoint to create the order where you can see that the api gateway is being called.
