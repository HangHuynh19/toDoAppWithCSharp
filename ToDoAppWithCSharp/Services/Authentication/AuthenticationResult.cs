namespace ToDoAppWithCSharp.Services.Authentication;

public record AuthenticationResult(
    Guid UserId,
    string Email,
    DateTime CreatedDate,
    DateTime UpdatedDate,
    string Token
);