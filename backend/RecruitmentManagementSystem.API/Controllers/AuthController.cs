using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.DTOS;
using RecruitmentManagementSystem.API.Models;
using RecruitmentManagementSystem.API.Services;

namespace RecruitmentManagementSystem.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        public static User user = new();
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await _authService.RegisterAsync(request: request);
            
            if(user is null)
            {
                return BadRequest("user already exists.");
            }
            
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var token = await _authService.LoginAsync(request: request);

            if (token is null) {
                return BadRequest("User/Password Invalid");
            }

            return Ok(token);
        }


    }
}
