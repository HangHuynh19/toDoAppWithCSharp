using Microsoft.AspNetCore.Mvc;
using ToDoAppWithCSharp.Contracts.Authentication;

namespace ToDoAppWithCSharp.Controllers;

[ApiController]
[Route("api/v1")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("signup")]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok(request);
    }

    [HttpPost("signin")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(request);
    }
}