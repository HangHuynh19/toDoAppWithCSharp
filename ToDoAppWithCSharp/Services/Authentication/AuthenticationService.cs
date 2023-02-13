using ErrorOr;
using ToDoAppWithCSharp.Common.Interfaces.Authentication;
using ToDoAppWithCSharp.Common.Interfaces.Persistence;
using ToDoAppWithCSharp.Models;
using ToDoAppWithCSharp.ServiceErrors;

namespace ToDoAppWithCSharp.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(User user)
    {
        if (_userRepository.GetUserByEmail(user.Email) is not null)
        {
            //throw new Exception("User already exists"); //TODO: use ErrorOr here
            return Errors.User.UserAlreadyExists;
        }

        var userResult = User.Create(user.Email, user.Password);
        _userRepository.AddUser(userResult);

        var token = _jwtTokenGenerator.GenerateToken(userResult.Value);

        return new AuthenticationResult(
            userResult.Value,
            token);
    }

    public ErrorOr<AuthenticationResult> Login(User inputUser)
    {
        if (_userRepository.GetUserByEmail(inputUser.Email) is not User user)
        {
            return Errors.User.UserNotExists;
        }

        if (user.Password != inputUser.Password)
        {
            return Errors.User.InvalidUsernameOrPassword;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> ChangePassword(User inputUser, string newPassword)
    {
        if (_userRepository.GetUserByEmail(inputUser.Email) is not User user)
        {
            return Errors.User.UserNotExists;
        }

        //User user = _userRepository.GetUserByEmail(inputUser.Email);

        if (user.Password != inputUser.Password)
        {
            return Errors.User.InvalidUsernameOrPassword;
        }

        user = _userRepository.UpdateUserPassword(inputUser, newPassword);
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}