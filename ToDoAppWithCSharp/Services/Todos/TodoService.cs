using ErrorOr;
using ToDoAppWithCSharp.Models;
using ToDoAppWithCSharp.ServiceErrors;

namespace ToDoAppWithCSharp.Services.Todos;

public class TodoService : ITodoService
{
    private static readonly Dictionary<Guid, Todo> _todos = new();
    public ErrorOr<Created> CreateTodo(Todo todo)
    {
        _todos.Add(todo.TodoID, todo);

        return Result.Created;
    }

    public ErrorOr<Todo> GetTodo(Guid id)
    {
        if(_todos.TryGetValue(id, out var todo))
        {
            return todo;
        }

        return Errors.Todo.NotFound;
    }

    public ErrorOr<List<Todo>> GetAllTodos()
    {
        List<Todo> todoList = new(); 

        foreach (KeyValuePair<Guid, Todo> kvp in _todos)
        {
            todoList.Add(kvp.Value);
        }

        return todoList;
    }

    public ErrorOr<Deleted> DeleteTodo(Guid id)
    {
        _todos.Remove(id);

        return Result.Deleted;
    }

    public ErrorOr<UpdateTodo> UpdateTodo(Todo todo)
    {
        var isNewlyCreated = !_todos.ContainsKey(todo.TodoID);
        _todos[todo.TodoID] = todo;

        return new UpdateTodo(isNewlyCreated);
    }
}