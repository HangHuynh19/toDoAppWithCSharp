using ErrorOr;
using ToDoAppWithCSharp.Models;

namespace ToDoAppWithCSharp.Services.Authentication;

public interface IAuthenticationService
{
    ErrorOr<AuthenticationResult> Register(User user);
    ErrorOr<AuthenticationResult> Login(User user);
    ErrorOr<AuthenticationResult> ChangePassword(User user, string newPassword);
}