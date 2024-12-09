using GreenTalk.Application.DTOs.AuthDTOs;
using GreenTalk.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenTalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                var response = await _authService.LoginAsync(loginRequestDto);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid username or password.");
            }
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Test()
        {
            IEnumerable<string> list = new List<string>() { "melih.kamar","tugba.kamar"};

            return Ok(list);
        }
    }
}
