using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoAppWithCSharp.Contracts.Authentication;
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
        var authResult = _authenticationService.Register(
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            authResult.UserId,
            authResult.Email,
            authResult.Token
        );

        return Ok(response);
    }

    [HttpPost("signin")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            authResult.UserId,
            authResult.Email,
            authResult.Token
        );

        return Ok(request);
    }
}