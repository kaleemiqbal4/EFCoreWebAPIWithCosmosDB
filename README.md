# EFCoreCosmosDB

## Project Overview

`EFCoreCosmosDB` is a .NET 8 solution that demonstrates a clean architecture using Entity Framework Core with Cosmos DB. The solution is organized into multiple projects to promote separation of concerns and maintainability.

### Project Structure

- **`src/API/EFCoreCosmosDB.API`**: Contains the ASP.NET Core Web API project. This is the entry point of the application where API endpoints are defined.
- **`src/API/EFCoreCosmosDB.Application`**: Contains the application services and business logic.
- **`src/API/EFCoreCosmosDB.Entity`**: Contains the entity models and DbContext configurations.
- **`src/API/EFCoreCosmosDB.Repository`**: Contains the data access layer, including repositories and Unit of Work implementation.

### Getting Started

#### Prerequisites

- .NET 8 SDK
- Cosmos DB account
- (Optional) Node.js and npm/yarn for front-end dependencies

#### Setup

1. **Clone the repository:**
   ```bash
   git clone https://github.com/kaleemiqbal4/EFCoreWebAPIWithCosmosDB.git
   cd EFCoreCosmosDB
   ```
