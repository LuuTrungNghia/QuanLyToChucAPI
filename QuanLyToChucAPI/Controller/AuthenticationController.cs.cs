using Microsoft.AspNetCore.Mvc;
using QuanLyToChucAPI.DTOs;
using QuanLyToChucAPI.Services;
using System.Threading.Tasks;

namespace QuanLyToChucAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SystemRegisterUserDTO user)
        {
            var result = await _authService.RegisterSystemUser(user);
          
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SystemSignInUserDTO credentials)
        {
            var result = await _authService.LoginSystemUser(credentials);
          
            return Ok(result);
        }
    }
}
