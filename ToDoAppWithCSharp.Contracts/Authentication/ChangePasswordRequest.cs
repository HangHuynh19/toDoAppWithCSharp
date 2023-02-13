namespace ToDoAppWithCSharp.Contracts.Authentication;

public record ChangePasswordRequest(
    string Email,
    string Password,
    string NewPassword,
    Guid UserId,
    DateTime CreatedDate
);