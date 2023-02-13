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

    public static class User
    {
        public static Error InvalidPassword => Error.Validation(
            code: "User.InvalidPassword",
            description: $"Password must be at least {Models.User.MinPasswordLength} characters.");

        public static Error InvalidEmail => Error.Validation(
            code: "User.InvalidEmail",
            description: $"Invalid email");

        public static Error UserAlreadyExists => Error.Validation(
            code: "User.UserAlreadyExists",
            description: $"User already exists.");

        public static Error InvalidUsernameOrPassword => Error.Validation(
            code: "User.InvalidUsernameOrPassword",
            description: $"Username or password is not correct.");

        public static Error UserNotExists => Error.Validation(
            code: "User.UserNotExists",
            description: $"This user is not found.");
    }
}