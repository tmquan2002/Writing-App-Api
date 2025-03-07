# Writings API

This is a .NET 8.0 web API for managing writings, following the principles of Clean Architecture.

## Project Structure

- `src/Writings.API`: The main API project. This is the entry point of the application.
- `src/Writings.Application`: Contains the application logic. This layer is responsible for the application's behavior and policies.
- `src/Writings.Domain`: Contains enterprise logic and types. This is the core layer of the application.
- `src/Writings.Infrastructure`: Contains infrastructure-related code such as database and file system interactions. This layer supports the higher layers.

## Packages and Libraries

This project uses several NuGet packages and libraries to achieve its functionality:

- **Microsoft and Oracle Entity Framework**: This is an open-source ORM framework for .NET. It enables developers to work with data using objects of domain-specific classes without focusing on the underlying database tables and columns where this data is stored.

- **Microsoft Identity Package**: This package is used for handling user identity in the web API. It provides features such as authentication, authorization, identity, and user access control.

Please refer to the official documentation of each package for more details and usage examples.

## Getting Started

### Prerequisites

- .NET 8.0
- Visual Studio 2022 or later

### Building

To build the project, open the `WritingApp.API.sln` file in Visual Studio and build the solution.

### Running

To run the project, set `WritingApp.API` as the startup project in Visual Studio and start the application.

## API Endpoints

1. `GET /api/writings`
   - Parameters: `searchPhrase`, `pageSize`, `pageNumber`, `sortBy`, `sortDirection` (No parameters currently)
  
2. `GET /api/writings/current` (In progress)
   - Authorization: Bearer token

3. `GET /api/writings/{id}`
   - Parameters: `id`

4. `DELETE /api/writings/{id}`
   - Parameters: `id`
   - Authorization: Bearer token

5. `DELETE /api/writings/{id}`
   - Parameters: `id`
   - Authorization: Bearer token

6. `POST /api/writings`
   - Body: JSON object with writings properties
   - Authorization: Bearer token

 
