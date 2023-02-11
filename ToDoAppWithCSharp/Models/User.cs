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
    public DateTime CreatedDate { get; }
    public DateTime UpdatedDate { get; }

    private User(Guid userId, string email, string password, DateTime createdDate, DateTime updatedDate)
    {
        UserId = userId;
        Email = email;
        Password = password;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }

    public static ErrorOr<User> Create(
        string email,
        string password,
        Guid? userId = null,
        DateTime? createdDate = null,
        DateTime? updatedDate = null)
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
            password,
            createdDate ?? DateTime.UtcNow,
            updatedDate ?? DateTime.UtcNow);
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
            request.Password,
            request.UserId,
            request.CreatedDate,
            request.UpdatedDate

        );
    }

    public static ErrorOr<User> From(ChangePasswordRequest request)
    {
        return Create(
            request.Email,
            request.Password,
            request.UserId,
            request.CreatedDate
        );
    }
}