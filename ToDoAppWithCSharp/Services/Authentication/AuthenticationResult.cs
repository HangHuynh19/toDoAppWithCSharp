namespace ToDoAppWithCSharp.Services.Authentication;

public record AuthenticationResult(
    Guid UserId,
    string Email,
    string Token
);