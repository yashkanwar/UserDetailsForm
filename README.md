# UserDetailsForm

## Project Overview

This project is a web application developed using ASP.NET Core Razor Pages. It allows users to manage their personal details through a user-friendly interface. The application supports functionalities for inserting, updating, and deleting user information.

## Features

- **Home Page:** Displays a list of all user entries with options to update or delete each entry.
- **Insert Page:** Allows users to add new entries.
- **Update Page:** Provides functionality to update existing user details.
- **Delete User Details:** Allows users to remove existing entries from the system.

- **Error Handling:** Includes error handling for different scenarios.

## Project Structure

- `Pages/` - Contains the Razor Pages for various functionalities.
  - `About.cshtml` - About page.
  - `Index.cshtml` - Home page displaying user entries.
  - `Insert.cshtml` - Page for inserting new users.
  - `Update.cshtml` - Page for updating existing users.
- `Delete.cshtml.cs` - Handles the backend logic for deleting user details.
  - `Shared/` - Contains shared layout and validation scripts.
- `Models/` - Contains the data models.
  - `UserDetails.cs` - Model for user details.
- `Data/` - Contains the database context.
  - `ApplicationDbContext.cs` - Database context class.
- `wwwroot/` - Contains static files like CSS, JavaScript, and images.
  - `css/` - Stylesheets.
  - `js/` - JavaScript files.
 
## Prerequisites

Before setting up and running this project, ensure that you have the following software and packages installed:

### Software
- **Visual Studio** - To build and run the .NET project.
- **SQL Server** - To host the database.
- **SSMS (SQL Server Management Studio)** - Optional, but recommended for managing your SQL Server database.

### NuGet Packages
- **Microsoft.EntityFrameworkCore** - For interacting with the database through Entity Framework Core.
- **Microsoft.EntityFrameworkCore.SqlServer** - For connecting Entity Framework Core to SQL Server.
- **Microsoft.EntityFrameworkCore.Tools** - For running migrations and scaffolding from the command line in Visual Studio.

### Additional Requirements
- A working SQL Server instance to run the database for the project.
- The connection string in the `appsettings.json` file should point to your SQL Server instance and database.

## Project Setup

### Database Setup Instructions

To set up the database for this project, follow these steps:

1. **Create a Database**:
   - Create a new database in your SQL Server instance. You can name it `UserDetailsDb` or any other name you prefer.

2. **Create a Table**:
   - Create a table in the database with the following schema:

   ```sql
   CREATE TABLE UserDetails (
       Id INT IDENTITY(1,1) PRIMARY KEY,    -- Auto-incrementing primary key
       FirstName NVARCHAR(100) NOT NULL,    -- Required field
       MiddleName NVARCHAR(100) NOT NULL,   -- Required field
       LastName NVARCHAR(100) NOT NULL,     -- Required field
       DOB DATE NOT NULL,                   -- Required field
       State NVARCHAR(100) NOT NULL,        -- Required field
       City NVARCHAR(100) NOT NULL,         -- Required field
       Email NVARCHAR(255) NOT NULL UNIQUE  -- Required field, unique constraint
   );

3. Update Connection String in your appsettings.json file:
```
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=UserDetailsDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
4. ApplicationDbContext.cs
The ```ApplicationDbContext``` file configures the connection between the application and the database. It defines the ```DbSet<UserDetails>``` which maps to the ```UserDetails``` table in the database, enabling interaction with the user data.
