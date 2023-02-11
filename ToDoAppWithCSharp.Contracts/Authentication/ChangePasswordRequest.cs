namespace ToDoAppWithCSharp.Contracts.Authentication;

public record ChangePasswordRequest(
    string Email,
    string Password,
    Guid UserId,
    DateTime CreatedDate
);