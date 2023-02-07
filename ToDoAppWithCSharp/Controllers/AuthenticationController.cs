using Microsoft.AspNetCore.Mvc;
using ToDoAppWithCSharp.Contracts.Authentication;
using ToDoAppWithCSharp.Services.Authentication;

namespace ToDoAppWithCSharp.Controllers;

[ApiController]
[Route("api/v1")]
public class AuthenticationController : ControllerBase
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