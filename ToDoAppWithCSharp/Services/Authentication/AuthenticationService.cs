using ToDoAppWithCSharp.Common.Interfaces.Authentication;

namespace ToDoAppWithCSharp.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Register(string email, string password)
    {
        // Check if user already exists

        // Create user with unique ID 

        // Create JWT token 
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, email);

        return new AuthenticationResult(userId, email, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), email, "token");
    }
}