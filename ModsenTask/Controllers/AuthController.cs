using Microsoft.AspNetCore.Mvc;
using ModsenTask.Dtos;
using ModsenTask.Services.Interfaces;

namespace ModsenTask.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<string> Login([FromBody] LoginDto loginDto)
    {
        return await _authService.Login(loginDto);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterOrganizerDto registerOrganizerDto)
    {
        return Ok(await _authService.Register(registerOrganizerDto));
    }
}