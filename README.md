# toDoAppWithCSharp

A backend for a personal TODO applicationwrting with C# and .NET 6.0

## Endpoints 
- **POST** */api/v1/signup*: Sign up as an user of the system, using email & password
- **POST** */api/v1/signin*: Sign in using email & password. The system will return the JWT token that can be used to call the APIs that follow
- **PUT** */api/v1/changePassword*: Change user’s password
- **GET** */api/v1/todos?status=[status]*: Get a list of todo items. Optionally, a status query param can be included to return only items of specific status. If not present, return all items
- **POST** */api/v1/todos*: Create a new todo item
- **PUT** */api/v1/todos/:id*: Update a todo item
- **DELETE** */api/v1/todos/:id*: Delete a todo item

## Requirements

- .NET 6.0
- Visual Studio

## Installation

- Clone the project:

```zsh
git clone https://github.com/HangHuynh19/toDoAppWithCSharp.git

```

- Open the project on Visual Studio
- Install the following Nuget packages: 
  + "ErrorOr", 
  + "Microsoft.AspNetCore.Authentication.JwtBearer", 
  + "Microsoft.Extensions.Configuration", 
  + "Microsoft.Extensions.DependencyInjection.Abstractions", 
  + "Microsoft.Extensions.Options.ConfigurationExtensions", 
  + "System.IdentityModel.Tokens.Jwt" version="6.26.1"

- Run the project with the following command:
```zsh
dotnet run --project ./ToDoAppWithCSharp/
```
