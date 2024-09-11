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
