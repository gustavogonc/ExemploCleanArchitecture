using ExemploCleanArchitecture.Application.DTOs;
using ExemploCleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExemploCleanArchitecture.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authService;
    public AuthenticationController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
    {
        try
        {
            var userData = await _authService.LoginAsync(loginRequest);

            if (userData is null)
            {
                return BadRequest("Invalid login data provided!");
            }

            return Ok(userData);

        }
        catch (Exception)
        {
            return Problem("An unexpected error ocurred! Try again later.", null, 500, "Unexpected Error!", null);
        }
    }
}

