using ExemploCleanArchitecture.Application.DTOs;
using ExemploCleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExemploCleanArchitecture.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Authorize]
    [HttpGet("recover-active-users")]
    public async Task<IActionResult> GetActiveUsers()
    {
        try
        {
            var data = await _userService.RecoverActiveUsersAsync();
            return Ok(data);
        }
        catch (Exception ex)
        {

            return Problem("An unexpected error ocurred! Try again later.", null, 500, "Unexpected Error!", null);
        }
    }

    [HttpPost("register-new-user")]
    public async Task<IActionResult> RegisterNewUser(RegisterUserDTO userRequest)
    {
        try
        {
            await _userService.RegisterNewUserAsync(userRequest);

            return Created();
        }
        catch (Exception ex)
        {

            if (ex is InvalidDataException)
            {
                return BadRequest(ex.Message);
            }

            return Problem("An unexpected error ocurred! Try again later.", null, 500, "Unexpected Error!", null);
        }
    }
}

