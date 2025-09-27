using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentManagementSystem.API.DTOS;
using RecruitmentManagementSystem.API.DTOS.Request;
using RecruitmentManagementSystem.API.DTOS.Response;
using RecruitmentManagementSystem.API.Models;
using RecruitmentManagementSystem.API.Services;

namespace RecruitmentManagementSystem.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterRequestDto request)
        {
            var user = await _authService.RegisterAsync(request: request);

            if (user is null)
            {
                return BadRequest("user already exists or invalid inputs.");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var resultResponse = await _authService.LoginAsync(request: request);

            if (resultResponse is null)
            {
                return BadRequest("User/Password Invalid");
            }

            return Ok(resultResponse);
        }


        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await _authService.RefreshTokensAsync(request);

            if (result is null || result.AuthToken is null || result.RefreshToken is null)
            {
                return BadRequest("Invalid refresh token");
            }

            return Ok(result);
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> Auth()
        {
            return Ok("Authed");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("auth-admin")]
        public ActionResult<string> AuthAdmin()
        {
            return Ok("Authed");
        }
    }
}
