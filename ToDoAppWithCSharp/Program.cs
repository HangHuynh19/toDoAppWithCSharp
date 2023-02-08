//using ToDoAppWithCSharp.Services.Todos; 
using ToDoAppWithCSharp;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication(builder.Configuration);

    builder.Services.AddControllers();
    //builder.Services.AddScoped<ITodoService, TodoService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}


