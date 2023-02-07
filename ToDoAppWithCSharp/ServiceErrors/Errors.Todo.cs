using ErrorOr;

namespace ToDoAppWithCSharp.ServiceErrors;

public static class Errors
{
    public static class Todo
    {
        public static Error InvalidTodoName => Error.Validation(
            code: "Todo.InvalidTodoName",
            description: $"Todo name must be at least {Models.Todo.MinNameLength} characters and"
            + $" at most {Models.Todo.MaxNameLength} characters."
        );
        public static Error NotFound => Error.NotFound(
            code: "Todo.NotFound",
            description: "Todo not found"
        );
    }
}