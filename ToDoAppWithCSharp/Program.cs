//using ToDoAppWithCSharp.Services.Todos; 
using ToDoAppWithCSharp;
using ToDoAppWithCSharp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure();

    builder.Services.AddControllers();
    //builder.Services.AddScoped<ITodoService, TodoService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


