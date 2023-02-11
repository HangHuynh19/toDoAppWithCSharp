namespace ToDoAppWithCSharp.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password,
    Guid UserId,
    DateTime CreatedDate,
    DateTime UpdatedDate
);