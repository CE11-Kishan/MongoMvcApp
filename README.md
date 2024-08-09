# MVC .NET App with MongoDB

## Overview
This project is a sample ASP.NET Core MVC application integrated with MongoDB. It provides a basic CRUD (Create, Read, Update, Delete) functionality for managing products.

## Features
- Create, view, update, and delete products
- Uses MongoDB for data storage
- Built with ASP.NET Core MVC for a robust web application

## Production URL
You can access the live application at: [https://productapp.somee.com/](https://productapp.somee.com/)

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [MongoDB](https://www.mongodb.com/try/download/community) (running instance)

### Setup
1. **Clone the repository:**
   ```sh
   git clone https://github.com/yourusername/your-repo.git
   cd your-repo
   ```

2. **Replace MongoDB Connection String:**
   - Open `appsettings.json` in the project directory.
   - Replace the placeholder MongoDB connection string with your own in the `ConnectionStrings` section.

3. **Restore dependencies:**
   ```sh
   dotnet restore
   ```

4. **Build the project:**
   ```sh
   dotnet build
   ```

5. **Run the application:**
   ```sh
   dotnet run
   ```

### Publish
To publish the application for deployment, use:
```sh
dotnet publish --configuration Release --output ./publish
```




