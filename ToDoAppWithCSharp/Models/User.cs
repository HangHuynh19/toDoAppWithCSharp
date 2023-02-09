using ErrorOr;
using ToDoAppWithCSharp.Common.Interfaces.Authentication;
using ToDoAppWithCSharp.Contracts.Authentication;
using ToDoAppWithCSharp.ServiceErrors;

namespace ToDoAppWithCSharp.Models;

public class User
{
    public const int MinPasswordLength = 6;
    public Guid UserId { get; }
    public string Email { get; }
    public string Password { get; }

    private User(Guid userId, string email, string password)
    {
        UserId = userId;
        Email = email;
        Password = password;
    }

    public static ErrorOr<User> Create(
        string email,
        string password,
        Guid? userId = null)
    {
        List<Error> errors = new();

        if (!email.Contains("@"))
        {
            errors.Add(Errors.User.InvalidEmail);
        }

        if (password.Length is < MinPasswordLength)
        {
            errors.Add(Errors.User.InvalidPassword);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new User(
            userId ?? Guid.NewGuid(),
            email,
            password);
    }

    public static ErrorOr<User> From(RegisterRequest request)
    {
        return Create(
            request.Email,
            request.Password
        );
    }

    public static ErrorOr<User> From(LoginRequest request)
    {
        return Create(
            request.Email,
            request.Password
        );
    }

    public static ErrorOr<User> From(ChangePasswordRequest request)
    {
        return Create(
            request.Email,
            request.Password
        );
    }
}