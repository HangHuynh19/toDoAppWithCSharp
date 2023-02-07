using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using ToDoAppWithCSharp.Contracts.Todo;
using ToDoAppWithCSharp.Contracts.Util;
using ToDoAppWithCSharp.Models;
using ToDoAppWithCSharp.ServiceErrors;
using ToDoAppWithCSharp.Services.Todos;

namespace ToDoAppWithCSharp.Controllers;

public class TodosController : ApiController
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpPost]
    public IActionResult CreateTodo(CreateTodoRequest request) 
    {
        ErrorOr<Todo> requestToTodoResult = Todo.From(request);

        if (requestToTodoResult.IsError)
        {
            return Problem(requestToTodoResult.Errors);
        }

        var todo = requestToTodoResult.Value;
        // TODO: save todo to database
        ErrorOr<Created> createTodoResult = _todoService.CreateTodo(todo);
        

        return createTodoResult.Match(
            created => CreatedAtGetTodo(todo),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public IActionResult GetAllTodos()
    {
        ErrorOr<List<Todo>> getAllTodosResult = _todoService.GetAllTodos();

        return getAllTodosResult.Match(
            todoList => Ok(MapTodoListResponse(todoList)),
            errors => Problem(errors)
        );

    }

    [HttpGet("{id:guid}")]
    public IActionResult GetTodo(Guid id) 
    {
        ErrorOr<Todo> getTodoResult = _todoService.GetTodo(id);

        return getTodoResult.Match(
            todo => Ok(MapTodoResponse(todo)),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateTodo(Guid id, UpdateTodoRequest request) 
    {
        ErrorOr<Todo> requestToTodoResult = Todo.From(id, request);

        if (requestToTodoResult.IsError)
        {
            return Problem(requestToTodoResult.Errors);
        }

        var todo = requestToTodoResult.Value;

        ErrorOr<UpdateTodo> updateTodoResult = _todoService.UpdateTodo(todo);

        return updateTodoResult.Match(
            updated => updated.IsNewlyCreated ? CreatedAtGetTodo(todo) : NoContent(),
            errors => Problem(errors)
        );
    }


    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTodo(Guid id) 
    {
        ErrorOr<Deleted> deleteTodoResult = _todoService.DeleteTodo(id);

        return deleteTodoResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static TodoResponse MapTodoResponse(Todo todo)
    {
        return new TodoResponse(
            todo.TodoID,
            todo.Name,
            todo.Description,
            todo.UserID,
            todo.CreatedDate,
            todo.UpdatedDate,
            todo.Status
        );
    }

    private static List<TodoResponse> MapTodoListResponse(List<Todo> todoList)
    {
        List<TodoResponse> todoListResponse = new(); 
        foreach (var item in todoList)
        {
            todoListResponse.Add(new TodoResponse(
                item.TodoID,
                item.Name,
                item.Description,
                item.UserID,
                item.CreatedDate,
                item.UpdatedDate,
                item.Status));
        }
        
        return todoListResponse;
    }

    private CreatedAtActionResult CreatedAtGetTodo(Todo todo)
    {
        return CreatedAtAction(
            actionName: nameof(GetTodo),
            routeValues: new { id = todo.TodoID},
            value: MapTodoResponse(todo)
        );
    }
}

