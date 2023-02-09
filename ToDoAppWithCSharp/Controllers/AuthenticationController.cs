using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAppWithCSharp.Contracts.Authentication;
using ToDoAppWithCSharp.Models;
using ToDoAppWithCSharp.Services.Authentication;

namespace ToDoAppWithCSharp.Controllers;

[Route("api/v1")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost("signup")]
    public IActionResult Register(RegisterRequest request)
    {
        /* ErrorOr<User> requestToUserResult = Models.User.From(request);
        var authResult = _authenticationService.Register(Models.User.From(request));

        var response = new AuthenticationResponse(
            authResult.UserId,
            authResult.Email,
            authResult.Token
        );

        return Ok(response); */
        ErrorOr<User> requestToUserResult = Models.User.From(request);

        if (requestToUserResult.IsError)
        {
            return Problem(requestToUserResult.Errors);
        }

        var user = requestToUserResult.Value;
        ErrorOr<AuthenticationResult> createUserResult = _authenticationService.Register(user);

        return createUserResult.Match(
            user => Ok(createUserResult),
            errors => Problem(errors)
        );
    }

    [HttpPost("signin")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<User> requestToUserResult = Models.User.From(request);

        if (requestToUserResult.IsError)
        {
            return Problem(requestToUserResult.Errors);
        }

        var user = requestToUserResult.Value;
        ErrorOr<AuthenticationResult> createUserResult = _authenticationService.Login(user);

        return createUserResult.Match(
            user => Ok(createUserResult),
            errors => Problem(errors)
        );
        /* var authResult = _authenticationService.Login(
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            authResult.UserId,
            authResult.Email,
            authResult.Token
        );

        return Ok(response); */
    }

    [HttpPut("changePassword")]
    [Authorize]
    public IActionResult ChangePassword(ChangePasswordRequest request)
    {
        ErrorOr<User> requestToUserResult = Models.User.From(request);

        if (requestToUserResult.IsError)
        {
            return Problem(requestToUserResult.Errors);
        }

        var user = requestToUserResult.Value;
        ErrorOr<AuthenticationResult> createUserResult = _authenticationService.Login(user);

        return createUserResult.Match(
            user => Ok(createUserResult),
            errors => Problem(errors)
        );

        /* var authResult = _authenticationService.ChangePassword(
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            authResult.UserId,
            authResult.Email,
            authResult.Token
        );

        return Ok(response); */
    }
}