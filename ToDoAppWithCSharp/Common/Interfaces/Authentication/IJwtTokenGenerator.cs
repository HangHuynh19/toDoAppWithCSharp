using ToDoAppWithCSharp.Models;

namespace ToDoAppWithCSharp.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}