using ToDoAppWithCSharp.Models;

namespace ToDoAppWithCSharp.Services.Authentication;

public record AuthenticationResult(
    /* Guid UserId,
    string Email,
    DateTime CreatedDate,
    DateTime UpdatedDate, */
    User user,
    string Token
);