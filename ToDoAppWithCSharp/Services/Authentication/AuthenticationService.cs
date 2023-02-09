using ErrorOr;
using ToDoAppWithCSharp.Common.Interfaces.Authentication;
using ToDoAppWithCSharp.Models;

namespace ToDoAppWithCSharp.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private static readonly List<User> _users = new();
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public ErrorOr<AuthenticationResult> Register(User user)
    {
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, user.Email);
        _users.Add(user);

        return new AuthenticationResult(userId, user.Email, token);
    }

    public ErrorOr<AuthenticationResult> Login(User user)
    {
        Guid userId = Guid.Empty;

        foreach (var u in _users)
        {
            if (u.Email == user.Email)
            {
                userId = u.UserId;
                break;
            }
        }

        return new AuthenticationResult(userId, user.Email, _jwtTokenGenerator.GenerateToken(userId, user.Email));
    }

    public ErrorOr<AuthenticationResult> ChangePassword(User user)
    {
        int index = _users.FindIndex(u => u.Email == user.Email);
        _users[index] = user;

        return new AuthenticationResult(user.UserId, user.Email, _jwtTokenGenerator.GenerateToken(user.UserId, user.Email));
    }
}