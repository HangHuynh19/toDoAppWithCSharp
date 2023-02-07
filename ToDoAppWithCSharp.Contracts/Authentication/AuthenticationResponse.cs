namespace ToDoAppWithCSharp.Contracts.Authentication;

public record AuthenticationResponse(
    Guid UserId,
    string Email,
    string Token
);