namespace ToDoAppWithCSharp.Contracts.Authentication;

public record ChangePasswordRequest(
    string Email,
    string Password
);