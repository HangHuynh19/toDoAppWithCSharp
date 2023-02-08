using Microsoft.Extensions.DependencyInjection;
using ToDoAppWithCSharp.Services.Authentication;
using ToDoAppWithCSharp.Services.Todos;

namespace ToDoAppWithCSharp;

public static class ToDoAppWithCSharp
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ITodoService, TodoService>();
        return services;
    }
}