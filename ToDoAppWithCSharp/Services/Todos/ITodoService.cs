using ErrorOr;
using ToDoAppWithCSharp.Models;

namespace ToDoAppWithCSharp.Services.Todos;

public interface ITodoService
{
    ErrorOr<Created> CreateTodo(Todo todo);
    ErrorOr<Deleted> DeleteTodo(Guid id);
    ErrorOr<Todo> GetTodo(Guid id);
    ErrorOr<List<Todo>> GetAllTodos();
    ErrorOr<UpdateTodo> UpdateTodo(Todo todo);
}