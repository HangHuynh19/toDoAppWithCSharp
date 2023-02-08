using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ToDoAppWithCSharp.Common.Interfaces.Authentication;
using ToDoAppWithCSharp.Common.Interfaces.Services;
using ToDoAppWithCSharp.Services.Authentication;
using ToDoAppWithCSharp.Services.Todos;
using ToDoAppWithCSharp.Models;

namespace ToDoAppWithCSharp;

public static class ToDoAppWithCSharp
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<ITodoService, TodoService>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}