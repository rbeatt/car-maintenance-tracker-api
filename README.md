# Car Maintenance Tracker API

A simple ASP.NET Core Web API for tracking cars and their maintenance records. This project supports secure authentication, validation, and CRUD operations for cars and their maintenance history.

## Features

- Manage cars (add, update, delete, list, get details)
- Track maintenance records for each car
- Secure endpoints with Azure AD authentication (JWT Bearer)
- Model validation with DataAnnotations
- Entity Framework Core for data access
- Swagger/OpenAPI documentation

## Project Structure

```
Controllers/         # API controllers
Data/                # Entity Framework DbContext
DTOs/                # Data Transfer Objects (if used)
Extensions/          # Extension methods (if used)
Migrations/          # EF Core migrations
Models/              # Entity models
Services/            # Business logic/services
Properties/          # launchSettings.json
Program.cs           # Main entry point
appsettings.json     # Configuration
.gitignore           # Git ignore rules
```

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server or SQLite (update connection string as needed)

### Setup

1. **Clone the repository**
   ```sh
   git clone https://github.com/yourusername/car-maintenance-tracker-api.git
   cd car-maintenance-tracker-api
   ```

2. **Configure the database**
   - Edit `appsettings.json` and set your `DefaultConnection` string.

3. **Apply database migrations**
   ```sh
   dotnet ef database update
   ```

4. **Run the API**
   ```sh
   dotnet run
   ```

5. **Explore the API**
   - Open Swagger UI at `https://localhost:7178/swagger` (port may vary).

## API Endpoints

| Method | Endpoint                    | Description                            |
| ------ | --------------------------- | -------------------------------------- |
| GET    | `/cars`                     | List all cars                          |
| GET    | `/cars/{id}`                | Get details for a specific car         |
| POST   | `/cars`                     | Add a new car                          |
| PUT    | `/cars/{id}`                | Update car info                        |
| DELETE | `/cars/{id}`                | Remove a car                           |
| GET    | `/cars/{carId}/maintenance` | List all maintenance records for a car |
| POST   | `/cars/{carId}/maintenance` | Add a maintenance record for a car     |
| PUT    | `/maintenance/{id}`         | Update a maintenance record            |
| DELETE | `/maintenance/{id}`         | Delete a maintenance record            |

## Security

- Endpoints are protected with Azure AD JWT Bearer authentication.
- Use HTTPS for all requests.
- Sensitive configuration (like secrets) should not be committed.

## Development

- Code style: C#, .NET 9, async/await
- Uses [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- Uses [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) for Swagger/OpenAPI

## License

MIT

---

**Note:**  
Update the connection string and authentication settings in `appsettings.json` as